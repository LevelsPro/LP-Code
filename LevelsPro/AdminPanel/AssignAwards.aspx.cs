using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class AssignAwards :AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!Page.IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    LoadPlayers();
                    LoadAwards();
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            ExceptionUtility.CheckForErrorMessage(Session);
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        #region assign award to user code
        protected void btnAssignAward_Click(object sender, EventArgs e)
        {
            try
            {
                              
                UserAwards Awards = new UserAwards();
                Awards.User_Id = Convert.ToInt32(ddlPalyer.SelectedValue);
                Awards.Award_Id = Convert.ToInt32(ddlAward.SelectedValue);
                Awards.AwardDate = DateTime.Now;
                Awards.Manual = 1;
                Awards.AwardedBy = Convert.ToInt32(Session["Userid"]);
                
                UserAwardInsertBLL insert = new UserAwardInsertBLL();
                insert.Award = Awards;
                insert.Invoke();

                lblmessage.Visible = true;
                lblmessage.Text = Resources.TestSiteResources.AssignedAward;

                LoadData();
                Session["DebLogString"] = "[User " + Awards.AwardedBy + "] assigned [Award " + Awards.Award_Id + "] to [User " + Awards.User_Id + "]";
                log.Debug(Session["DebLogString"]);
            }
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                ExceptionUtility.ExceptionLogString(ex, Session);
                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                log.Debug(Session["ExpLogString"]);
                
                if (ex.Message.Contains("Duplicate"))
                {
                    lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.AlreadyAssigned;
                }
                else
                {
                    lblmessage.Text = Resources.TestSiteResources.NotAssigned;
                }
            }
        }
        #endregion

        #region Load all players
        public void LoadPlayers()
        {
            UserViewBLL player = new UserViewBLL();

            Common.User _user = new User();

            _user.Where = "";

            player.User = _user;
            DataSet dsPlayer = new DataSet();
            try
            {
                player.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dsPlayer = player.ResultSet;

            ddlPalyer.DataTextField = "FullName";
            ddlPalyer.DataValueField = "UserID";

            DataView dv = dsPlayer.Tables[0].DefaultView;
            try
            {
                ddlPalyer.DataSource = dv.ToTable();
                ddlPalyer.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            ListItem li = new ListItem("Select", "0");
            ddlPalyer.Items.Insert(0, li);
        }
        #endregion

        #region load all awards 
        public void LoadAwards()
        {
            AwardViewBLL award = new AwardViewBLL();
             DataSet dsAwards = new DataSet();
            try
            {
                award.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dsAwards = award.ResultSet;

            ddlAward.DataTextField = "Award_Name";
            ddlAward.DataValueField = "Award_ID";

            DataView dv = dsAwards.Tables[0].DefaultView;

            dv.RowFilter = "Award_Manual = 1";
            DataTable dt = dv.ToTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlAward.DataSource = dt;
                ddlAward.DataBind();
            }

            ListItem li = new ListItem("Select", "0");
            ddlAward.Items.Insert(0, li);
        }
        #endregion

        protected void gvAwards_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAwards.PageIndex = e.NewPageIndex;
            try
            {
                LoadData();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        protected void LoadData()
        {
            ManualAwardViewBLL manual = new ManualAwardViewBLL();

            try
            {
                manual.Invoke();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            if (manual.ResultSet != null && manual.ResultSet.Tables.Count > 0 && manual.ResultSet.Tables[0] != null && manual.ResultSet.Tables[0].Rows.Count > 0)
            {
                gvAwards.DataSource = manual.ResultSet;
                gvAwards.DataBind();
            }
            else
            {
                gvAwards.DataSource = null;
                gvAwards.DataBind();
            }
        }
    }
}