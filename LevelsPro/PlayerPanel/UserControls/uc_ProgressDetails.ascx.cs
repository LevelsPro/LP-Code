using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using AjaxControlToolkit;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_ProgressDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                hpl.Visible = true;
           
        }

        public void LoadTargetDescription(int targetid)
        {
            Session["targetid"]=targetid;
            TargetDesciptionViewBLL desc = new TargetDesciptionViewBLL();
           
            try
            {               
                desc.Invoke();
            }

            catch (Exception ex)
            {
            }

            DataView dv = desc.ResultSet.Tables[0].DefaultView;
            dv.RowFilter = "Target_ID=" + targetid;           
            DataTable dt = dv.ToTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                lblheading.Text = dt.Rows[0]["KPIName"].ToString();
                //pdesc.InnerText = dt.Rows[0]["KPIDesc"].ToString();
                string descs = dt.Rows[0]["KPIDesc"].ToString();
                String TipsDESC = dt.Rows[0]["TipsDesc"].ToString();
                String TipsLink = dt.Rows[0]["TipsLink"].ToString();

                if (TipsDESC != null && TipsDESC != "" && TipsLink != null && TipsLink != "")
                {
                    hpl.Text = TipsDESC;
                    hpl.NavigateUrl = TipsLink;
                }
                else
                {
                    hpl.Visible = false;
                }
                /*
                string[] arg = new string[2];
                arg = descs.Split('^');
                if (!arg.Equals(""))
                {
                    pdesc.InnerText = arg[0];
                    try
                    {
                        hpl.Text = arg[1];
                        hpl.NavigateUrl = hpl.Text;
                    }
                    catch (Exception ex)
                    {
                        hpl.Text = "Click";
                        hpl.NavigateUrl="http://www.levelspro.com/";
                        pdesc.InnerText = descs;

                    }
                }
                */
              
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {            
            ModalPopupExtender mpe = this.Parent.FindControl("mpeViewProgressDetailsDiv") as ModalPopupExtender;
            mpe.Hide();
            //((ProgressDetails)this.Parent.Page).LoadData();
            //((UpdatePanel)this.Parent.FindControl("upViewProgressDetails")).Update();
            //Response.Redirect("ProgressDetails.aspx",false);
        }

                   
    }
}