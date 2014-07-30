using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;
using BusinessLogic.Insert;
using System.Drawing;
using BusinessLogic.Select;
using BusinessLogic.Update;
using Common;

namespace LevelsPro.AdminPanel
{
    public partial class SiteManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!IsPostBack)
            {
                
                LoadData();
            }
        }

        

       

       

        protected void LoadData()
        {
            SiteViewBLL site = new SiteViewBLL();
            try
            {
                site.Invoke();
            }
            catch (Exception ex)
            {
               
            }
           
            
            dlSite.DataSource = site.ResultSet;
            dlSite.DataBind();
        }

       

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlSite_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditSite")
            {

                Response.Redirect("SiteEdit.aspx?siteid=" + e.CommandArgument.ToString());

            }
        }

        protected void btnNewSite_Click(object sender, EventArgs e)
        {
            Response.Redirect("SiteEdit.aspx?siteid=0");
        }
    }
}