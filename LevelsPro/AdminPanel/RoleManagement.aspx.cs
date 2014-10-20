using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using Common;
using System.Drawing;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;
namespace LevelsPro.AdminPanel
{

    public partial class RoleManagement : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        static  String checks = "";
        protected override void OnInit(EventArgs e)
        {
              base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            dlRole.DataSource = role.ResultSet;
            dlRole.DataBind();
        }
       

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleEdit.aspx?roleid=0");
        }

        protected void dlRole_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditRole")
            {

                Response.Redirect("RoleEdit.aspx?roleid=" + e.CommandArgument.ToString());

            }

        }
    }
}