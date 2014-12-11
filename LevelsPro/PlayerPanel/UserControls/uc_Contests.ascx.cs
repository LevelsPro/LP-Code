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

// modified by jseas
namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_Contests : System.Web.UI.UserControl
    {
        #region init
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        #endregion

        #region attributes - constants - properties

        #region constants
        public const string PlayerHasCon = "playerHasContests";
        #endregion

        #endregion

        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        #endregion

        #region load data
        protected void LoadData()
        {
            // init controls
            Session[PlayerHasCon] = "false";
            var contest = new ContestPositionListViewBLL();
            var _contest = new Contest
                               {
                                   Where = " WHERE y.User_ID = " + Convert.ToString(Session["userid"])
                               };
            contest.ContestPositionList = _contest;
            try
            {
                contest.Invoke();
            }
            catch (Exception ex)
            {
            }

            // verify process
            if (contest.ResultSet.Tables[0] == null || contest.ResultSet.Tables[0].Rows.Count <= 0) return;

            // load data and set variables
            Session[PlayerHasCon] = "true";
            lvViewContests.DataSource = contest.ResultSet.Tables[0];
            lvViewContests.DataBind();
        }
        #endregion

        #region user interface events
        protected void lvViewContests_ItemCommand(object source, ListViewCommandEventArgs e)
        {
            int ContestID = Convert.ToInt32(e.CommandArgument);
            Session["ContestID"] = ContestID;
            Response.Redirect("ContestDetails.aspx");
        }

        protected void lvViewContests_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HiddenField lbl = (HiddenField)e.Item.FindControl("hfToDate");
            if (lbl.Value != "")
            {
                if (Convert.ToDateTime(lbl.Value) >= DateTime.Today)
                {
                    LinkButton link = (LinkButton)e.Item.FindControl("lnkbtnContestDetail");

                    link.CssClass = "level-cont-green-selected";
                }
            }
        }
        #endregion
    }
}