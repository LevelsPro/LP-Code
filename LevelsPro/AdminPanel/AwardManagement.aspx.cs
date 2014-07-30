using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using System.IO;
using System.Drawing;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class AwardManagement : AuthorizedPage
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(Page.IsPostBack))
            {
                LoadData();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        

        protected void LoadData()
        {
            AwardViewBLL award = new AwardViewBLL();
            try
            {
                award.Invoke();
            }
            catch (Exception ex)
            {
            }

            

            DataView dv = award.ResultSet.Tables[0].DefaultView;
            dlAward.DataSource = dv;
            dlAward.DataBind();
        }

        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlAward_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName =="EditAward")
            {

                Response.Redirect("AwardEdit.aspx?awardid=" +e.CommandArgument.ToString());
            
            }
        }

        protected void btnNewAward_Click(object sender, EventArgs e)
        {
            Response.Redirect("AwardEdit.aspx?awardid=0");
        }
    }
}

        
