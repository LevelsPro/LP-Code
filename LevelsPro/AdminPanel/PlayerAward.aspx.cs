using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic.Select;
using Common;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using BusinessLogic.Delete;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class PlayerAward : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    LoadAwards();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    ViewState["userid"] = Request.QueryString["userid"];
                    LoadData(Convert.ToInt32(ViewState["userid"]));
                }

                if (Request.QueryString["levelid"] != null && Request.QueryString["levelid"].ToString() != "")
                {
                    ViewState["levelid"] = Request.QueryString["levelid"];
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerManagement.aspx");
        }

        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

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
        #region show player awards
        protected void LoadData(int UserID)
        {

            if (UserID > 0)
            {
                UserViewBLL player = new UserViewBLL();
                Common.User _user = new User();

                _user.Where = " WHERE tblUser.UserID = " + UserID.ToString();

                player.User = _user;
                try
                {
                    player.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
                DataView dvPlayer = player.ResultSet.Tables[0].DefaultView;
                if (dvPlayer != null && dvPlayer.ToTable().Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dvPlayer.ToTable();

                    lblFirstNameValue.Text = dt.Rows[0]["U_FirstName"].ToString();
                    lblLastNameValue.Text = dt.Rows[0]["U_LastName"].ToString();
                }


                ManualAwardViewBLL manual = new ManualAwardViewBLL();
                UserAwards userawards = new UserAwards();
                userawards.User_Id = UserID;
                manual.UserAwards = userawards;
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
                    dlAwards.DataSource = manual.ResultSet;
                    dlAwards.DataBind();
                }
                else
                {
                    dlAwards.DataSource = null;
                    dlAwards.DataBind();
                }
            }           
        }
        #endregion

        #region assign award to user
        protected void btnAssignAward_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
                {
                    UserAwards Awards = new UserAwards();
                    Awards.User_Id = Convert.ToInt32(ViewState["userid"]);
                    Awards.Award_Id = Convert.ToInt32(ddlAward.SelectedValue);
                    Awards.AwardDate = DateTime.Now;
                    Awards.Manual = 1;
                    Awards.AwardedBy = Convert.ToInt32(Session["Userid"]);

                    UserAwardInsertBLL insert = new UserAwardInsertBLL();
                    insert.Award = Awards;
                    insert.Invoke();

                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.AssignedAward;

                    LoadData(Convert.ToInt32(ViewState["userid"]));
                }
            }
            catch (Exception ex)
            {
                ExceptionUtility.ExceptionLogString(ex, Session);
                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                log.Debug(Session["ExpLogString"]);
                lblmessage.Visible = true;
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
        protected void dlAwards_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAward")
            {
                AssignAwardDeleteBLL awarddelete = new AssignAwardDeleteBLL();
                Award _award = new Award();
                _award.AwardID = Convert.ToInt32(e.CommandArgument);
                _award.UserID = Convert.ToInt32(ViewState["userid"]);
                awarddelete.Award = _award;
                try
                {
                    awarddelete.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                LoadData(Convert.ToInt32(ViewState["userid"]));
            }
        }

        protected void btnMainInfo_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("EditPlayer.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnProgress_Click(object sender, EventArgs e)
        {
            if (Session["LevelCheck"].ToString() != null && ViewState["userid"] != null)
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString() + "&levelid=" + Session["LevelCheck"].ToString(), false);
            }
            else if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnRewards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerRewards.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }
    }
}