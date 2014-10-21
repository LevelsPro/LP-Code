using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic.Select;
using Common;
using LevelsPro.App_Code;
using System.Configuration;
using BusinessLogic.Update;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class ViewMilestones : AuthorizedPage
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
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                btnMyAwards.Enabled = true;
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

        protected void LoadData()
        {
            string path = ConfigurationSettings.AppSettings["AwardsPath"].ToString();
            string Thumbpath = ConfigurationSettings.AppSettings["AwardsThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                ViewProfile.LoadData();
                lblName.Text = Session["displayname"].ToString() + " - " + Resources.TestSiteResources.AwardsB;
               
                GetAutomaticAwardsBLL auto = new GetAutomaticAwardsBLL();
               
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["userid"]);

                auto.User = user;

                try
                {                
                    auto.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (auto.ResultSet != null && auto.ResultSet.Tables.Count > 0 && auto.ResultSet.Tables[1] != null && auto.ResultSet.Tables[1].Rows.Count > 0)
                {
                    DataView dv = auto.ResultSet.Tables[1].DefaultView;

                    dv.RowFilter = "Award_Manual = 0 AND Percentage < 100";

                    DataTable dt = dv.ToTable();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dlViewAwards.DataSource = dt;
                        dlViewAwards.DataBind();
                    }
                }
            }
        }

        

        protected void dlViewAwards_ItemDataBound(object sender, DataListItemEventArgs e)
        {


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                
                Label lblPercentage = e.Item.FindControl("lblPercentage") as Label;
                
                decimal percentage = 0;
                percentage = Convert.ToDecimal(lblPercentage.Text.Trim());
                if (percentage > 100)
                    percentage = 100;
                lblPercentage.Text = Math.Round(percentage, 0).ToString() + "%";
                lblPercentage.Style.Add("width", Math.Round(percentage, 0).ToString() + "%");

                
            }


        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            User user = new User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}