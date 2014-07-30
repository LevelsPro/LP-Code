using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Reports;
using System.Configuration;

namespace LevelsPro.ManagerPanel.UserControls
{
    public partial class uc_Profile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            string Thumbpath = "../" + ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                lblName.Text = Session["displayname"].ToString();
                lblRoleName.Text = Session["rolename"].ToString();
                UserImageViewBLL UserImage = new UserImageViewBLL();

                Common.UserImage image = new Common.UserImage();

                image.UserID = Convert.ToInt32(Session["userid"]);


                UserImage.UserImages = image;

                try
                {
                    UserImage.Invoke();
                }
                catch (Exception ex)
                {
                }
                DataView dvImage1 = UserImage.ResultSet.Tables[0].DefaultView;
                dvImage1.RowFilter = "U_Current=1";
                DataTable dtcImage = new DataTable();
                dtcImage = dvImage1.ToTable();
                if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                {
                    imgPhoto.ImageUrl = Thumbpath + dtcImage.Rows[0]["Player_Thumbnail"].ToString();
                }

                UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
                Common.User _user = new Common.User();

                _user.UserID = Convert.ToInt32(Session["userid"]);

                userlevel.User = _user;

                try
                {
                    userlevel.Invoke();
                }
                catch (Exception ex)
                {
                }

                if (userlevel.ResultSet != null && userlevel.ResultSet.Tables.Count > 0 && userlevel.ResultSet.Tables[0] != null && userlevel.ResultSet.Tables[0].Rows.Count > 0)
                {
                    lblLevelName.Text = Resources.TestSiteResources.LevelL + ' ' + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();//"Level 1";
                }
                else
                {
                    lblLevelName.Text = Resources.TestSiteResources.Level0;
                }


                //Points point = new Points();
                //point.UserID = Convert.ToInt32(Session["userid"]);
                //UserPointsReportBLL _usersum = new UserPointsReportBLL();
                //try
                //{
                //    _usersum.Points = point;
                //    _usersum.Invoke();
                //}
                //catch (Exception ex)
                //{
                //}
                //DataView dv = _usersum.Sum.Tables[0].DefaultView;
                //DataTable dt = dv.ToTable();


                //if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                //{
                //    if (dt.Rows[1][0].ToString().Trim() != "")
                //    {
                //        lblPoints.Text = (Convert.ToInt32(dt.Rows[0][0]) + Convert.ToInt32(dt.Rows[1][0])).ToString();
                //    }
                //    else
                //    {
                //        lblPoints.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
                //    }
                //}
                //else
                //{
                //    lblPoints.Text = "0";
                //}
                Points point = new Points();
                point.UserID = Convert.ToInt32(Session["userid"]);
                PlayerPointsViewBLL score = new PlayerPointsViewBLL();
                try
                {
                    score.Points = point;
                    score.Invoke();
                }
                catch (Exception ex)
                {
                }
                DataView dvPoints = score.Sum.Tables[0].DefaultView;
                DataTable dt = dvPoints.ToTable();
                if (dt.Rows[0]["U_Points"] != null && dt.Rows[0]["U_Points"].ToString() != "")
                {
                    Session["U_Points"] = dt.Rows[0]["U_Points"].ToString();

                }
                if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                {
                    lblPoints.Text = Session["U_Points"].ToString();
                }
                else
                {
                    lblPoints.Text = "0";
                }
            }
        }
    }
}