using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelsPro.ErrorPages
{
    public partial class ErrorPage404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception exp = Server.GetLastError();
            string role = (string)Session["role"];
            role = role.ToLower();
            string userRole = (string)Session["userrole"];
            switch (role)
            {
                case "player":
                    string source = "../PlayerPanel/Messages.aspx";
                    Response.AppendHeader("Refresh", "5;url=" + source);
                    break;
            }
        }
    }
}