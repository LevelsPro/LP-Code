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
using System.IO;
using LevelsPro.App_Code;
using System.Configuration;

namespace LevelsPro.AdminPanel
{
    public partial class RewardManagement : AuthorizedPage
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
            RewardViewBLL reward = new RewardViewBLL();
            
            try
            {
                reward.Invoke();
            }
            catch (Exception ex)
            {

            }
            
            DataView dv = reward.ResultSet.Tables[0].DefaultView;
            

            

            dlReward.DataSource = dv;
            dlReward.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlReward_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditReward")
            {
                Response.Redirect("RewardEdit.aspx?rewardid=" + e.CommandArgument.ToString());
            }
        }

        protected void btnNewReward_Click(object sender, EventArgs e)
        {
            Response.Redirect("RewardEdit.aspx?rewardid=0");
        }

       


       

    }
}