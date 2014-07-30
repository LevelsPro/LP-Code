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

namespace LevelsPro.AdminPanel
{
    public partial class QuizManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                LoadQuiz();
            }
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
                }
                catch (Exception ex)
                {
                }

                LoadQuiz();
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