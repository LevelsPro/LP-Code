using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using LevelsPro.App_Code;

namespace LevelsPro.PlayerPanel
{
    public partial class ViewContests : AuthorizedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void LoadData()
        {
            PlayerContestViewBLL contest = new PlayerContestViewBLL();
            try
            {
                contest.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = contest.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Role_ID=8";

            dlViewContests.DataSource = dv.ToTable();
            dlViewContests.DataBind();
        }
    }
}