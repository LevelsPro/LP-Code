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

namespace LevelsPro.PlayerPanel
{
    public partial class ViewLevelAwards : AuthorizedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                //btnMyAwards.Enabled = false;
            }
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