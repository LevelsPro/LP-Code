using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using DataAccess;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using Common;
using System.Drawing;
using LevelsPro.App_Code;
namespace LevelsPro.AdminPanel
{

    public partial class RoleManagement : AuthorizedPage
    {
      static  String checks = "";
      protected override void OnInit(EventArgs e)
      {
          base.OnInit(e);

      }
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
            if (!(Page.IsPostBack))
            {
               
                LoadData();
               
            }
           

        }
        protected void LoadData()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
               
            }
            
            dlRole.DataSource = role.ResultSet;
            dlRole.DataBind();
        }
       

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleEdit.aspx?roleid=0");
        }

        protected void dlRole_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditRole")
            {

                Response.Redirect("RoleEdit.aspx?roleid=" + e.CommandArgument.ToString());

            }

        }
    }
}