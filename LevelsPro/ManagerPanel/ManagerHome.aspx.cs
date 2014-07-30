using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;

using System.Reflection;
using BusinessLogic.Reports;
using Common;

using BusinessLogic.Select;

namespace LevelsPro.ManagerPanel
{
    public partial class ManagerHome : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}