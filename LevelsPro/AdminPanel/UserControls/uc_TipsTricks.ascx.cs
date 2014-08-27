using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Reflection;

namespace LevelsPro.AdminPanel.UserControls
{
    public partial class uc_TipsTricks : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        public void LoadData()
        {
            if ((Session["TipsDESC"].ToString() != null || Session["TipsDESC"].ToString() != "")
                && (Session["TipsLINK"].ToString() != null || Session["TipsLINK"].ToString() != ""))
            {
                txtReferal.Text = Session["TipsDESC"].ToString();
                txtLink.Text = Session["TipsLINK"].ToString();
            }
            else
            {
                txtReferal.Text = "";
                txtLink.Text = "";
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Session["TipsDESC"] = txtReferal.Text;
            Session["TipsLINK"] = txtLink.Text;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["TipsDESC"] = txtReferal.Text;
            Session["TipsLINK"] = txtLink.Text;
        }
    }
}