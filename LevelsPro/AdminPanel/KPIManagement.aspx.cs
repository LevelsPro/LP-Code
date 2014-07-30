using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using System.Data;
using System.Drawing;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class KPIManagement : AuthorizedPage
    {
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
            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
            }
            dlKPI.DataSource = kpi.ResultSet;
            dlKPI.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewKPI_Click(object sender, EventArgs e)
        {
            Response.Redirect("KPIEdit.aspx?kpiid=0");
        }

        protected void dlKPI_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditKPI")
            {

                Response.Redirect("KPIEdit.aspx?kpiid=" + e.CommandArgument.ToString());

            }
        }
    }
}