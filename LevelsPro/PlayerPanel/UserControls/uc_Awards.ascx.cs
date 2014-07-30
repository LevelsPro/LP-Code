using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using System.Configuration;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_Awards : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            string path = ConfigurationSettings.AppSettings["AwardsPath"].ToString();
            string Thumbpath = ConfigurationSettings.AppSettings["AwardsThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
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

                }

                if (auto.ResultSet != null && auto.ResultSet.Tables.Count > 0 && auto.ResultSet.Tables[0] != null && auto.ResultSet.Tables[0].Rows.Count > 0)
                {
                    DataView dv = auto.ResultSet.Tables[0].DefaultView;
                    dv.RowFilter = "Percentage >= 100 OR Award_Manual = 'True' ";//AchievedAward = 'yes'
                    DataTable dt = new DataTable();
                    dt = dv.ToTable();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //DataTable dtNew = dt.Rows.Cast<System.Data.DataRow>().Take(6);
                        DataTable dtTop = dt.Rows.Cast<DataRow>().Take(8).CopyToDataTable();
                        //dt.Rows.AsEnumerable().Take(6);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dlViewAwards.DataSource = dtTop;
                            dlViewAwards.DataBind();
                        }
                    }
                }
            }
        }

        //protected void dlViewAwards_ItemCommand(object source, DataListCommandEventArgs e)
        //{

        //}
    }
}