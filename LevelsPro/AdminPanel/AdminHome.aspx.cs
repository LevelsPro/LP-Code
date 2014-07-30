using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class AdminHome : AuthorizedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();            
            Response.Redirect("~/Index.aspx");
        }

        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected void lkbChang_Click(object sender, EventArgs e)
        {
            mpeChangePassDiv.Show();
        }
    }
}