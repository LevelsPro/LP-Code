using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Update;
using AjaxControlToolkit;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;
using System.Text;


namespace LevelsPro.UserControls
{
    public partial class uc_ChangePassword : System.Web.UI.UserControl
    {
        //static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //public static string Encrypt(string originalString)
        //{

        //    var cryptoProvider = new DESCryptoServiceProvider();
        //    var memoryStream = new MemoryStream();
        //    var cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes),
        //        CryptoStreamMode.Write);
        //    var writer = new StreamWriter(cryptoStream);
        //    writer.Write(originalString);
        //    writer.Flush();
        //    cryptoStream.FlushFinalBlock();
        //    writer.Flush();
        //    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        //}

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            lblMeassage.Visible = false;   
           //  bool PasswordVerification = false; 
           //PasswordVerification= PasswordEncrypt.ValidatePassword(txtPassword.Text, Session["password"].ToString());
            ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
            if (txtOldPass.Text == Session["password"].ToString())
            {
                    MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                    scon.Open();
                    MySqlTransaction sqlTrans = scon.BeginTransaction();
                    try
                    {
                        UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                        Common.User _updateuser = new Common.User();

                        _updateuser.UserID = Convert.ToInt32(Session["userid"]);
                      //  _updateuser.UserPassword =Encrypt(txtNewPass.Text);
                        _updateuser.UserPassword = PasswordEncrypt.CreateHash(txtNewPass.Text);
                        _updateuser.sqlTransaction = sqlTrans;   
                     
                        updateUser.User = _updateuser;
                        updateUser.Invoke();
                        Session["password"] = PasswordEncrypt.CreateHash(txtNewPass.Text);
                        sqlTrans.Commit();
                    }
                    catch (Exception)
                    {
                        sqlTrans.Rollback();
                    }
                    finally
                    {                            
                            sqlTrans.Dispose();
                            scon.Close();
                    }                  
                   
                   mpe.Hide();

            }
            else
            {
                        lblMeassage.Visible = true;
                        lblMeassage.Text = "Old password is not correct.";
                        lblMeassage.ForeColor = Color.Crimson;
                        //ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
                        mpe.Show();
            }

            ////if (txtNewPass.Text != "")
            ////{
            //    if (Session["userid"] != null && Session["userid"].ToString() != "")
            //    {
            //        CheckPasswordBLL checkPwd = new CheckPasswordBLL();
            //        Common.User _checkpwd = new Common.User();

            //        _checkpwd.UserID = Convert.ToInt32(Session["userid"]);
            //        _checkpwd.UserPassword = txtOldPass.Text.Trim();

            //        checkPwd.User = _checkpwd;

            //        try
            //        {
            //            checkPwd.Invoke();
            //        }
            //        catch (Exception ex)
            //        {
                       
            //            lblMeassage.Visible = true;
            //            lblMeassage.Text = "There is some problem occured, please try later.";
            //            ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
            //            mpe.Show();
            //            return;
            //        }

            //        DataSet dsCheck = new DataSet();

            //        dsCheck = checkPwd.ResultSet;

            //        if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0] != null && dsCheck.Tables[0].Rows.Count > 0)
            //        {
            //            UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
            //            Common.User _updateuser = new Common.User();

            //            _updateuser.UserID = Convert.ToInt32(Session["userid"]);
            //            _updateuser.UserPassword = txtNewPass.Text.Trim();

            //            updateUser.User = _updateuser;

            //            try
            //            {
            //                updateUser.Invoke();
            //            }
            //            catch (Exception ex)
            //            {
            //                lblMeassage.Visible = true;
            //                lblMeassage.Text = "There is some problem occured, please try later.";
            //                ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
            //                mpe.Show();
            //                return;
            //            }

            //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('Password has been changed successfully.')</script>", false);
            //            //Session.Abandon();
            //            String role = Session["role"].ToString();
            //            role = role.ToLower();
            //            if (role.Equals("admin"))
            //            {
            //                lblMeassage.Visible = false;
            //                Response.Redirect("~/AdminPanel/AdminHome.aspx");
            //            }
            //            else if (role.Equals("manager"))
            //            {
            //                lblMeassage.Visible = false;
            //                Response.Redirect("~/ManagerPanel/TeamPerformance.aspx");
            //            }
            //            else if (role.Equals("player"))
            //            {
            //                lblMeassage.Visible = false;
            //                Response.Redirect("~/PlayerPanel/PlayerHome.aspx");
            //            }
            //            else
            //            {
            //                lblMeassage.Visible = false;
            //                Response.Redirect("~\\Login.aspx");
            //            }
            //        //}
            //        //else
            //        //{
            //        //    lblMeassage.Visible = true;
            //        //    lblMeassage.Text = "Old password is not correct.";
            //        //    ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
            //        //    mpe.Show();
            //        //}

            //    }
           // }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender mpe = this.Parent.FindControl("mpeChangePassDiv") as ModalPopupExtender;
            mpe.Hide();
            //string role = Session["role"].ToString();
            ////role = role.ToLower();
            //if (role.Equals("Admin"))
            //{
            //    lblMeassage.Visible = false;
            //    Response.Redirect("~/AdminPanel/AdminHome.aspx?" + DateTime.Now.Ticks);
            //}
            //else if (role.Equals("Manager"))
            //{
            //    lblMeassage.Visible = false;
            //    Response.Redirect("~/ManagerPanel/TeamPerformance.aspx?" + DateTime.Now.Ticks);
            //}
            //else if (role.Equals("Player"))
            //{
            //    lblMeassage.Visible = false;
            //    Response.Redirect("~/PlayerPanel/PlayerHome.aspx?" + DateTime.Now.Ticks);
            //}
            //else
            //{
            //    lblMeassage.Visible = false;
            //    Response.Redirect("~\\Login.aspx?" + DateTime.Now.Ticks);
            //}
        }
         
    }
}