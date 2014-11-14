using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Reports;
using System.Configuration;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_ContestUserProfile : System.Web.UI.UserControl
    {
        public string cssClass;
        public static DataSet dsPoints = new DataSet();  

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(string userID)
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                UserInfoByIDBLL u = new UserInfoByIDBLL();
                User _user = new User();
                _user.UserID = Convert.ToInt32(userID);
                u.User = _user;
                try
                {
                    u.Invoke();
                }
                catch (Exception ex)
                {
                }
                if (u.ResultSet.Tables[0] != null && u.ResultSet.Tables[0].Rows.Count > 0) 
                {
                    lblRoleName.Text = u.ResultSet.Tables[0].Rows[0]["RoleName"].ToString();
                    lblStore.Text = u.ResultSet.Tables[0].Rows[0]["SiteName"].ToString();
                    
                    Session["HeaderName"] = u.ResultSet.Tables[0].Rows[0]["U_FirstName"].ToString() + " " + u.ResultSet.Tables[0].Rows[0]["U_LastName"].ToString() + "'s Leaderboard";
                    Session["CurrectName"] = u.ResultSet.Tables[0].Rows[0]["U_FirstName"].ToString() + " " + u.ResultSet.Tables[0].Rows[0]["U_LastName"].ToString();
                }
              
                ContestPositionListViewBLL contest = new ContestPositionListViewBLL();
                Contest _contest = new Contest();
                _contest.Where = " WHERE y.User_ID = " + userID.ToString() + " AND y.ContestID = " + Session["ContestID"].ToString();
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
                    lblNameContest.Text = contest.ResultSet.Tables[0].Rows[0]["ContestName"].ToString();
                    lblRank1.Text = contest.ResultSet.Tables[0].Rows[0]["Position"].ToString();
                    cssClass = contest.ResultSet.Tables[0].Rows[0]["cssClass"].ToString();
                    lblStorePlace.Text = contest.ResultSet.Tables[0].Rows[0]["PositionClear"].ToString() + " Place";
                    lblCompanyPlace.Text = "18th Place";
                }

                ContestPositionViewBLL positions = new ContestPositionViewBLL();
                _contest = new Contest();
                _contest.Where = " WHERE ContestId = " + Session["ContestID"].ToString() + " LIMIT 3";
                positions.ContestPosition = _contest;
                try
                {
                    positions.Invoke();
                }
                catch (Exception ex)
                {

                }
                dsPoints = positions.ResultSet;
                DataView dvPoints = positions.ResultSet.Tables[0].DefaultView;
                if (dvPoints != null && dvPoints.ToTable().Rows.Count > 0)
                {
                    lvAwards.DataSource = dvPoints;
                    lvAwards.DataBind();
                }
                else
                {
                    lvAwards.DataSource = null;
                    lvAwards.DataBind();
                }
            }
        }

        protected void lvAwards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal lt = (Literal)e.Item.FindControl("ltNumber");
            
            lt.Text = AddOrdinal(Convert.ToInt32(lt.Text) + 1);
        }

        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }
    }
}