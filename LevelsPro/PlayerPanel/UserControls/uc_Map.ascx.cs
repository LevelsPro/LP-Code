using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using System.Configuration;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_Map : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  LoadMap();
            }
        }

        private void LoadMap()
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            MapViewBLL map = new MapViewBLL();
            LevelPerformanceViewBLL level = new LevelPerformanceViewBLL();
            try
            {
                map.Invoke();
                level.Invoke();
            }

            catch (Exception ex)
            {
            }

            DataView dv = map.ResultSet.Tables[0].DefaultView;
            DataView dvlevel = level.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Role_ID=" + Convert.ToInt32(Session["UserRoleID"]);
            dvlevel.RowFilter = "user_id=" + Convert.ToInt32(Session["userid"]);

            DataTable dt = dv.ToTable();
            DataTable dtlevel = dvlevel.ToTable();
            int currentlevel = 0;
            string nextlevel = "";
            string previouslevelname = "";

            if (dtlevel != null && dtlevel.Rows.Count > 0)
            {
                previouslevelname = dtlevel.Rows[0]["currentlevel"].ToString();
                currentlevel = Convert.ToInt32(dtlevel.Rows[0]["current_level"]);
                nextlevel = dtlevel.Rows[0]["nextlevel"].ToString();
            }

            string strMap = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i + 1 < currentlevel)
                    {
                        strMap += "<div class='orange-cir mcr' id='div" + i.ToString() + "'  style='top:" + dt.Rows[i]["Dimension_top"] + "%; left:" + dt.Rows[i]["Dimension_left"] + "%;'>" + dt.Rows[i]["Level_Position"] + "</div>";
                    }
                    else if (i + 1 == currentlevel)
                    {
                        strMap += "<div class='orange-cir mcr' id='div" + i.ToString() + "'  style='top:" + dt.Rows[i]["Dimension_top"] + "%; left:" + dt.Rows[i]["Dimension_left"] + "%;'>" + dt.Rows[i]["Level_Position"] + "</div>";
                        UserImageViewBLL userimage = new UserImageViewBLL();

                        Common.UserImage image = new Common.UserImage();

                        image.UserID = Convert.ToInt32(Session["userid"]);


                        userimage.UserImages = image;

                        try
                        {
                            userimage.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }
                        DataView dvImage = userimage.ResultSet.Tables[0].DefaultView;

                        dvImage.RowFilter = "U_Current=1";

                        DataTable dtImage = dvImage.ToTable();

                        if (dtImage.Rows.Count > 0 && dtImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                        {
                            strMap += "<div class='pic-holder' id='div" + i.ToString() + "'  style='top:" + (Convert.ToInt32(dt.Rows[i]["Dimension_top"]) - 22) + "%; left:" + (Convert.ToInt32(dt.Rows[i]["Dimension_left"]) - 3) + "%;'><img src='" + Thumbpath +  dtImage.Rows[0]["Player_Thumbnail"].ToString() + "' /></div>";
                        }
                        else
                        {
                            strMap += "<div class='pic-holder' id='div" + i.ToString() + "'  style='top:" + (Convert.ToInt32(dt.Rows[i]["Dimension_top"]) - 22) + "%; left:" + (Convert.ToInt32(dt.Rows[i]["Dimension_left"]) - 3) + "%;'><img src='Images/imagesNo.jpeg' /></div>";
                        }
                    }
                    else
                    {
                        strMap += "<div class='blue-cir mcr' id='div" + i.ToString() + "'  style='top:" + dt.Rows[i]["Dimension_top"] + "%; left:" + dt.Rows[i]["Dimension_left"] + "%;'>" + dt.Rows[i]["Level_Position"] + "</div>";
                    }
                }

                strMap += "<div class='title' id='titlediv'>" + Resources.TestSiteResources.HeadingTo + ' ' + nextlevel + "</div>";
            }

            ltMap.Text = strMap;
        }
    }
}