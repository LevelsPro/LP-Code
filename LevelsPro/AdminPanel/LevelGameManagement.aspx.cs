using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class LevelGameManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (!(Page.IsPostBack))
            {
                if (Request.QueryString["game"] != null && Request.QueryString["game"].ToString() != "added")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Game has been added successfully.";
                }
                else if (Request.QueryString["game"] != null && Request.QueryString["game"].ToString() != "updated")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Game has been updated successfully.";
                }
                LoadData();
            }
        }

        protected void LoadData()
        {
            LevelGameViewBLL game = new LevelGameViewBLL();
            try
            {
                game.Invoke();

                dlLevelGame.DataSource = game.ResultSet;
                dlLevelGame.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNewRole_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelGameEdit.aspx",false);
        }

        protected void dlLevelGame_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditGame")
            {

                Response.Redirect("LevelGameEdit.aspx?gameid=" + e.CommandArgument.ToString());

            }

        }

        protected void btnNewGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("LevelGameEdit.aspx", false);
        }
    }
}