using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLogic.Select;
using Common;
using System.Data;
using LevelsPro.App_Code;
using BusinessLogic.Update;
using LevelsPro.Util;

namespace LevelsPro.PlayerPanel
{
    public partial class ViewLevelAwards : AuthorizedPage
    {
        private static string pageURL;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                //btnMyAwards.Enabled = false;
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

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
                //Points points = new Points();
                Common.User user = new Common.User();

                //points.UserID = Convert.ToInt32(Session["userid"]);

                user.UserID = Convert.ToInt32(Session["userid"]);

                //award.Points = points;

                auto.User = user;

                try
                {
                    //award.Invoke();
                    auto.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (auto.ResultSet != null && auto.ResultSet.Tables.Count > 0 && auto.ResultSet.Tables[0] != null && auto.ResultSet.Tables[0].Rows.Count > 0)
                {
                    DataView dv = auto.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "AwardCategoryID=24"; //(Percentage >= 100 OR AchievedAward = 'yes') AND 

                    DataTable dt = dv.ToTable();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dlViewAwards.DataSource = dt;
                        dlViewAwards.DataBind();
                    }
                }
            }
        }



        //protected void dlViewAwards_ItemCommand(object source, DataListCommandEventArgs e)
        //{
        //    if (e.CommandName == "ViewAward")
        //    {
        //        Award _award = new Award();

        //        int id = Convert.ToInt32(e.CommandArgument);
        //        _award.AwardID = id;
        //        //ucAwardDetails.Load_AwardDetails(id);
        //        //mpeAwardDetails.Show();
        //        //upAwardDetails.Update();
        //    }
        //}

        protected void dlViewAwards_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblAwardDate = e.Item.FindControl("lblAwardDate") as Label;

                if (lblAwardDate.Text.Trim() != "")
                {
                    lblAwardDate.Text = "Earned " + Convert.ToDateTime(lblAwardDate.Text.Trim()).ToShortDateString();
                }
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

        protected void dlViewAwards_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPopup")
            {
                int awardid = Convert.ToInt32(e.CommandArgument);
                mpeAwardDetails.Show();
                ucAwardDetails.LoadData(awardid);
            }
        }

        protected void btnMyManagerAwards_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayerPanel/ViewManagerAwards.aspx", false);
        }
    }
}