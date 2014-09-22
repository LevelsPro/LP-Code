using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.Util;

namespace LevelsPro.ErrorPages
{
    public partial class DefaultErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string role= (string) Session["role"];
            role = role.ToLower();
            string userRole = (string)Session["userrole"];
            switch(role)
            {
                case "player":
                    string source = ExceptionUtility.GetRedirectionURL(Session);;
                    Response.AppendHeader("Refresh", "5;url=" + source);
                break;
            }
        }
    }
}