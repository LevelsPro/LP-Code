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

namespace LevelsPro.PlayerPanel
{
    public partial class ViewMilestones : AuthorizedPage
    {
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
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
                //PlayerAwardViewBLL award = new PlayerAwardViewBLL();
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

                //Label lblTargetScore = e.Item.FindControl("lblTargetScore") as Label;
                //Label lblAchievedScore = e.Item.FindControl("lblAchievedScore") as Label;
                //Label lblManual = e.Item.FindControl("lblManual") as Label;
                Label lblPercentage = e.Item.FindControl("lblPercentage") as Label;
                //Label lblAwardDate = e.Item.FindControl("lblAwardDate") as Label;
                //Image imgAwards = e.Item.FindControl("imgAwards") as Image;
                decimal percentage = 0;
                percentage = Convert.ToDecimal(lblPercentage.Text.Trim());
                if (percentage > 100)
                    percentage = 100;
                lblPercentage.Text = Math.Round(percentage, 0).ToString() + "%";
                lblPercentage.Style.Add("width", Math.Round(percentage, 0).ToString() + "%");

                //if (lblManual.Text.Trim().ToLower() == "false" || lblAwardDate.Text.Trim() == "")
                //{
                //    decimal total = 0;
                //    decimal achieved = 0;
                //    decimal percentage = 0;

                //    if (lblTargetScore.Text.Trim() != "")
                //    {
                //        total = Convert.ToInt32(lblTargetScore.Text.Trim());
                //    }

                //    if (lblAchievedScore.Text.Trim() != "")
                //    {
                //        achieved = Convert.ToInt32(lblAchievedScore.Text.Trim());
                //    }

                //    if (total != 0)
                //    {
                //        percentage = (achieved / total) * 100;
                //    }

                //    lblPercentage.Visible = true;
                //    lblPercentage.Text = Math.Round(percentage, 0).ToString() + "%";

                //    lblPercentage.Style.Add("width", Math.Round(percentage, 0).ToString() + "%");

                //    imgAwards.CssClass = "disabled-aw";
                //    //e.Item.CssClass = "disabled-aw";

                //}
                //else
                //{
                //    lblPercentage.Visible = false;
                //}

                //if (lblAwardDate.Text.Trim() != "")
                //{
                //    lblAwardDate.Text = "Earned " + Convert.ToDateTime(lblAwardDate.Text.Trim()).ToShortDateString();
                //}
                ////GelAllMilestonesBLL mile = new GelAllMilestonesBLL();

                ////Award award = new Award();

                ////award.AwardID = Convert.ToInt32(lblAwardID.Text.Trim());

                ////mile.Award = award;

                ////try
                ////{
                ////    mile.Invoke();
                ////}
                ////catch (Exception ex)
                ////{ 

                ////}

                ////DataSet ds = mile.ResultSet;

                ////if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                ////{
                ////    int AScore = 0;
                ////    int TValue = Convert.ToInt32(ds.Tables[0].Rows[0]["TargetValue"]);
                ////    if (ds.Tables[0].Rows[0]["AchievedScore"].ToString() == "")
                ////    {
                ////        AScore = 0;
                ////    }
                ////    else
                ////    {
                ////        AScore = Convert.ToInt32(ds.Tables[0].Rows[0]["AchievedScore"]);
                ////    }

                ////    int Percentage = 0;

                ////    if (TValue != 0)
                ////    {
                ////        Percentage = (AScore / TValue) * 100;
                ////    }
                ////    lblPercentage.Text = Percentage.ToString() + "%";
                ////}
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