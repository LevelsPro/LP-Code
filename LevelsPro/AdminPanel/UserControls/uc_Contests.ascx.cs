using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;

namespace LevelsPro.AdminPanel.UserControls
{
    public partial class uc_Contests : System.Web.UI.UserControl
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
            ContestPositionListViewBLL contest = new ContestPositionListViewBLL();
            Contest _contest = new Contest();
            _contest.Where = " WHERE y.User_ID = " + Session["userid"].ToString();
            contest.ContestPositionList = _contest;
            try
            {
                contest.Invoke();
            }
            catch (Exception ex)
            {
            }
            if (contest.ResultSet.Tables[0] != null && contest.ResultSet.Tables[0].Rows.Count > 0)
            {

                lvViewContests.DataSource = contest.ResultSet.Tables[0];
                lvViewContests.DataBind();
            }
        }

        protected void lvViewContests_ItemCommand(object source, ListViewCommandEventArgs e)
        {
            int ContestID = Convert.ToInt32(e.CommandArgument);
            Session["ContestID"] = ContestID;
            Response.Redirect("ContestDetails.aspx");
        }

        protected void dlViewContests_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //DataSet dsPointsTable = new DataSet();
            /*Contest _contestid = new Contest();
            ContestPlayersScoreBLL contestplayerscore = new ContestPlayersScoreBLL();
            Label lblcontid = (Label)e.Item.FindControl("lblcontestid");
            _contestid.ContestID = Convert.ToInt32(lblcontid.Text);
            contestplayerscore.Contest = _contestid;
            contestplayerscore.Invoke();
             DataView dv =  contestplayerscore.ResultSet.Tables[0].DefaultView;
            dv.RowFilter = "user_id="+Convert.ToInt32(Session["userid"]);
             DataTable dt = dv.ToTable();
             if (dt != null && dt.Rows.Count > 0)
            {
                Label lbl = (Label)e.Item.FindControl("lblRank");
                lbl.Text = dt.Rows[0]["contest_rank"].ToString();

            }*/
        }
    }
}