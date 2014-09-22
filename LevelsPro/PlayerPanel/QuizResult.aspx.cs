using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Update;
using System.Web.UI.HtmlControls;
using BusinessLogic.Select;
using System.Data;
using LevelsPro.App_Code;
using Common;
using LevelsPro.Util;

namespace LevelsPro.PlayerPanel
{
    public partial class QuizResult : AuthorizedPage
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
               if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() != "")
                {
                    ViewState["quizid"] = Request.QueryString["check"].ToString();
                }
                
               
                LoadData();
                
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
            ltlName.Text = Session["displayname"].ToString() + Resources.TestSiteResources.QuizResults;
            Common.Quiz _quiz = new Quiz();
            _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            _quiz.LevelID = Convert.ToInt32(Session["CurLevel"]);

            PlayerQuizViewBLL Quiz_Selection = new PlayerQuizViewBLL();
            try
            {
                Quiz_Selection.Quiz = _quiz;
                Quiz_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = Quiz_Selection.ResultSet.Tables[2].DefaultView;
            dv.RowFilter = "UserID = " + Convert.ToInt32(Session["userid"]) +" AND QuizID= " + Convert.ToInt32(ViewState["quizid"]);
            DataTable dtQuiz = dv.ToTable();
            lblTotal.Text = "0";
            for (int i = 0; i < dtQuiz.Rows.Count; i++)
            {
                lblTotal.Text = (Convert.ToInt32(lblTotal.Text) + Convert.ToInt32(dtQuiz.Rows[i]["PointsAchieved"])).ToString();
            
            }

            dlResult.DataSource = dtQuiz;
            dlResult.DataBind();
        }
        protected void btnHome_Click(object sender, System.EventArgs e)
        {
            if ((Session["TipsLinkage"] != null || Session["TipsLinkage"] != "") && Session["TipsLinkage"].Equals("true"))
            {
                string jScript = "<script>window.close();</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
            }
            else
            {
                Response.Redirect("PlayerHome.aspx");
            }
        }

        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            if ((Session["TipsLinkage"] != null || Session["TipsLinkage"] != "") && Session["TipsLinkage"].Equals("true"))
            {
                string jScript = "<script>window.close();</script>";
                  ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
            }
            else
            {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
            }
        }

        protected void dlResult_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblCorrect = e.Item.FindControl("lblCorrect") as Label;
            if (lblCorrect.Text.ToLower() == "1")
            {
                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("clstrip");
                span.Attributes["class"] = "qr-item qr-green";

            }
            else
            {
                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("clstrip");
                span.Attributes["class"] = "qr-item qr-red";
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            if (Session["TipsLinkage"] != null && Session["TipsLinkage"].Equals("true"))
            {
                string jScript = "<script>window.close();</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
            }
            else
            {
                Response.Redirect("QuizSelection.aspx");
            }
        }
    }
}