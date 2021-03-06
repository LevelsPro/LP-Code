﻿using System;
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
using log4net;
using LevelsPro.Util;
using Common.Utils;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace LevelsPro.AdminPanel
{
    public partial class APIExportSheet : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            lblMessage.Visible = false;
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                //BindGridwithDummy();
            }
            ExceptionUtility.CheckForErrorMessage(Session);
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
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
            try
            {
                DataView dvuserid = new DataView();
                userdata.Select(DataSourceSelectArguments.Empty);
                dvuserid= userdata.Select(DataSourceSelectArguments.Empty) as DataView;
                DataTable dtuserid = new DataTable();

                if (gvAPI.Rows.Count > 0)
                {
                    foreach (GridViewRow gr in gvAPI.Rows)
                    {
                        if (gr.Cells[2].Text.Equals("HoursWorked"))
                        {

                            #region Updating Hours Worked Performance

                            dvuserid.RowFilter = "U_EmpID= '" + Convert.ToString(gr.Cells[0].Text) + "'";
                            dtuserid = dvuserid.ToTable();

                            User user = new User();
                            user.Hours = Convert.ToInt32(gr.Cells[1].Text);
                            user.UserID = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);

                            HoursWorkedUpdateBLL HoursPerform = new HoursWorkedUpdateBLL();

                            try
                            {
                                HoursPerform.User = user;
                                HoursPerform.Invoke();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                            }
                            #endregion
                        }
                        else if (gr.Cells[5].Text.Equals("KPI"))
                        {
                            #region Updating Level Performance

                            dvuserid.RowFilter = "U_EmpID= '" + Convert.ToString(gr.Cells[0].Text) + "'";
                            dtuserid = dvuserid.ToTable();

                            if (dtuserid.Rows.Count == 1)
                            {

                                bool check = false;
                                UserLevelPercentBLL userlevelP = new UserLevelPercentBLL();
                                Common.User _userPercent = new Common.User();

                                // _userPercent.UserID = Convert.ToInt32(gr.Cells[0].Text);

                                _userPercent.UserID = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);

                                userlevelP.User = _userPercent;

                                try
                                {
                                    userlevelP.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }

                                if (userlevelP.ResultSet != null && userlevelP.ResultSet.Tables.Count > 0 && userlevelP.ResultSet.Tables[0] != null && userlevelP.ResultSet.Tables[0].Rows.Count > 0)
                                {

                                    DataSet dsTarget = new DataSet();
                                    String UserPoints = "0";

                                    int UserID = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);
                                    int LevelID = Convert.ToInt32(userlevelP.ResultSet.Tables[0].Rows[0]["current_level"]);

                                    TargetViewBLL Target = new TargetViewBLL();
                                    try
                                    {
                                        Target.Invoke();
                                        dsTarget = Target.ResultSet;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw ex;
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
                                                    throw ex;
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
                                                            throw ex;
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
                                                    throw ex;
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
                                                            throw ex;
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
                                        throw ex;
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
                                        throw ex;
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
                                        throw ex;
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
                                            throw ex;
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
                                                    throw ex;
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
                                                                throw ex;
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

                            }
                            #endregion
                        }
                        else if (gr.Cells[5].Text.Equals("Award"))
                        {
                            if (Convert.ToInt32(gr.Cells[6].Text.ToString()) > 0)
                            {
                                #region Updating Award Performance
                                DataSet dsTarget = new DataSet();

                                dvuserid.RowFilter = "U_EmpID= '" + Convert.ToString(gr.Cells[0].Text) + "'";
                                dtuserid = dvuserid.ToTable();

                                Common.User _userPercent = new Common.User();
                                _userPercent.UserID = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);
                                int userid = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);
                                int awardid = Convert.ToInt32(gr.Cells[6].Text);
                                _userPercent.AwardID = Convert.ToInt32(gr.Cells[6].Text);
                                TargetViewBLL Target = new TargetViewBLL();
                                try
                                {
                                    Target.Invoke();
                                    dsTarget = Target.ResultSet;
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
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
                                    throw ex;
                                }

                                #endregion
                            }
                        }
                        else if (gr.Cells[5].Text.Equals("Contest"))
                        {
                            #region Updating Contest Performance

                            #region Getting Contest ID
                            getContestIDBLL CID = new getContestIDBLL();
                            KPI kpi = new KPI();
                            kpi.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                            CID.KPI = kpi;
                            try
                            {
                                CID.Invoke();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                            }

                            DataTable dtCID = new DataTable();
                            if (CID.ResultSet != null)
                            {
                                dtCID = CID.ResultSet.Tables[0];
                            }
                            #endregion

                            #region Running Insert Procedure for all the Contest ID being found
                            for (int i = 0; i < dtCID.Rows.Count; i++)
                            {
                                dvuserid.RowFilter = "U_EmpID= '" + Convert.ToString(gr.Cells[0].Text) + "'";
                                dtuserid = dvuserid.ToTable();

                                Contest contest = new Contest();
                                contest.ContestID = Convert.ToInt32(dtCID.Rows[i][0].ToString());
                                contest.UserID = Convert.ToInt32(dtuserid.Rows[0]["UserID"]);
                                contest.KPIID = Convert.ToInt32(gr.Cells[2].Text);
                                contest.Points = Convert.ToInt32(gr.Cells[3].Text);
                                contest.EntryDate = Convert.ToString(gr.Cells[1].Text);

                                ContestPerformanceInsertBLL contestPerform = new ContestPerformanceInsertBLL();

                                try
                                {
                                    contestPerform.Contest = contest;
                                    contestPerform.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                finally
                                {
                                }

                            }
                            #endregion


                            #endregion
                        }
                    }


                }
                lblErrorMessages.Text = "Final";
                gvAPI.DataSource = null;
                gvAPI.DataBind();
            }
            catch (Exception exc)
            {
                lblErrorMessages.Text = exc.Message;
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
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
            string fileName = "";
            string FullName = "";
            string[] a = new string[1];
            DataTable dt = null;

            try
            {
                #region Import SpreadSheet
                if (fuImport.FileName.Length > 0)
                {
                    a = fuImport.FileName.Split('.');
                    fileName = Convert.ToString(System.DateTime.Now.Ticks) + "." + a.GetValue(1).ToString();
                    FilePath = Server.MapPath(@"~\APIExcelSheet");
                    FileResources resource = FileResources.Instance;
                    resource.preparePath(FilePath);
                    fuImport.SaveAs(FilePath + @"\" + fileName);
                    FullName = FilePath + @"\" + fileName;

                    // Load DataTable using OfficeOpenXml.
                    dt = SpreadsheetReader.loadDataTable(FullName);
                }
                #endregion

                #region Populate Award ID
                int counterType = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][5].ToString().ToLower().Equals("award"))
                    {
                        counterType++;
                    }
                }

                if (counterType > 0)
                {
                    dt.Columns.Add("AwardID", typeof(System.Int32));
                    for (int rowsIndex = 0; rowsIndex < dt.Rows.Count; rowsIndex++)
                    {
                        if (dt.Rows[rowsIndex][2] != DBNull.Value)
                        {
                            #region Getting Award ID
                            getContestIDBLL CID = new getContestIDBLL();
                            KPI kpi = new KPI();
                            kpi.KPIID = Convert.ToInt32(dt.Rows[rowsIndex][2].ToString());
                            CID.KPI = kpi;
                            try
                            {
                                CID.Invoke();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                            }

                            DataTable dtCID = new DataTable();
                            if (CID.ResultSet != null)
                            {
                                dtCID = CID.ResultSet.Tables[1];
                            }

                            for (int x = 0; x < dtCID.Rows.Count; x++)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    int dtCol = 0;
                                    int dtCIDCol = 0;

                                    if (dt.Rows[j][2] != DBNull.Value && dtCID.Rows[x][1] != DBNull.Value)
                                    {
                                        if (Int32.TryParse(Convert.ToString(dt.Rows[j][2]), out dtCol) && Int32.TryParse(Convert.ToString(dtCID.Rows[x][1]), out dtCIDCol))
                                        {

                                            if (dtCol == dtCIDCol)
                                            {
                                                int outInt = 0;
                                                if (Int32.TryParse(dtCID.Rows[x][0].ToString(), out outInt))
                                                {
                                                    dt.Rows[j]["AwardID"] = outInt;
                                                }
                                            }
                                            else
                                            {
                                                dt.Rows[j]["AwardID"] = 0;
                                            }
                                        }
                                    }

                                }
                            }
                            #endregion
                        }
                        else
                        {
                            dt.Rows.RemoveAt(rowsIndex);
                        }
                    }
                }
                #endregion
            }
            catch (Exception exc)
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
            }

            gvAPI.DataSource = dt;
            gvAPI.DataBind();
        }
        #endregion
    }
}