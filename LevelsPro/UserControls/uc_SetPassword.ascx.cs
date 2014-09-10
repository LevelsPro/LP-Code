using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Update;
using AjaxControlToolkit;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Drawing;
using BusinessLogic.Delete;
using Common;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace LevelsPro.UserControls
{
    public partial class uc_SetPassword : System.Web.UI.UserControl
    {
      //  static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //public void LoadData(int UserID)
        //{
        //    Session["UserIDForgot"] = UserID;
        //}       
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

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            ModalPopupExtender mpeSetNewPass = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
            if (txtConfrmPassword.Text.Equals(txtPassword.Text))
            {
                lblMeassage.Visible = false;
                if (Session["useridForgot"] == null)
                {
                    //Session["Newpassword"] = txtPassword.Text;
                    Session["password"] = PasswordEncrypt.CreateHash(txtPassword.Text);
                    mpeSetNewPass.Hide();

                    Quiz _quiz = new Quiz();
                    SecurityAnswersDeleteBLL _answers = new SecurityAnswersDeleteBLL();
                    if (Session["UserCheck"] != null)
                    {
                        _quiz.UserID = Convert.ToInt32(Session["UserCheck"]);
                        _answers.Quiz = _quiz;
                        try 
                        {

                            _answers.Invoke();

                        }
                        catch (Exception ex)
                        {
                        
                        }

                    }



                    ModalPopupExtender mpe = this.Parent.FindControl("mpeSecurityQuestionsDiv") as ModalPopupExtender;
                    mpe.Show();
                    uc_SecurityQuestions ucSQ = this.Parent.FindControl("ucSecurityQuestions") as uc_SecurityQuestions;//new uc_SecurityQuestions();
                    ucSQ.LoadQuestions();
                }
                else
                {   
                    MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                    scon.Open();
                    MySqlTransaction sqlTrans = scon.BeginTransaction();
                    try
                    {
                        UpdatePasswordBLL updateUser = new UpdatePasswordBLL();
                        Common.User _updateuser = new Common.User();

                        _updateuser.UserID = Convert.ToInt32(Session["useridForgot"]);
                        _updateuser.UserPassword = PasswordEncrypt.CreateHash(txtPassword.Text);
                        _updateuser.sqlTransaction = sqlTrans;   
                     
                        updateUser.User = _updateuser;

                        //try
                       // {
                            updateUser.Invoke();
                        //}
                            sqlTrans.Commit();
                    }
                    catch (Exception)
                    {
                        sqlTrans.Rollback();
                        //lblMessage.Visible = true;
                        //lblMessage.Text = "There is some problem occured, please try later.";
                        //  return;
                    }
                    finally
                    {
                            Session["useridForgot"] = null;
                            sqlTrans.Dispose();
                            scon.Close();
                    }
                  
                    mpeSetNewPass.Hide();
                   // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('Password has been changed successfully.')</script>", false);

                   // Response.Redirect("PlayerPanel/PlayerHome.aspx", false);
                }
                // Session["username"] = userName;
            }
            else
            {
                txtConfrmPassword.Text = "";
                txtPassword.Text = "";
                lblMeassage.Visible = true;
                lblMeassage.ForeColor = Color.Crimson;
                //ModalPopupExtender mpeSetNewPass = this.Parent.FindControl("mpeSetNewPassword") as ModalPopupExtender;
                mpeSetNewPass.Show();  

                
            }
        }
    }
}