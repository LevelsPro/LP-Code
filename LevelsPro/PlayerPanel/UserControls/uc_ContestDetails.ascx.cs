using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;
using BusinessLogic.Select;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_ContestDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Load_ContestDetails(int ContestID)
        {

            DataSet ds = new DataSet();
            Contest _contest = new Contest();
            PlayerContestViewDetailBLL contest = new PlayerContestViewDetailBLL();
            _contest.ContestID = ContestID;
            contest.Contest= _contest;
            contest.Invoke();
            ds = contest.ResultSet;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblContestName.InnerText = ds.Tables[0].Rows[0]["Contest_Name"].ToString();
                lblContestDescription.InnerText = ds.Tables[0].Rows[0]["Contest_Dur"].ToString();
            }

        }
    }
}