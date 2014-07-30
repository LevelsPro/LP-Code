using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class LevelGameEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (!IsPostBack)
            {
                lblHeading.Text =Resources.TestSiteResources.CreateGame;
                if (Request.QueryString["gameid"] != null && Request.QueryString["gameid"].ToString() != "")
                {
                    ViewState["gameid"] = Request.QueryString["gameid"];

                    LoadData(Convert.ToInt32(ViewState["gameid"]));
                }                                               
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
          
           
                Response.Redirect("LevelGameManagement.aspx", false);
     
        }

        protected void LoadData(int GameID)
        {
            lblHeading.Text = Resources.TestSiteResources.UpdateGame;
            LevelGameViewBLL game = new LevelGameViewBLL();
            try
            {
                game.Invoke();

                if (game.ResultSet != null && game.ResultSet.Tables.Count > 0 && game.ResultSet.Tables[0] != null && game.ResultSet.Tables[0].Rows.Count > 0)
                {
                    
                    DataView dv = game.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "GameID = " + GameID.ToString();

                    DataTable dt = dv.ToTable();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        btnAddGame.Text = Resources.TestSiteResources.UpdateGame;
                        txtGameName.Text = dt.Rows[0]["GameName"].ToString();
                        if (dt.Rows[0]["GameActive"] != null && dt.Rows[0]["GameActive"].ToString() == "1")
                        {
                            cbGame.Checked = true;
                        }
                        else
                        {
                            cbGame.Checked = false;
                        }

                        LevelGameDDLViewBLL gameDDL = new LevelGameDDLViewBLL();
                        Common.LevelGame gameObj = new Common.LevelGame();
                        gameObj.GameID = GameID;


                        gameDDL.Game = gameObj;

                        try
                        {
                            gameDDL.Invoke();

                            dlLevelGameDDL.DataSource = gameDDL.ResultSet;
                            dlLevelGameDDL.DataBind();
                        }
                        catch (Exception ex)
                        { 
                        
                        }
                        
                    }
                }                
            }
            catch (Exception ex)
            {
            }
        }

        #region edit game
        protected void dlLevelGameDDL_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditGame")
            {
                btnAddValue.Text = Resources.TestSiteResources.UpdateValue;
                ViewState["gameDDLID"] = e.CommandArgument;                
                Literal ltGameName = e.Item.FindControl("ltGameName") as Literal;
                Literal ltActive = e.Item.FindControl("ltActive") as Literal;

                if (ltActive != null && ltActive.Text.Trim() == "1")
                {
                    cbGameDDL.Checked = true;
                }
                else
                {
                    cbGameDDL.Checked = false;
                }

                txtValueName.Text = ltGameName.Text;

                divValueText.Visible = true;
                divValueButton.Visible = true;
                divActiveText.Visible = true;
            }
        }
        #endregion

        #region add and update game
        protected void btnAddGame_Click(object sender, EventArgs e)
        {
            if (btnAddGame.Text == Resources.TestSiteResources.UpdateGame)
            {
                if (ViewState["gameid"] != null && ViewState["gameid"].ToString() != "")
                {
                    LevelGameUpdateBLL LevelGame = new LevelGameUpdateBLL();
                    Common.LevelGame game = new Common.LevelGame();

                    game.GameName = txtGameName.Text.Trim();
                    game.GameID = Convert.ToInt32(ViewState["gameid"]);
                    if (cbGame.Checked)
                    {
                        game.Active = 1;
                    }
                    else
                    {
                        game.Active = 0;
                    }

                    LevelGame.LevelGame = game;

                    try
                    {
                        LevelGame.Invoke();
                        Response.Redirect("LevelGameManagement.aspx?game=updated", false);
                    }
                    catch
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Cannot update game.";
                    }
                }
            }
            else
            {
                LevelGameInsertBLL LevelGame = new LevelGameInsertBLL();
                Common.LevelGame game = new Common.LevelGame();

                game.GameName = txtGameName.Text.Trim();

                LevelGame.LevelGame = game;

                try
                {
                    LevelGame.Invoke();
                    Response.Redirect("LevelGameManagement.aspx?game=added",false);
                }
                catch
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Cannot add game.";
                }
            }
        }
        #endregion
        protected void btnNewGameDDL_Click(object sender, EventArgs e)
        {
            divValueText.Visible = true;
            divValueButton.Visible = true;
            divActiveText.Visible = true;
        }

        protected void btnAddValue_Click(object sender, EventArgs e)
        {
            if (btnAddValue.Text == Resources.TestSiteResources.UpdateValue)
            {
                if (ViewState["gameDDLID"] != null && ViewState["gameDDLID"].ToString() != "" && ViewState["gameid"] != null && ViewState["gameid"].ToString() != "")
                {
                    LevelGameDDLUpdateBLL LevelGame = new LevelGameDDLUpdateBLL();
                    Common.LevelGame game = new Common.LevelGame();

                    game.GameDropDownName = txtValueName.Text.Trim();
                    game.GameID = Convert.ToInt32(ViewState["gameid"]);
                    game.GameDropDownID = Convert.ToInt32(ViewState["gameDDLID"]);
                    if (cbGameDDL.Checked)
                    {
                        game.Active = 1;
                    }
                    else
                    {
                        game.Active = 0;
                    }

                    LevelGame.LevelGame = game;

                    try
                    {
                        LevelGame.Invoke();
                        LoadData(Convert.ToInt32(ViewState["gameid"]));
                        btnAddValue.Text = Resources.TestSiteResources.AddValue;
                        txtValueName.Text = "";
                        cbGameDDL.Checked = false;
                        divValueText.Visible = false;
                        divValueButton.Visible = false;
                        divActiveText.Visible = false;
                        
                    }
                    catch
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Cannot update value.";
                    }
                }
            }
            else
            {
                if (ViewState["gameid"] != null && ViewState["gameid"].ToString() != "")
                {
                    LevelGameDDLInsertBLL LevelGame = new LevelGameDDLInsertBLL();
                    Common.LevelGame game = new Common.LevelGame();

                    game.GameDropDownName = txtValueName.Text.Trim();
                    game.GameID = Convert.ToInt32(ViewState["gameid"]);
                    LevelGame.LevelGame = game;

                    try
                    {
                        LevelGame.Invoke();
                        LoadData(Convert.ToInt32(ViewState["gameid"]));

                        txtValueName.Text = "";
                        cbGameDDL.Checked = false;

                        divValueText.Visible = false;
                        divValueButton.Visible = false;
                        divActiveText.Visible = false;
                    }
                    catch
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Cannot add value.";
                    }
                }
            }
        }
    }
}