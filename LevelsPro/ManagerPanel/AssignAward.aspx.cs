using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Delete;
using Common;
using BusinessLogic.Insert;
using System.Data;
using BusinessLogic.Select;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.ManagerPanel
{
    public partial class AssignAward : System.Web.UI.Page
    {
        private static string pageURL;
        private ILog log;
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
                if (Session["playerid"] != null && Session["playerid"].ToString() != "")
                {
                    ViewState["playerid"] = Session["playerid"];
                    try
                    {
                        LoadData(Convert.ToInt32(ViewState["playerid"]));
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                    Label2.Text = Resources.TestSiteResources.AssignAward1 + " to " + Session["playernamemanager"].ToString();
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

        protected void LoadData(int UserID)
        {

            if (UserID > 0)
            {
                Label2.Text = Resources.TestSiteResources.AssignAward1 + " to " + Session["playernamemanager"].ToString();

                ManualAwardViewBLL manual = new ManualAwardViewBLL();
                UserAwards userawards = new UserAwards();
                userawards.User_Id = UserID;
                manual.UserAwards = userawards;
                try
                {
                    manual.Invoke();
                }
                catch(Exception exp)
                {
                    throw exp;
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
        protected void btnAssignAward_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["playerid"] != null && ViewState["playerid"].ToString() != "")
                {
                    UserAwards Awards = new UserAwards();
                    Awards.User_Id = Convert.ToInt32(ViewState["playerid"]);
                    Awards.Award_Id = Convert.ToInt32(ddlAward.SelectedValue);
                    Awards.AwardDate = DateTime.Now;
                    Awards.Manual = 1;
                    Awards.AwardedBy = Convert.ToInt32(Session["Userid"]);

                    UserAwardInsertBLL insert = new UserAwardInsertBLL();
                    insert.Award = Awards;
                    insert.Invoke();

                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.AssignedAward;

                    //ddlAward.SelectedValue = "0";

                    try
                    {
                        LoadData(Convert.ToInt32(ViewState["playerid"]));
                    }
                    catch (Exception ex)
                    {

                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);

                        if (ex.Message.ToLower().Contains("duplicate"))
                        { }
                        else
                            throw ex;
                    }
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddlAward.SelectedValue = "0";
            lblmessage.Text = "";
            
        }



        protected void dlAwards_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAward")
            {
                AssignAwardDeleteBLL awarddelete = new AssignAwardDeleteBLL();
                Award _award = new Award();
                _award.AwardID = Convert.ToInt32(e.CommandArgument);
                _award.UserID = Convert.ToInt32(ViewState["playerid"]);
                awarddelete.Award = _award;
                try
                {
                    awarddelete.Invoke();
                    LoadData(Convert.ToInt32(ViewState["playerid"]));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        protected void exit_Click(object sender, ImageClickEventArgs e)
        {
            ddlAward.SelectedValue = "0";
            lblmessage.Text = "";
            Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["playerid"]) + "&likelihood=" + Session["likelihood"] + "&remaining=" + Convert.ToInt32(Session["remaining"]) + "&Base=" + Convert.ToInt32(Session["Base"]), false);
            
        }

      
    }
}