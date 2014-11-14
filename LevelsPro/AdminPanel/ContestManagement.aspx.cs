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
using BusinessLogic.Duplicate;

namespace LevelsPro.AdminPanel
{
    public partial class ContestManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                LoadContest();
            }
        }

        protected void LoadContest()
        {
            ContestViewBLL contestview = new ContestViewBLL();
            Contest _contest = new Contest();
            _contest.Where = "";
            contestview.Contest = _contest;
            try
            {
                contestview.Invoke();
            }
            catch (Exception ex)
            {
            }
            if (contestview.ResultSet.Tables[0] != null && contestview.ResultSet.Tables[0].Rows.Count > 0)
            {

                dlContest.DataSource = contestview.ResultSet.Tables[0];
                dlContest.DataBind();
            }

        }

        protected void dlContest_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditContest")
            {
                Response.Redirect("ContestEdit.aspx?contestid=" + e.CommandArgument.ToString());
            }
            else if (e.CommandName == "DeleteContest")
            {
                ContestDeleteBLL contestdelete = new ContestDeleteBLL();
                Contest _contest = new Contest();
                _contest.ContestID = Convert.ToInt32(e.CommandArgument);
                contestdelete.Contest = _contest;
                try
                {
                    contestdelete.Invoke();
                }
                catch (Exception ex)
                {
                }

                LoadContest();
            }
            else if (e.CommandName == "DuplicateContest")
            {
                ContestDuplicateBLL contestduplicate = new ContestDuplicateBLL();
                Contest _contest = new Contest();
                _contest.ContestID = Convert.ToInt32(e.CommandArgument);
                contestduplicate.Contest = _contest;
                try
                {
                    contestduplicate.Invoke();
                }
                catch (Exception ex)
                {
                }

                LoadContest();
            }

        }

        protected void btnNewContest_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContestEdit.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlContest_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ( e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem ) {
                Literal LT = e.Item.FindControl("ltToDate") as Literal;
                var toDate = DateTime.Parse(LT.Text.ToString());
                var nowDate = DateTime.Now;

                int result = DateTime.Compare(nowDate, toDate);

                if (result < 0) 
                {
                    ImageButton BT = e.Item.FindControl("imgDelete") as ImageButton;
                    BT.Enabled = false;
                }                
             }
        }
    }
}