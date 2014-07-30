using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using BusinessLogic.Select;
using AjaxControlToolkit;

namespace LevelsPro.UserControls
{
    public partial class uc_CheckAnswers : System.Web.UI.UserControl
    {
        static int a = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    LoadData();
            //}

        }

        public void LoadData()
        {
            if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
            {
                LoadQuestions();
            }

            DataSet dsQuestions = new DataSet();
            dsQuestions = LoadQuestionAnswers();

            if (dsQuestions != null && dsQuestions.Tables.Count > 0 && dsQuestions.Tables[0] != null && dsQuestions.Tables[0].Rows.Count > 0)
            {
                ddlQuestion1.SelectedValue = dsQuestions.Tables[0].Rows[0]["Question_ID"].ToString();
                ddlQuestion1.Enabled = false;
                ddlQuestion1.Visible = true;
                ddlQuestion2.SelectedValue = dsQuestions.Tables[0].Rows[1]["Question_ID"].ToString();
                ddlQuestion2.Enabled = false;
                ddlQuestion2.Visible = true;
                ddlQuestion3.SelectedValue = dsQuestions.Tables[0].Rows[2]["Question_ID"].ToString();
                ddlQuestion3.Visible = true;
                ddlQuestion3.Enabled = false;
            }
        }
        private DataSet LoadQuestionAnswers()
        {

            if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
            {
                LoadQuestions();
                CheckSecurityAnswersBLL checkuser = new CheckSecurityAnswersBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["useridForgot"]);

                checkuser.User = user;
                DataSet dsCheck = new DataSet();
                try
                {
                    checkuser.Invoke();

                }
                catch (Exception ex)
                {

                }
                dsCheck = checkuser.ResultSet;
                return dsCheck;
                //return dsCheck;
                //
            }
            else
                return null;
        }
        protected void btnSubmitAnswers_Click(object sender, EventArgs e)
        {

            DataSet dsCheck = new DataSet();

            dsCheck = LoadQuestionAnswers();


            if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
            {
                if ((dsCheck.Tables[0].Rows[0]["Answer"].ToString() == txtAnswer1.Text.Trim()) && (dsCheck.Tables[0].Rows[1]["Answer"].ToString() == txtAnswer2.Text.Trim()) && (dsCheck.Tables[0].Rows[2]["Answer"].ToString() == txtAnswer3.Text.Trim()))
                {
                    if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
                    {
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeAnswers") as ModalPopupExtender;
                        mpe.Hide();
                        uc_SetPassword chk = this.Parent.FindControl("ucSetNewPassword") as uc_SetPassword;
                        chk.LoadData(Convert.ToInt32(Session["useridForgot"]));
                        ModalPopupExtender mpe1 = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
                        mpe1.Show();
                    }
                }
                else
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "Answers not matched.";
                    ModalPopupExtender mpe = this.Parent.FindControl("mpeAnswers") as ModalPopupExtender;
                    mpe.Show();
                    txtAnswer1.Text = "";
                    txtAnswer2.Text = "";
                    txtAnswer3.Text = "";


                    DataSet dsQuestions = new DataSet();
                    dsQuestions = LoadQuestionAnswers();

                    if (dsQuestions != null && dsQuestions.Tables.Count > 0 && dsQuestions.Tables[0] != null && dsQuestions.Tables[0].Rows.Count > 0)
                    {
                        ddlQuestion1.SelectedValue = dsQuestions.Tables[0].Rows[0]["Question_ID"].ToString();
                        ddlQuestion1.Enabled = false;
                        ddlQuestion1.Visible = true;
                        ddlQuestion2.SelectedValue = dsQuestions.Tables[0].Rows[1]["Question_ID"].ToString();
                        ddlQuestion2.Enabled = false;
                        ddlQuestion2.Visible = true;
                        ddlQuestion3.SelectedValue = dsQuestions.Tables[0].Rows[2]["Question_ID"].ToString();
                        ddlQuestion3.Visible = true;
                        ddlQuestion3.Enabled = false;
                    }
                    // divChangePwd.Visible = false;
                }
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
                lblMeassage.Visible = true;
                lblMeassage.Text = "There is some problem occured, please try later.";
                return;
            }

            ddlQuestion1.DataTextField = "Question_Text";
            ddlQuestion1.DataValueField = "Question_ID";

            ddlQuestion2.DataTextField = "Question_Text";
            ddlQuestion2.DataValueField = "Question_ID";

            ddlQuestion3.DataTextField = "Question_Text";
            ddlQuestion3.DataValueField = "Question_ID";

            if (securityquestionsbll.ResultSet != null && securityquestionsbll.ResultSet.Tables.Count > 0 && securityquestionsbll.ResultSet.Tables[0] != null && securityquestionsbll.ResultSet.Tables[0].Rows.Count > 0)
            {
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
        }
    }
}