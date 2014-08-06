﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
//using System.Web.Mail;
using BusinessLogic;
using BusinessLogic.Update;
using LevelsPro.App_Code;
using System.Net.Mail;

namespace LevelsPro
{
    public partial class ForgotPassword : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Visible = false;
            lblMeassage.Visible = false;

            DataSet dsQuestions = new DataSet();
            dsQuestions = LoadQuestionAnswers();

            if (dsQuestions != null && dsQuestions.Tables.Count > 0 && dsQuestions.Tables[0] != null && dsQuestions.Tables[0].Rows.Count > 0)
            {
                ddlQuestion1.SelectedValue = dsQuestions.Tables[0].Rows[0]["Question_ID"].ToString();
                ddlQuestion1.Enabled = false;
                ddlQuestion2.SelectedValue = dsQuestions.Tables[0].Rows[1]["Question_ID"].ToString();
                ddlQuestion2.Enabled = false;
                ddlQuestion3.SelectedValue = dsQuestions.Tables[0].Rows[2]["Question_ID"].ToString();
                ddlQuestion3.Enabled = false;
            }



            //if (!IsPostBack)
            //{
            //    if (Session["usernameForgot"] != null && Session["usernameForgot"].ToString() != "")
            //    {
            //        lblUserNameValue.Text = Session["usernameForgot"].ToString();
            //    }
            //}
        }

        private DataSet LoadQuestionAnswers()
        {
            if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
            {
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

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            UserInfoByEmailBLL user = new UserInfoByEmailBLL();

            Common.User _user = new Common.User();

            _user.UserEmail = txtEmail.Text.Trim();

            user.User = _user;

            try
            {
                user.Invoke();
            }
            catch (Exception ex)
            {
                lblMeassage.Visible = true;
                lblMeassage.Text = "There is some problem occured, please try later.";
                return;
            }

            DataSet dsUser = new DataSet();

            dsUser = user.ResultSet;

            if (dsUser != null && dsUser.Tables.Count > 0 && dsUser.Tables[0] != null && dsUser.Tables[0].Rows.Count > 0)
            {
                string strRandomPassword = System.Web.Security.Membership.GeneratePassword(8, 3);

                UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                Common.User _updateuser = new Common.User();

                _updateuser.UserID = Convert.ToInt32(dsUser.Tables[0].Rows[0]["UserID"]);
                _updateuser.UserPassword = strRandomPassword;

                updateUser.User = _updateuser;

                try
                {
                    updateUser.Invoke();
                }
                catch (Exception ex)
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "There is some problem occured, please try later.";
                    return;
                }

                string strTo = txtEmail.Text.Trim();
                string strSubject = "Forgot Password";
                string strBody = "Dear " + dsUser.Tables[0].Rows[0]["U_Name"].ToString() + "<br /><br /> Your new password is generated by the system. Please use the following password to login.<br /><br /> Password: <b>" + strRandomPassword + "</b><br /><br /> Regards<br />LevelsPro";

                int result = SendMail(strTo, strSubject, strBody);

                if (result > 0)
                {
                    btnLogin.Visible = true;
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "Email sent.";
                }
            }
            else
            {
                btnLogin.Visible = false;
                lblMeassage.Visible = true;
                lblMeassage.Text = "Email address is not correct.";
            }
        }

        //#region SendMail
        public int SendMail(string strTo, string strSubject, string strBody)
        {
            int value = 0;
            try
            {
                //System.Web.Mail.MailMessage objMailMsg = new System.Web.Mail.MailMessage();
                //objMailMsg.To = strTo;
                //objMailMsg.From = System.Configuration.ConfigurationManager.AppSettings["SMTPFROM"];
                //objMailMsg.Subject = strSubject;
                //objMailMsg.Body = strBody;

                //System.Web.Mail.SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPSERVER"];                
                //objMailMsg.BodyFormat = MailFormat.Html; 

                //System.Web.Mail.SmtpMail.Send(objMailMsg);
                //value = 1;



                MailAddress sendFrom = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["SMTPFROM"].ToString());
                MailAddress sendTo = new MailAddress(strTo);

                MailMessage obEmail = new MailMessage(sendFrom, sendTo);
                obEmail.Priority = MailPriority.High;
                //objEmail.Body = pswd;           

                obEmail.Body = strBody;
                obEmail.Subject = strSubject;
                obEmail.IsBodyHtml = true;
                SmtpClient mysmtpClient = new SmtpClient();
                mysmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPSERVER"];
                //mysmtpClient.Port = int.Parse("25");
                mysmtpClient.Send(obEmail);

                value = 1;

            }
            catch (Exception ex)
            {
                value = 0;
            }
            return value;
        }

        protected void btnSubmitAnswers_Click(object sender, EventArgs e)
        {

            DataSet dsCheck = new DataSet();

            dsCheck = LoadQuestionAnswers();


            if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
            {
                if ((dsCheck.Tables[0].Rows[0]["Answer"].ToString() == txtAnswer1.Text.Trim()) && (dsCheck.Tables[0].Rows[1]["Answer"].ToString() == txtAnswer2.Text.Trim()) && (dsCheck.Tables[0].Rows[2]["Answer"].ToString() == txtAnswer3.Text.Trim()))
                {
                    divChangePwd.Visible = true;
                }
                else
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "Answers not matched.";
                    divChangePwd.Visible = false;
                }
            }

           
        }
        //if (ddlQuestion1.SelectedValue != ddlQuestion2.SelectedValue)
        //{
        //    user.UserID = Convert.ToInt32(Session["useridForgot"]);
        //    user.QuestionID = Convert.ToInt32(ddlQuestion2.SelectedValue);
        //    user.Answer = txtAnswer2.Text.Trim();

        //    checkuser.User = user;


        //    checkuser.Invoke();

        //    if (ddlQuestion3.SelectedValue != ddlQuestion1.SelectedValue && ddlQuestion3.SelectedValue != ddlQuestion2.SelectedValue)
        //    {
        //        user.UserID = Convert.ToInt32(Session["useridForgot"]);
        //        user.QuestionID = Convert.ToInt32(ddlQuestion3.SelectedValue);
        //        user.Answer = txtAnswer3.Text.Trim();

        //        checkuser.User = user;


        //        checkuser.Invoke();

        //    }
        //}



        protected void rblChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblChoice.SelectedValue == "2")
            {
                divQuestions.Visible = true;
                LoadQuestions();
                divEmail.Visible = false;
            }
            else
            {
                divEmail.Visible = true;
                divQuestions.Visible = false;
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

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() != "")
            {
                if (Session["useridForgot"] != null && Session["useridForgot"].ToString() != "")
                {
                    UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                    Common.User _updateuser = new Common.User();

                    _updateuser.UserID = Convert.ToInt32(Session["useridForgot"]);
                    _updateuser.UserPassword = txtNewPassword.Text.Trim();

                    updateUser.User = _updateuser;

                    try
                    {
                        updateUser.Invoke();
                    }
                    catch (Exception ex)
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "There is some problem occured, please try later.";
                        return;
                    }

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('Password has been changed successfully.')</script>", false);

                    Response.Redirect("Index.aspx", false);
                }
            }
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "")
            {
                CheckUserNameBLL checkuser = new CheckUserNameBLL();
                Common.User user = new Common.User();

                user.UserName = txtUser.Text.Trim();

                checkuser.User = user;

                try
                {
                    checkuser.Invoke();
                }
                catch (Exception ex)
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "There is some problem occured, please try later.";
                    return;
                }

                DataSet dsCheck = new DataSet();

                dsCheck = checkuser.ResultSet;

                if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
                {
                    Session["useridForgot"] = dsCheck.Tables[0].Rows[0]["UserID"];
                    Session["usernameForgot"] = dsCheck.Tables[0].Rows[0]["U_Name"];
                    //Response.Redirect("ForgotPassword.aspx", false);
                    pnlForgotStep1.Visible = false;
                    pnlForgotStep2.Visible = true;
                }
                else
                {
                    lblMeassage.Visible = true;
                    lblMeassage.Text = "User Name is not correct.";
                }
            }
        }
    }
}