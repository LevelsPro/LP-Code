using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using System.Data;
using AjaxControlToolkit;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_AwardDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadData(int awardid)
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                PlayerAwardViewBLL award = new PlayerAwardViewBLL();
                Points points = new Points();

                points.UserID = Convert.ToInt32(Session["userid"]);

                award.Points = points;

                try
                {
                    award.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = award.ResultSet.Tables[0].DefaultView;
                dv.RowFilter = "Award_ID=" + awardid;
                DataTable dt = new DataTable();
                dt = dv.ToTable();              
                
                //dt.Rows.Cast<System.Data.DataRow>().Take(6);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblheading.Text = dt.Rows[0]["Award_Name"].ToString();
                    pdesc.InnerText = dt.Rows[0]["Award_Desc"].ToString();
                    //dlViewAwards.DataSource = award.ResultSet.Tables[0];
                    //dlViewAwards.DataBind();
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardDetails") as ModalPopupExtender;
            mpe.Hide();           
            Response.Redirect(Request.Url.ToString());
        }
    }
}