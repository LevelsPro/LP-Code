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
using LevelsPro.App_Code;
using System.Configuration;
using System.IO;
using BusinessLogic.Delete;

namespace LevelsPro.AdminPanel
{
    public partial class MatchManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                LoadMatch();
            }
        }

        protected void LoadMatch()
        {
            MatchViewBLL matchview = new MatchViewBLL();
            Match _match = new Match();
            _match.Where = "";
            matchview.Match = _match;
            try
            {
                matchview.Invoke();
            }
            catch (Exception ex)
            {
            }
            if (matchview.ResultSet.Tables[0] != null && matchview.ResultSet.Tables[0].Rows.Count > 0)
            {

                dlMatch.DataSource = matchview.ResultSet.Tables[0];
                dlMatch.DataBind();
            }

        }

        protected void dlMatch_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditMatch")
            {
                Response.Redirect("MatchEdit.aspx?matchid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "DeleteMatch")
            {
                MatchDeleteBLL matchdelete = new MatchDeleteBLL();
                Match _match = new Match();
                _match.MatchID = Convert.ToInt32(e.CommandArgument);
                matchdelete.Match = _match;
                try
                {
                    matchdelete.Invoke();
                }
                catch (Exception ex)
                {
                }

                LoadMatch();
            }
            else if (e.CommandName == "ManageDataSets")
            {
                Response.Redirect("DataSetManagement.aspx?matchid=" + e.CommandArgument.ToString());
            }

        }

        protected void btnNewMatch_Click(object sender, EventArgs e)
        {
            Response.Redirect("MatchEdit.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}