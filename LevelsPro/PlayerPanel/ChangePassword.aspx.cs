using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Update;
using LevelsPro.App_Code;

namespace LevelsPro.PlayerPanel
{
    public partial class ChangePassword : AuthorizedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMeassage.Visible = false;
            //if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            //{
            //    if (Session["MyUICulture"].ToString() == "en-US")
            //    {
            //        ddlLanguage.SelectedIndex = 0;
            //    }
            //    else
            //    {
            //        ddlLanguage.SelectedIndex = 1;
            //    }
            //}
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() != "")
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    CheckPasswordBLL checkPwd = new CheckPasswordBLL();
                    Common.User _checkpwd = new Common.User();

                    _checkpwd.UserID = Convert.ToInt32(Session["userid"]);
                    _checkpwd.UserPassword = txtOldPassword.Text.Trim();

                    checkPwd.User = _checkpwd;

                    try
                    {
                        checkPwd.Invoke();
                    }
                    catch (Exception ex)
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "There is some problem occured, please try later.";
                        return;
                    }

                    DataSet dsCheck = new DataSet();

                    dsCheck = checkPwd.ResultSet;

                    if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
                    {
                        UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                        Common.User _updateuser = new Common.User();

                        _updateuser.UserID = Convert.ToInt32(Session["userid"]);
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
                        //Session.Abandon();
                        Response.Redirect("~/PlayerPanel/PlayerHome.aspx", false);
                    }
                    else
                    {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Old password is not correct.";
                    }

                }
            }
        }
    }
}