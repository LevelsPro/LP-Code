using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class LevelGameManagement : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                if (Request.QueryString["game"] != null && Request.QueryString["game"].ToString() != "added")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Game has been added successfully.";
                }
                else if (Request.QueryString["game"] != null && Request.QueryString["game"].ToString() != "updated")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Game has been updated successfully.";
                }
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
            LevelGameViewBLL game = new LevelGameViewBLL();
            try
            {
                game.Invoke();

                dlLevelGame.DataSource = game.ResultSet;
                dlLevelGame.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelGameEdit.aspx",false);
        }

        protected void dlLevelGame_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditGame")
            {

                Response.Redirect("LevelGameEdit.aspx?gameid=" + e.CommandArgument.ToString());

            }

        }

        protected void btnNewGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelGameEdit.aspx", false);
        }
    }
}