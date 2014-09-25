using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LevelsPro.App_Code;
using BusinessLogic.Select;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using LevelsPro.PlayerPanel;
using DataAccess;
using log4net;
using LevelsPro.Util;
namespace LevelsPro
{
    public partial class Login : AuthorizedPage
    {
        // Comments for GitHUb
       // static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        private static readonly ILog log = LogManager.GetLogger(
  System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            ExceptionUtility.CheckForLoginErrorMessage();
            if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            {
                if (Session["MyUICulture"].ToString() == "en-US")
                {
                    ddlLanguage.SelectedIndex = 0;
                }
                else if ((Session["MyUICulture"].ToString() == "fr-FR"))
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                else 
                {
                    ddlLanguage.SelectedIndex = 2;
                }
            }
            if (ddlLanguage.SelectedIndex==0)
            {
                SetCulture("en-US", "en-US");
            }
            else if (ddlLanguage.SelectedIndex == 1)
            {
                SetCulture("fr-FR", "fr-FR");
            }
            else 
            {
                SetCulture("es-ES", "es-ES");
            }

            lblError.Visible = false;

        

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }       

   



        protected void btnSignin_Click(object sender, EventArgs e)
        {
            try
            {
            string user, pwd, Sysrole;
            user = txtUser.Text.Trim();
            pwd = txtPassword.Text;
         

            DataSet ds = new DataSet();

           
                
                ds = UserData(user);
           

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "Invalid user name or password.";
                txtPassword.Focus();
                return;
                
            }
            Session["language"] = ddlLanguage.SelectedItem.Text;
            Session["userid"] = ds.Tables[0].Rows[0]["UserID"];
            Session["username"] = user;
            

            if (ds.Tables[0].Rows[0]["U_Password"].ToString().Equals(""))
            {
                Session["password"] = null;
                mpeSetNewPassword.Show();
            }
            bool PasswordVerification = false; 
            if (!ds.Tables[0].Rows[0]["U_Password"].ToString().Equals(""))
                {
                   // Session["password"] = txtPassword.Text;
                    PasswordVerification = PasswordEncrypt.ValidatePassword(txtPassword.Text, ds.Tables[0].Rows[0]["U_Password"].ToString());
                }
             if (PasswordVerification == true)
            {
                Sysrole = ds.Tables[0].Rows[0]["U_SysRole"].ToString();
                if(Sysrole.Equals("Player"))
                {
                    Session["FirstTimeLogin"] = 0; //check to not run sp to get info two times
                    Session["UserCurrentLevel"] = Convert.ToInt32(ds.Tables[0].Rows[0]["current_level"].ToString());
                    Session["LevelPosition"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Level_Position"].ToString());
                    Session["PlayerLevelImage"] = ds.Tables[0].Rows[0]["ImageName"].ToString();
                    Session["AllLevelsPlayer"] = ds.Tables[1];

                    //ReuseableItems.PlayerPoints_PlayerPanel = Convert.ToInt32(ds.Tables[0].Rows[0]["U_Points"].ToString());
                    //ReuseableItems.PlayerCurrentLevelID_PlayerPanel = Convert.ToInt32(ds.Tables[0].Rows[0]["current_level"].ToString());
                    //ReuseableItems.PlayerCurrentLevelPosition_PlayerPanel = Convert.ToInt32(ds.Tables[0].Rows[0]["Level_Position"].ToString());
                    //ReuseableItems.PlayerLevelImage = ds.Tables[0].Rows[0]["ImageName"].ToString();
                    //ReuseableItems.AllLevelsPlayer = ds.Tables[1];

                }
                Session["userrole"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                Session["rolename"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                Session["TipsLinkage"] ="false";
               // Session["Role_ID"] = ds.Tables[0].Rows[0]["Role_ID"];
                Session["UserRoleID"] = ds.Tables[0].Rows[0]["U_RolesID"];
                Session["role"] = Sysrole;
                Session["checkforlogout"] = 0;

                if (ds.Tables[0].Rows[0]["Display_Name"].ToString() == "1")
                {
                    Session["displayname"] = ds.Tables[0].Rows[0]["U_FirstName"].ToString() + ' ' + ds.Tables[0].Rows[0]["U_LastName"].ToString();
                }
                else
                {
                    Session["displayname"] = ds.Tables[0].Rows[0]["U_NickName"].ToString();
                }

                Session["siteid"] = ds.Tables[0].Rows[0]["U_SiteID"];
                Session["sitename"] = ds.Tables[0].Rows[0]["SiteName"].ToString();

                
                Session["U_Points"] = ds.Tables[0].Rows[0]["U_Points"];
                //Session["username"] = user;                
                Session["password"] = pwd;

                if (ds.Tables[0].Rows[0]["ManagerEmail"] != null)
                {
                    Session["ManagerEmail"] = ds.Tables[0].Rows[0]["ManagerEmail"];
                }
                if (ds.Tables[0].Rows[0]["ManagerID"] != null)
                {
                    Session["ManagerID"] = ds.Tables[0].Rows[0]["ManagerID"];
                }
                
                if (Sysrole.Equals("Admin"))
                {
                    Response.Redirect("~/AdminPanel/AdminHome.aspx?" + DateTime.Now.Ticks);
                }
                else if (Sysrole.Equals("Manager"))
                {
                    Response.Redirect("~/ManagerPanel/TeamPerformance.aspx?" + DateTime.Now.Ticks);
                }
                else if (Sysrole.Equals("Player"))
                {
                    Response.Redirect("~/PlayerPanel/PlayerHome.aspx?" + DateTime.Now.Ticks,false);
                }
                else
                {
                    Response.Redirect("~\\Login.aspx?" + DateTime.Now.Ticks);
                }            
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Invalid user name or password.";
                txtPassword.Focus();
                return;
            }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("Login error of User"+ Session["username"].ToString()+" :" + ex.Message);
                }
            }
        }

        protected void btnForgetPass_Click(object sender, EventArgs e)
        {
            mpeForgot.Show();            
        }
    }
}