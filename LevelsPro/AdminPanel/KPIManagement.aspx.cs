using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using System.Data;
using System.Drawing;
using LevelsPro.App_Code;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class KPIManagement : AuthorizedPage
    {
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
        
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
               
            }
            ExceptionUtility.CheckForErrorMessage(Session);

        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData()
        {
            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dlKPI.DataSource = kpi.ResultSet;
            dlKPI.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewKPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("KPIEdit.aspx?kpiid=0");
        }

        protected void dlKPI_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditKPI")
            {

                Response.Redirect("KPIEdit.aspx?kpiid=" + e.CommandArgument.ToString());

            }
        }
    }
}