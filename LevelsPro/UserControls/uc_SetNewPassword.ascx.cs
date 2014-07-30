using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Update;

namespace LevelsPro.UserControls
{
    public partial class uc_SetNewPassword : System.Web.UI.UserControl
    {
        public static String userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // userName = Session["username"].ToString();
        }

        public void LoadData(int UserID)
        {
            Session["UserIDForgot"] = UserID;
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    //if (txtConfrmPassword.Text.Equals(txtPassword.Text))
        //    //{
        //    //    if (Session["UserIDForgot"] == null)
        //    //    {
        //    //        Session["Newpassword"] = txtPassword.Text;

        //    //        ModalPopupExtender mpesetquestion = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
        //    //        mpesetquestion.Hide();

        //    //        ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
        //    //        mpe.Show();
        //    //        uc_SecurityQuestions ucSQ = this.Parent.FindControl("ucSecurityQuestions") as uc_SecurityQuestions;//new uc_SecurityQuestions();
        //    //        ucSQ.LoadQuestions();
        //    //    }
        //    //    else
        //    //    {
        //    //        UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
        //    //        Common.User _updateuser = new Common.User();

        //    //        _updateuser.UserID = Convert.ToInt32(Session["useridForgot"]);
        //    //        _updateuser.UserPassword = txtPassword.Text.Trim();

        //    //        updateUser.User = _updateuser;

        //    //        try
        //    //        {
        //    //            updateUser.Invoke();
        //    //        }
        //    //        catch (Exception ex)
        //    //        {
        //    //            //lblMessage.Visible = true;
        //    //            //lblMessage.Text = "There is some problem occured, please try later.";
        //    //            return;
        //    //        }

        //    //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('Password has been changed successfully.')</script>", false);

        //    //        Response.Redirect("PlayerPanel/PlayerHome.aspx", false);
        //    //    }
        //    //   // Session["username"] = userName;
        //    //}
        //    //else
        //    //{
        //    //    txtConfrmPassword.Text = "";
        //    //    txtPassword.Text = "";
        //    //}
        //}

    

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtConfrmPassword.Text.Equals(txtPassword.Text))
            {
                if (Session["UserIDForgot"] == null)
                {
                    Session["Newpassword"] = txtPassword.Text;

                    ModalPopupExtender mpesetquestion = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
                    mpesetquestion.Hide();

                    ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
                    mpe.Show();
                    uc_SecurityQuestions ucSQ = this.Parent.FindControl("ucSecurityQuestions") as uc_SecurityQuestions;//new uc_SecurityQuestions();
                    ucSQ.LoadQuestions();
                }
                else
                {
                    UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                    Common.User _updateuser = new Common.User();

                    _updateuser.UserID = Convert.ToInt32(Session["useridForgot"]);
                    _updateuser.UserPassword = txtPassword.Text.Trim();

                    updateUser.User = _updateuser;

                    try
                    {
                        updateUser.Invoke();
                    }
                    catch (Exception ex)
                    {
                        //lblMessage.Visible = true;
                        //lblMessage.Text = "There is some problem occured, please try later.";
                        return;
                    }

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('Password has been changed successfully.')</script>", false);

                    Response.Redirect("PlayerPanel/PlayerHome.aspx", false);
                }
                // Session["username"] = userName;
            }
            else
            {
                txtConfrmPassword.Text = "";
                txtPassword.Text = "";
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}