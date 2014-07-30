using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;

namespace LevelsPro.ManagerPanel
{
    public partial class SwapRole : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSwapRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayerPanel/PlayerHome.aspx");
        }
    }
}