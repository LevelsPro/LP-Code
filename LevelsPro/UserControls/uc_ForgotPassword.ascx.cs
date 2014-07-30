using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Data;
using BusinessLogic.Select;
using System.Drawing;
using BusinessLogic.Update;
using Common;
using BusinessLogic.Insert;

namespace LevelsPro.UserControls
{
    public partial class uc_ForgotPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Visible = false;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender mpe = this.Parent.FindControl("mpeForgot") as ModalPopupExtender;
            mpe.Hide();
            lblmessage.Text = "";
            lblmessage.Visible = false;
           
        }

        protected void btnSecurity_Click(object sender, EventArgs e)
        {

          //  if (txtUserName.Text.Trim() != "")
           // {
                //CheckUserNameBLL checkuser = new CheckUserNameBLL();
                //Common.User user = new Common.User();

                //user.UserName = txtUserName.Text.Trim();

                //checkuser.User = user;

                //try
                //{
                //    checkuser.Invoke();
                //}
                //catch (Exception ex)
                //{
                //    lblMeassage.Visible = true;
                //    lblMeassage.Text = "There is some problem occured, please try later.";
                //    return;
                //}

                ModalPopupExtender mpe = this.Parent.FindControl("mpeForgot") as ModalPopupExtender;
                DataSet dsCheck = new DataSet();
                App_Code.AuthorizedPage cls = new App_Code.AuthorizedPage();
                dsCheck = cls.UserData(txtUserName.Text.Trim());

                if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
                {
                    Session["useridForgot"] = dsCheck.Tables[0].Rows[0]["UserID"];
                   // Session["usernameForgot"] = dsCheck.Tables[0].Rows[0]["U_Name"];

                    //Session["userid"] = dsCheck.Tables[0].Rows[0]["UserID"];
                    //Session["username"] = dsCheck.Tables[0].Rows[0]["U_Name"];                    
                    mpe.Hide();


                   // uc_CheckAnswers chk = this.Parent.FindControl("ucCheckAnswers") as uc_CheckAnswers;
                   // chk.LoadData();
                    //ModalPopupExtender mpe1 = this.Parent.FindControl("mpeAnswers") as ModalPopupExtender;
                    //mpe1.Show();
                    ModalPopupExtender mpeSQ = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
                    mpeSQ.Show();
                    uc_SecurityQuestions ucSQ = this.Parent.FindControl("ucSecurityQuestions") as uc_SecurityQuestions;//new uc_SecurityQuestions();
                    ucSQ.LoadQuestions();
                }
                else
                {              

                    lblMeassage.Visible = true;
                    lblMeassage.Text = "User Name is not correct.";
                    lblMeassage.ForeColor = Color.Crimson;
                    mpe.Show();
                  

                }
           //}


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() != null || txtUserName.Text.Trim() != "")
            {
                DataSet dsCheck = new DataSet();
                App_Code.AuthorizedPage cls = new App_Code.AuthorizedPage();
                dsCheck = cls.UserData(txtUserName.Text.Trim());

                if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
                {
                    Session["useridForgot"] = dsCheck.Tables[0].Rows[0]["UserID"];


                    PasswordResetUpdateBLL _reset = new PasswordResetUpdateBLL();
                    User _user = new User();
                    _user.UserName = txtUserName.Text.Trim();
                    _reset.User = _user;
                    try
                    {
                        _reset.Invoke();

                    }
                    catch (Exception ex)
                    {

                    }

                    UserViewBLL _adminusers = new UserViewBLL();
                    Common.User adminuser = new Common.User();

                    adminuser.Where = "where U_SysRole = 'Admin'";
                    _adminusers.User = adminuser;

                    try
                    {
                        _adminusers.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                 

                    MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
                    Common.Messages _message = new Common.Messages();

                    foreach (DataRow dr in _adminusers.ResultSet.Tables[0].Rows)
                    {
                        _message.FromUserID =Convert.ToInt32(Session["useridForgot"]);
                        _message.ToUserID = Convert.ToInt32(dr["UserID"]);
                        _message.MessageSubject = "Reset Password";

                        String Message = txtUserName.Text + " has reset their password at " + System.DateTime.Now.ToString();

                        _message.MessageText = Message;
                        try
                        {
                            _messageInsert.messages = _message;
                            _messageInsert.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }

                    }
                    lblmessage.Visible = true;
                    ModalPopupExtender mpe = this.Parent.FindControl("mpeForgot") as ModalPopupExtender;
                    mpe.Show();
                    Session["UserCheck"] = Session["useridForgot"].ToString();
                    Session["useridForgot"] = null;
                }
            }
        }
    }
}