using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;


namespace LevelsPro.Player
{
    public partial class Welcome : AuthorizedPage
    {
        private string usr, pwd, role;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Authentication Code
                try
                {
                    usr = (string)Session["username"];
                    pwd = (string)Session["password"];
                    role = (string)Session["role"];
                    if ((usr == null) || (pwd == null))
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
                            if (!(role.Equals("Player")))
                            {
                                Response.Redirect("~/Login.aspx");
                            }
                            else
                            {
                            }
                       // }
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
                    if ((Session["role"].ToString() == null))
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
    }
}