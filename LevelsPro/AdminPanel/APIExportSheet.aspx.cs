using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic.Insert;
using System.Data.OleDb;
using LevelsPro.App_Code;
using BusinessLogic.Update;
using BusinessLogic.Select;
using Common;

namespace LevelsPro.AdminPanel
{
    public partial class APIExportSheet : AuthorizedPage
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
                //BindGridwithDummy();
            }
        }

        private void BindGridwithDummy()
        {
            DataTable dt = new DataTable();
            //Employee ID
            dt.Columns.Add(new System.Data.DataColumn("UserID", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("KPIID", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Score", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Measure", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("DateTime", typeof(String)));

            dt.Rows.Add("26", "19", "150", "cum", "08/30/2013");
            dt.Rows.Add("23", "14", "70", "cum", "08/30/2013");
            dt.Rows.Add("94", "10", "106", "cum", "08/30/2013");

       

            gvAPI.DataSource = dt;
            gvAPI.DataBind();

        }
        #region  send record to score table
        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (gvAPI.Rows.Count > 0)
            {
                foreach (GridViewRow gr in gvAPI.Rows)
                {
                    if (gr.Cells[5].Text.Equals("KPI"))
                    {
                        #region Updating Level Performance
                    bool check = false;
                    UserLevelPercentBLL userlevelP = new UserLevelPercentBLL();
                    Common.User _userPercent = new Common.User();

                    _userPercent.UserID = Convert.ToInt32(gr.Cells[0].Text);

                    userlevelP.User = _userPercent;

                    try
                    {
                        userlevelP.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                    if (userlevelP.ResultSet != null && userlevelP.ResultSet.Tables.Count > 0 && userlevelP.ResultSet.Tables[0] != null && userlevelP.ResultSet.Tables[0].Rows.Count > 0)
                    {

                        DataSet dsTarget = new DataSet();
                        String UserPoints = "0";

                        int UserID = Convert.ToInt32(gr.Cells[0].Text);
                        int LevelID = Convert.ToInt32(userlevelP.ResultSet.Tables[0].Rows[0]["current_level"]);

                        TargetViewBLL Target = new TargetViewBLL();
                        try
                        {
                            Target.Invoke();
                            dsTarget = Target.ResultSet;
                        }
                        catch (Exception ex)
                        {
                        }

                        DataView dvTarget = dsTarget.Tables[0].DefaultView;
                        dvTarget.RowFilter = "Level_ID = " + LevelID;

                        DataTable dtTarget = dvTarget.ToTable();

                        ScoreInsertAutoBLL score = new ScoreInsertAutoBLL();
                        Common.User user = new Common.User();

                        user.UserID = UserID;
                        user.CurrentLevel = LevelID;


                        String KPIText = gr.Cells[2].Text;
                        int KPIScore = Convert.ToInt32(gr.Cells[3].Text);
                        KPIText = KPIText.Trim();

                        for (int i = 0; i < dtTarget.Rows.Count; i++)
                        {
                            String TargetText = dtTarget.Rows[i]["KPI_ID"].ToString();
                            TargetText = TargetText.Trim();

                            if (KPIText.Equals(TargetText))
                            {
                                int TargetValue = Convert.ToInt32(dtTarget.Rows[i]["Target_Value"].ToString());

                                if (KPIScore < TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = Convert.ToInt32(gr.Cells[3].Text);
                                    check = true;
                                    break;

                                }
                                else if (KPIScore == TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = Convert.ToInt32(gr.Cells[3].Text);

                                    #region KPI Score Acheived
                                    PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                                    targetprogress.User = user;

                                    try
                                    {
                                        targetprogress.Invoke();
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    DataView dv = targetprogress.ResultSet.Tables[0].DefaultView;
                                    dv.RowFilter = "KPI_ID = " + Convert.ToInt32(gr.Cells[2].Text);
                                    DataTable dT = new DataTable();
                                    dT = dv.ToTable();

                                    if (dT != null && dT.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in dT.Rows)
                                        {


                                            UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                                            //Common.User user_targetpoints = new Common.User();

                                            //user_targetpoints.UserID = Convert.ToInt32(Session["userid"]);
                                            user.TargetID = Convert.ToInt32(dr["Target_ID"]);

                                            popup.User = user;
                                            try
                                            {
                                                popup.Invoke();
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                            if (UserPoints != null && UserPoints != "")
                                            {
                                                UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                            }
                                            else
                                            {
                                                UserPoints = dr["Points"].ToString();
                                            }

                                        }

                                    }
                                    #endregion

                                    check = true;
                                    break;
                                }
                                else if (KPIScore > TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = TargetValue;

                                    #region KPI Score Acheived
                                    PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                                    targetprogress.User = user;

                                    try
                                    {
                                        targetprogress.Invoke();
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    DataView dv = targetprogress.ResultSet.Tables[0].DefaultView;
                                    dv.RowFilter = "KPI_ID = " + Convert.ToInt32(gr.Cells[2].Text);
                                    DataTable dT = new DataTable();
                                    dT = dv.ToTable();

                                    if (dT != null && dT.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in dT.Rows)
                                        {


                                            UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                                            //Common.User user_targetpoints = new Common.User();

                                            //user_targetpoints.UserID = Convert.ToInt32(Session["userid"]);
                                            user.TargetID = Convert.ToInt32(dr["Target_ID"]);

                                            popup.User = user;
                                            try
                                            {
                                                popup.Invoke();
                                            }
                                            catch (Exception ex)
                                            {
                                            }

                                            if (UserPoints != null && UserPoints != "")
                                            {
                                                UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                            }
                                            else
                                            {
                                                UserPoints = dr["Points"].ToString();
                                            }

                                        }

                                    }
                                    #endregion

                                    check = true;
                                    break;
                                }
                            }
                        }

                        if (check == false)
                        {
                            user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                            user.Score = Convert.ToInt32(gr.Cells[3].Text);
                            user.CurrentLevel = 0;
                        }

                        user.EntryDate = Convert.ToDateTime(gr.Cells[1].Text);
                        user.Measure = gr.Cells[4].Text;

                        score.User = user;

                        try
                        {
                            score.Invoke();
                        }
                        catch (Exception ex)
                        {

                        }


                        #region Level Changing Logic

                        #region Get Points
                        Points point = new Points();
                        point.UserID = UserID;
                        PlayerPointsViewBLL scorePoints = new PlayerPointsViewBLL();
                        try
                        {
                            scorePoints.Points = point;
                            scorePoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }
                        DataView dvPoints = scorePoints.Sum.Tables[0].DefaultView;
                        DataTable dt = dvPoints.ToTable();

                        if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["U_Points"] != null && dt.Rows[0]["U_Points"].ToString() != "")
                        {
                            UserPoints = dt.Rows[0]["U_Points"].ToString();

                        }
                        #endregion



                        UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
                        userlevel.User = user;
                        try
                        {
                            userlevel.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }

                        if (userlevel.ResultSet != null && userlevel.ResultSet.Tables.Count > 0 && userlevel.ResultSet.Tables[0] != null && userlevel.ResultSet.Tables[0].Rows.Count > 0)
                        {
                            TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();
                            progress.User = user;
                            try
                            {
                                progress.Invoke();
                            }
                            catch (Exception ex)
                            {
                            }

                            if (progress.ResultSet != null && progress.ResultSet.Tables.Count > 0 && progress.ResultSet.Tables[0] != null && progress.ResultSet.Tables[0].Rows.Count > 0)
                            {
                                decimal percentage = 0;
                                decimal totalPercentage = 0;
                                foreach (DataRow dr in progress.ResultSet.Tables[0].Rows)
                                {
                                    percentage += Convert.ToDecimal(dr["current_percentage"]);
                                }

                                totalPercentage = percentage / progress.ResultSet.Tables[0].Rows.Count;

                                if (totalPercentage >= 100)
                                {
                                    PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                                    targetprogress.User = user;

                                    try
                                    {
                                        targetprogress.Invoke();
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                    if (targetprogress.ResultSet != null && targetprogress.ResultSet.Tables.Count > 0 && targetprogress.ResultSet.Tables[0] != null && targetprogress.ResultSet.Tables[0].Rows.Count > 0)
                                    {
                                        foreach (DataRow dr in targetprogress.ResultSet.Tables[0].Rows)
                                        {
                                            if (Convert.ToDecimal(dr["current_percentage"]) >= 100 && dr["achieved"].ToString() == "")
                                            {

                                                UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                                                //Common.User user_targetpoints = new Common.User();

                                                //user_targetpoints.UserID = Convert.ToInt32(Session["userid"]);
                                                user.TargetID = Convert.ToInt32(dr["Target_ID"]);

                                                popup.User = user;
                                                try
                                                {
                                                    popup.Invoke();
                                                }
                                                catch (Exception ex)
                                                {
                                                }

                                                //if (UserPoints != null && UserPoints != "")
                                                //{
                                                //    UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                                //}
                                                //else
                                                //{
                                                //    UserPoints = dr["Points"].ToString();
                                                //}

                                            }
                                        }
                                    }



                                    if (userlevel.ResultSet.Tables[0].Rows[0]["popup_showed"].ToString() == "0")
                                    {
                                        //done logic

                                        PopupShowedUpdateBLL popup = new PopupShowedUpdateBLL();
                                        popup.User = user;
                                        lblMessage.Visible = true;
                                        try
                                        {
                                            popup.Invoke();
                                            lblMessage.Text = "Data imported successfully.";
                                        }
                                        catch (Exception ex)
                                        {
                                            lblMessage.Text = "Cannot import data.";
                                        }

                                        //if (UserPoints != null && UserPoints != "")
                                        //{
                                        //    UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString())).ToString();
                                        //}
                                        //else
                                        //{
                                        //    UserPoints = userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString();
                                        //}

                                        //
                                    }
                                }
                            }
                        }
                        #endregion

                    }


                        #endregion
                    }
                    else if (gr.Cells[5].Text.Equals("Award"))
                    {
                        #region Updating Award Performance
                        DataSet dsTarget = new DataSet();
                        Common.User _userPercent = new Common.User();
                        _userPercent.UserID = Convert.ToInt32(gr.Cells[0].Text);
                        int userid = Convert.ToInt32(gr.Cells[0].Text);
                        int awardid=Convert.ToInt32(gr.Cells[6].Text);
                        _userPercent.AwardID = Convert.ToInt32(gr.Cells[6].Text);
                        TargetViewBLL Target = new TargetViewBLL();
                        try
                        {
                            Target.Invoke();
                            dsTarget = Target.ResultSet;
                        }
                        catch (Exception ex)
                        {
                        }

                        DataView dvTarget = dsTarget.Tables[1].DefaultView;
                        dvTarget.RowFilter = "Award_ID = " + awardid;

                        DataTable dtTarget = dvTarget.ToTable();
                        AwardScoreInsertBLL score = new AwardScoreInsertBLL();
                        Common.User user = new Common.User();

                        user.UserID = userid;

                        String KPIText = gr.Cells[2].Text;
                        int KPIScore = Convert.ToInt32(gr.Cells[3].Text);
                        KPIText = KPIText.Trim();

                        
                        for (int i = 0; i < dtTarget.Rows.Count; i++)
                        {
                            int TargetText = Convert.ToInt32(dtTarget.Rows[i]["Award_ID"].ToString());
                            //TargetText = TargetText.Trim();

                            if (awardid == TargetText)
                            {
                                int TargetValue = Convert.ToInt32(dtTarget.Rows[i]["Target_Value"].ToString());

                                if (KPIScore < TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = Convert.ToInt32(gr.Cells[3].Text);
                                    user.AwardID = awardid;
                                    break;

                                }
                                else if (KPIScore == TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = Convert.ToInt32(gr.Cells[3].Text);
                                    user.AwardID = awardid;
                                    break;
                                }
                                else if (KPIScore > TargetValue)
                                {
                                    user.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                    user.Score = TargetValue;
                                    user.AwardID = awardid;
                                    break;
                                }
                            }
                            
                        }

                        user.Measure = gr.Cells[4].Text;
                        score.User = user;

                        try
                        {
                            score.Invoke();
                        }
                        catch (Exception ex)
                        {

                        }

                        #endregion
                    }
                    else if (gr.Cells[5].Text.Equals("Contest"))
                    {
                        #region Updating Contest Performance

                        Contest contest = new Contest();
                        contest.ContestID = Int32.Parse(gr.Cells[5].ToString());
                        contest.UserID = Int32.Parse(gr.Cells[0].ToString());
                        contest.KPIID = Int32.Parse(gr.Cells[2].ToString());
                        contest.Points = Int32.Parse(gr.Cells[3].ToString());
                        contest.ImportDate = System.DateTime.Now.Date;

                        ContestPerformanceInsertBLL contestPerform = new ContestPerformanceInsertBLL();
                        
                        try
                        {
                            contestPerform.Contest = contest;
                            contestPerform.Invoke();
                        }
                        catch (Exception ex)
                        {
                            // Catching and Logging Exception Here...
                        }
                        finally
                        {
                        }
                        #endregion
                    }
                }


            }

        
        }
        #endregion
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        #region import to grid from excel
        protected void btnImpToGrid_Click(object sender, EventArgs e)
        {
            string FilePath = "";
            string[] a = new string[1];
            string fileName = "";
            string FullName = "";

            DataTable dt = null;
            DataSet ds = null;
            if (fuImport.FileName.Length > 0)
            {
                a = fuImport.FileName.Split('.');
                fileName = Convert.ToString(System.DateTime.Now.Ticks) + "." + a.GetValue(1).ToString();
                FilePath = Server.MapPath(@"~\APIExcelSheet");
                fuImport.SaveAs(FilePath + @"\" + fileName);

                FullName = FilePath + @"\" + fileName;

                // Database Saved Code
                string connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=yes'", FullName);
                string sql = "SELECT * from [Sheet1$]";
                dt = new DataTable();



                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                            //return dt;
                        }
                    }
                }





            }
            gvAPI.DataSource = dt;
            gvAPI.DataBind();
        }
        #endregion
    }
}