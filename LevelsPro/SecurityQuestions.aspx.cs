using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Insert;
using BusinessLogic.Select;
using System.Data;
using System.Drawing;

namespace LevelsPro
{
    public partial class SecurityQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSubmit.ValidationGroup = "Email";
                rfvNewPassword.ValidationGroup = "Email";
                rfvConfirmPassword.ValidationGroup = "Email";
                btnSubmit.ValidationGroup = "Email";
            }
        }

        protected void btnSubmitAnswers_Click(object sender, EventArgs e)
        {
            //if ()
            //SecurityAnswerInsertBLL securityanswers = new SecurityAnswerInsertBLL();
            //Common.User user = new Common.User();

            //user.UserID = 
        }

        protected void rblChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblChoice.SelectedValue == "2")
            {
                divQuestions.Visible = true;

                rfvNewPassword.ValidationGroup = "Question";
                rfvConfirmPassword.ValidationGroup = "Question";
                btnSubmit.ValidationGroup = "Question";
                LoadQuestions();
                divEmail.Visible = false;
                //upQuest.Update();
            }
            else
            {
                divEmail.Visible = true;
                rfvNewPassword.ValidationGroup = "Email";
                rfvConfirmPassword.ValidationGroup = "Email";
                btnSubmit.ValidationGroup = "Email";
                divQuestions.Visible = false;
                //upQuest.Update();
            }
        }
        private void LoadQuestions()
        {
            SecurityQuestionsViewBLL securityquestionsbll = new SecurityQuestionsViewBLL();
            try
            {
                securityquestionsbll.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlQuestion1.DataTextField = "Question_Text";
            ddlQuestion1.DataValueField = "Question_ID";

            ddlQuestion2.DataTextField = "Question_Text";
            ddlQuestion2.DataValueField = "Question_ID";

            ddlQuestion3.DataTextField = "Question_Text";
            ddlQuestion3.DataValueField = "Question_ID";

            DataView dv = securityquestionsbll.ResultSet.Tables[0].DefaultView;

            ddlQuestion1.DataSource = dv.ToTable();
            ddlQuestion1.DataBind();

            ddlQuestion2.DataSource = dv.ToTable();
            ddlQuestion2.DataBind();

            ddlQuestion3.DataSource = dv.ToTable();
            ddlQuestion3.DataBind();

            ListItem li = new ListItem("select question", "0");
            ddlQuestion1.Items.Insert(0, li);

            ListItem li2 = new ListItem("select question", "0");
            ddlQuestion2.Items.Insert(0, li2);

            ListItem li3 = new ListItem("select question", "0");
            ddlQuestion3.Items.Insert(0, li3);
        }

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (rblChoice.SelectedValue == "2")
            //{
            //    Page.Validate("Question");
            //}
            //else
            //{
            //    Page.Validate("Email");
            //}
            if (Session["userIDInfo"] != null)
            {
                SecurityAnswerInsertBLL securityanswers = new SecurityAnswerInsertBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["userIDInfo"]);
                user.UserPassword = txtNewPassword.Text.Trim();

                if (rblChoice.SelectedValue == "2") // Questions
                {

                    if (ddlQuestion1.SelectedValue == ddlQuestion2.SelectedValue || ddlQuestion2.SelectedValue == ddlQuestion3.SelectedValue || ddlQuestion3.SelectedValue == ddlQuestion1.SelectedValue)
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "select different questions.";
                        lblMeassage.ForeColor = Color.Crimson;
                        return;
                    }
                    try
                    {
                        user.Securitytype = 2;
                        user.QuestionID = Convert.ToInt32(ddlQuestion1.SelectedValue);
                        user.Answer = txtAnswer1.Text.Trim();
                        user.UserID = Convert.ToInt32(Session["userIDInfo"]);
                        user.UserPassword = txtNewPassword.Text.Trim();
                        securityanswers.User = user;

                        securityanswers.Invoke();

                        securityanswers = new SecurityAnswerInsertBLL();
                        user = new Common.User();
                        user.Securitytype = 2;
                        user.QuestionID = Convert.ToInt32(ddlQuestion2.SelectedValue);
                        user.Answer = txtAnswer2.Text.Trim();
                        user.UserID = Convert.ToInt32(Session["userIDInfo"]);
                        user.UserPassword = txtNewPassword.Text.Trim();
                        securityanswers.User = user;

                        securityanswers.Invoke();

                        securityanswers = new SecurityAnswerInsertBLL();
                        user = new Common.User();
                        user.Securitytype = 2;
                        user.QuestionID = Convert.ToInt32(ddlQuestion3.SelectedValue);
                        user.Answer = txtAnswer3.Text.Trim();
                        user.UserID = Convert.ToInt32(Session["userIDInfo"]);
                        user.UserPassword = txtNewPassword.Text.Trim();
                        securityanswers.User = user;

                        securityanswers.Invoke();

                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Information added successfully.";
                        Response.Redirect("Index.aspx",false);
                    }
                    catch (Exception ex)
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Cannot add information.";

                    }

                }
                else
                {
                    user.Securitytype = 1;
                    user.UserEmail = txtEmail.Text.Trim();

                    securityanswers.User = user;

                    try
                    {
                        securityanswers.Invoke();
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Information added successfully.";
                        Response.Redirect("Index.aspx",false);
                    }
                    catch (Exception ex)
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Cannot add information.";
                    }
                }
            }
        }
    }
}