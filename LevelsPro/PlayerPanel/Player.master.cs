using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LevelsPro.PlayerPanel
{
    public partial class Player : System.Web.UI.MasterPage
    {
        private string usr, role;
        protected void Page_Load(object sender, EventArgs e)
        {
            //usr = (string)Session["username"];
            //role = (string)Session["role"];           
            if (!(IsPostBack))
            {
                #region Authentication Code
                try
                {
                    usr = (string)Session["username"];
                    role = (string)Session["role"]; 

                    if (usr == null) 
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                    else
                    {
                        //if (!(Authorization(Roles(role), role)))
                        //{
                        //    //ClientScript.RegisterStartupScript(typeof(Page), "warning", "<script>alert('Invalid UserName/Password')</script>");                            
                        //}
                        //else
                        //{


                            if (!(role.Equals("Player")) || (role.Equals("Manager")))
                            {
                                Response.Redirect("~/Login.aspx");
                            }
                            else
                            {

                            }
                        //}
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
                }
                #endregion
            }
            else
            {
                try
                {
                    if ((Session["username"].ToString() == null))
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }      
        }


        #region Commented Code
        //[System.Web.Services.WebMethod]
        //public static void AbandonSession()
        //{
        //    HttpContext.Current.Session.Abandon();
        //}

        //protected void lnkbtnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //}
        #endregion


        public int SessionLengthMinutes
        {
            get { return Session.Timeout; }
        }
        public string SessionExpireDestinationUrl
        {
            get { return "../Index.aspx"; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.PageHead.Controls.Add(new LiteralControl(
                String.Format("<meta http-equiv='refresh' content='{0};url={1}'>",
                SessionLengthMinutes * 180, SessionExpireDestinationUrl)));
        }
    }
}