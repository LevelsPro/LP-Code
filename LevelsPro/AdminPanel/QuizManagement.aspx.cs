using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using System.Configuration;
using System.IO;
using BusinessLogic.Delete;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class QuizManagement : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!(Page.IsPostBack))
            {
                try
                {
                    System.Uri url = Request.Url;
                    pageURL = url.AbsolutePath.ToString();
                    LoadQuiz();
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
        protected void LoadQuiz()
        {
            QuizViewBLL quizview = new QuizViewBLL();
            Quiz _quiz = new Quiz();
            _quiz.Where = "";
            quizview.Quiz = _quiz;
            try
            {
                quizview.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (quizview.ResultSet.Tables[0] != null && quizview.ResultSet.Tables[0].Rows.Count > 0)
            {

                dlQuiz.DataSource = quizview.ResultSet.Tables[0];
                dlQuiz.DataBind();
            }

        }

        protected void dlQuiz_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditQuiz")
            {
                Response.Redirect("QuizEdit.aspx?quizid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "DeleteQuiz")
            {
                QuizDeleteBLL quizdelete = new QuizDeleteBLL();
                Quiz _quiz = new Quiz();
                _quiz.QuizID = Convert.ToInt32(e.CommandArgument);
                quizdelete.Quiz = _quiz;
                try
                {
                    quizdelete.Invoke();
                    LoadQuiz();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

               
            }
            else if (e.CommandName == "ManageQuestions")
            {
                Response.Redirect("QuestionManagement.aspx?quizid=" + e.CommandArgument.ToString());
            }

        }

        protected void btnNewQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizEdit.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}