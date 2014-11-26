using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using System.Web.UI.HtmlControls;

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
            
        }
    }
}