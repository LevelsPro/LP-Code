using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class ViewContests : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Uri url = Request.Url;
            pageURL = url.AbsolutePath.ToString();
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                LoadData();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            ExceptionUtility.CheckForErrorMessage(Session);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

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
            PlayerContestViewBLL contest = new PlayerContestViewBLL();
            try
            {
                contest.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = contest.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Role_ID=8";

            dlViewContests.DataSource = dv.ToTable();
            dlViewContests.DataBind();
        }
    }
}