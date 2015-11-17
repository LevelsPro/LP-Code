using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using System.Timers;
using System.Drawing;
using System.Configuration;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using BusinessLogic.Delete;
using LevelsPro.App_Code;
using System.Web.Services;
using System.Xml;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class MatchPlay : AuthorizedPage
    {
        static int counter = 0;
        
        static int check = 0;
        static int DataSetLimit = 0;
        
        public static int[] RandomArray;
        
        static DataTable dt_DataSets;
        static DataTable dt = new DataTable();
        public DataView dvLog;
        public DataSet dtLog;
        public DataTable dt_New;
        public DataView dv_New;
        public DataTable dtMatch;
       
        public Random a = new Random(System.DateTime.Now.Ticks.GetHashCode());
        public List<int> randomList = new List<int>();
        public static int MyNumber = 0;
        public bool MatchPlayLogEntry = false;
        public static int NumberofDataSets;
                
        private static int CurrenLevel;
        
        private static int TotalPlayerScore;
        private Common.User user = new Common.User();
        private static Common.Match _generalMatch = new Match();
        
        public string ids = "";
        public string cssClassW34 = "";

        private bool RoundResult = false;
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                #region Current Match
                MatchViewBLL getmatch = new MatchViewBLL();
                Match _gmatch = new Match();
                _gmatch.Where = " WHERE MatchID = " + Convert.ToInt32(Request.QueryString["matchid"]);
                getmatch.Match = _gmatch;
                try
                {
                    getmatch.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataView dvMatch = getmatch.ResultSet.Tables[0].DefaultView;
                dtMatch = new DataTable();
                dtMatch = dvMatch.ToTable();
                ViewState["NoOfDataSet"] = Convert.ToInt32(dtMatch.Rows[0]["NoOfDataSet"]);
                ViewState["MaxPlaysPerDay"] = Convert.ToInt32(dtMatch.Rows[0]["MaxPlaysPerDay"]);
                ViewState["PointsForCompletation"] = Convert.ToInt32(dtMatch.Rows[0]["PointsForCompletation"]);
                lblPointsForCompletation.Text = dtMatch.Rows[0]["PointsForCompletation"].ToString();
                ViewState["NoOfRounds"] = Convert.ToInt32(dtMatch.Rows[0]["NoOfRounds"]);
                lblNoOfRounds.Text = dtMatch.Rows[0]["NoOfRounds"].ToString();
                #endregion

                PlayerMatchViewBLL Match_Selection = new PlayerMatchViewBLL();

                GetMatchPlayLogBLL Log = new GetMatchPlayLogBLL();
                Log.Invoke();
                dtLog = Log.ResultSet;
                dvLog = dtLog.Tables[0].DefaultView;

                try
                {
                    Match_Selection.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataView dv = Match_Selection.ResultSet.Tables[0].DefaultView;

                dv_New = Match_Selection.ResultSet.Tables[3].DefaultView;
                dt_New = Match_Selection.ResultSet.Tables[1];
                dt = dv.ToTable();

                dt.Columns.Add("MatchTime", typeof(DateTime));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt_New.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["MatchID"].ToString().Equals(dt_New.Rows[j]["MatchID"].ToString()))
                        {
                            dt.Rows[i]["MatchTime"] = dt_New.Rows[j]["MatchTime"];
                            break;
                        }
                    }
                }

                // dv.RowFilter = "Distinct QuizID"; // = " + Convert.ToInt32(Session["userid"])
                dtMatch = dv_New.ToTable();

                DataView dvSelect = dt.DefaultView;
                DataView dvTimeCheck = dt_New.DefaultView;


                dvTimeCheck.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Session["userid"].ToString();
                dvSelect.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Session["userid"].ToString();

                //DataView dv_SelectionCheck = dt.DefaultView;
                //dv_SelectionCheck.RowFilter = "UserID = " + Session["userid"].ToString();

                //   dt_New = dv_New.ToTable();

                DataRow[] drTimeCheck = dvTimeCheck.ToTable().Select();

                DataRow[] drs = dvSelect.ToTable().Select("MatchPoints = max(MatchPoints)");                

                DataView dvSelectTop = dt.DefaultView;

                dvSelectTop.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]);

                DataRow[] drsTop = dvSelectTop.ToTable().Select("MatchPoints = max(MatchPoints)");

                var canPlay = true;

                if (dvTimeCheck.ToTable().Rows.Count > 0)
                {
                    foreach (DataRow dr in dvTimeCheck.ToTable().Rows)
                    {
                        DateTime Date = Convert.ToDateTime(dr["MatchTime"].ToString());
                        String DateString = Date.ToShortDateString();

                        dvLog.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Convert.ToInt32(Session["userid"]); //+ " AND QuizTime = " + DateString


                        DataTable dtPlayLog = dvLog.ToTable();
                        int Playcount = 0;
                        for (int i = 0; i < dtPlayLog.Rows.Count; i++)
                        {
                            if (dtPlayLog.Rows[i]["MatchTime"].ToString().Equals(DateString))
                            {
                                Playcount = Playcount + 1;
                            }
                        }

                        if (DateString.Equals(System.DateTime.Now.ToShortDateString()))
                        {
                            if (Playcount >= Convert.ToInt32(ViewState["MaxPlaysPerDay"]))
                            {
                                ltDone.Visible = true;
                                canPlay = false;
                            }
                            else
                            {
                                canPlay = true;
                            }
                        }
                    }
                }

                if (canPlay) 
                {
                    // dtScore = new DataTable();
                    counter = 1;
                    dt = new DataTable();
                    dt_DataSets = new DataTable();
                    ltScore.Text = "0";
                    try
                    {
                        LoadData(counter);
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                    lblTimeDataSet.Text = ViewState["TimePerRound"].ToString();
                    ltScore.Text = ViewState["PointsPerRound"].ToString();

                    CurrenLevel = 0;

                    TotalPlayerScore = 0;

                    ltlDataSetNumber.Text = "Round # " + ViewState["CurrentRound"].ToString() + " of " + ViewState["NoOfRounds"].ToString() + " - " + ViewState["RoundName"].ToString(); // need to look into this

                    MatchScoreDeleteBLL matchscore = new MatchScoreDeleteBLL();
                    Match _match = new Match();
                    _match.UserID = Convert.ToInt32(Session["userid"]);
                    matchscore.Match = _match;
                    try
                    {
                        matchscore.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }
        
        protected void LoadData( int CurrentRound)
        {
            GetRelatedKPI();

            #region User Level
            UserViewBLL levelid = new UserViewBLL();
            User us = new User();
            us.Where = "Where UserID =" + Convert.ToInt32(Session["userid"]);
            levelid.User = us;
            try
            {
                levelid.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DataView dv1 = levelid.ResultSet.Tables[0].DefaultView;
            DataTable dt1 = new DataTable();
            dt1 = dv1.ToTable();
            if (dt1.Rows[0] != null)
            {
                ViewState["CurrenLevel"] = Convert.ToInt32(dt1.Rows[0]["LevelID"]);
            }
            else{
                ViewState["CurrenLevel"] = Convert.ToInt32(dt1.Rows[0]["LevelID"]);
            }
            
            #endregion            

            #region Current Round
            RoundViewBLL getround = new RoundViewBLL();
            Match _round = new Match();            
            _round.Where = " WHERE MatchID = " + Convert.ToInt32(Request.QueryString["matchid"]) + " LIMIT " + (CurrentRound - 1).ToString() +", 1;";            
            
            getround.Match = _round;
            try
            {
                getround.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dvRound = getround.ResultSet.Tables[0].DefaultView;
            DataTable dtRound = new DataTable();
            dtRound = dvRound.ToTable();
            ViewState["CurrentRound"] = Convert.ToInt32(dtRound.Rows[0]["RoundNumber"]);
            lblCurrentRound.Text = dtRound.Rows[0]["RoundNumber"].ToString();

            ViewState["RoundName"] = dtRound.Rows[0]["RoundName"];
            ViewState["TimePerRound"] = Convert.ToInt32(dtRound.Rows[0]["TimePerRound"]);
            ViewState["PointsPerRound"] = Convert.ToInt32(dtRound.Rows[0]["PointsPerRound"]);
            ViewState["ShowHint"] = Convert.ToInt32(dtRound.Rows[0]["ShowHint"]) == 1 ? true : false;
            lblHint.Text = Convert.ToInt32(dtRound.Rows[0]["ShowHint"]) == 1 ? "true" : "false";
            #endregion

            #region Get DataSets
            Match _match = new Match();
            _match.LevelID = Convert.ToInt32(dt1.Rows[0]["LevelID"]);

            if (Request.QueryString["matchid"] != null && Request.QueryString["matchid"].ToString() != "")
            {
                _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            }
            _match.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            _match.NoRound = CurrentRound - 1;
            _match.NoDataSetPerRound = Convert.ToInt32(dtRound.Rows[0]["NoOfDataSets"]);
            _match.NoOfDataSet = Convert.ToInt32(ViewState["NoOfDataSet"]);
            lblNoDataElements.Text = ViewState["NoOfDataSet"].ToString();

            PlayerMatchDataSetsViewBLL match = new PlayerMatchDataSetsViewBLL();
            match.Match = _match;
            try
            {
                match.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DataView dv = match.ResultSet.Tables[0].DefaultView;
            DataView dvMatchPoints = match.ResultSet.Tables[1].DefaultView;
            dv.RowFilter = "SiteID =" + Convert.ToInt32(Session["siteid"]) + " OR SiteID = 0";
            dt = dv.ToTable(); // contains all questions
            DataTable dtMatchPoints = new DataTable();
            dvMatchPoints.RowFilter = "UserID = " + Convert.ToInt32(Session["userid"]) + " AND MatchId = " + Convert.ToInt32(Request.QueryString["matchid"]);

            dtMatchPoints = dvMatchPoints.ToTable();
            #endregion

            //Print the image column
            lvDataElementImage.DataSource = dt;
            lvDataElementImage.DataBind();
            ViewState["CurrectRoundStade"] = dt;

            //Ramdomize selected data elements
            dt.Columns.Add(new DataColumn("RandomNum", Type.GetType("System.Int32")));

            Random random = new Random();
            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                dt.Rows[i]["RandomNum"] = random.Next(1000);
            }
            dv = new DataView(dt);
            dv.Sort = "RandomNum";
            dt = dv.ToTable();
            ViewState["RandomRoundState"] = dt;

            RandomDataElementMaking();

            #region Generate Data element column
            string toWrite = "";

            toWrite = "<ul id='sortable' class='element-list fl connectedSortable'>";
            ids = ids + "#sortable";

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                #region 2 Elements
                if (Convert.ToInt32(dt.Rows[i]["NoDataElements"]) == 2)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[i]["DataSetID"].ToString() + "' datarel='even' class='disabled match-dataset-text wrapword'>";

                    if (dt.Rows[i]["DataElement1"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + dt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    
                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx1";
                }
                #endregion
                #region 3 elements
                else if (Convert.ToInt32(dt.Rows[i]["NoDataElements"]) == 3)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[i]["DataSetID"].ToString() + "' datarel='even' class='disabled match-dataset-text wrapword w34'>";
                    
                    if (dt.Rows[i]["DataElement2"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + dt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";
                    
                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[RandomArray[i]]["DataSetID"].ToString() + "' datarel='odd' class='disabled-blue match-dataset-text wrapword w34'>";
                    
                    if (dt.Rows[RandomArray[i]]["DataElement1"].ToString().Length > 50) 
                        toWrite = toWrite + "           <span>" + dt.Rows[RandomArray[i]]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[RandomArray[i]]["DataElement1"].ToString().Trim() + "</span>";
                    
                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx2";
                }
                #endregion
                #region 4 Elements
                else if (Convert.ToInt32(dt.Rows[i]["NoDataElements"]) == 4)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[i]["DataSetID"].ToString() + "' datarel='data1' class='disabled match-dataset-text wrapword w34'>";
                    
                    if (dt.Rows[i]["DataElement3"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + dt.Rows[i]["DataElement3"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[i]["DataElement3"].ToString().Trim() + "</span>";
                    
                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[RandomArray[i]]["DataSetID"].ToString() + "' datarel='data2' class='disabled-blue match-dataset-text wrapword w34'>";

                    if (dt.Rows[RandomArray[i]]["DataElement2"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + dt.Rows[RandomArray[i]]["DataElement2"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[RandomArray[i]]["DataElement2"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    var rand3 = 0;

                    if ((i + 1) < dt.Rows.Count)
                        rand3 = i + 1;
                    else
                        rand3 = 0;

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + dt.Rows[rand3]["DataSetID"].ToString() + "' datarel='data3' class='disabled-white match-dataset-text wrapword w34'>";

                    if (dt.Rows[rand3]["DataElement1"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + dt.Rows[rand3]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + dt.Rows[rand3]["DataElement1"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx3";
                }
                #endregion
            }
            toWrite = toWrite + "</ul>";

            ids = ids.TrimEnd(' ').TrimEnd(',');

            litWriteCode.Text = toWrite;
            #endregion            
        }

        public void Next()
        {
            counter = counter + 1;
            try
            {
                LoadData(counter);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            ltlDataSetNumber.Text = "Round # " + ViewState["CurrentRound"].ToString() + " of " + ViewState["NoOfRounds"].ToString() + " - " + ViewState["RoundName"].ToString(); // need to look into this

            lblTimeDataSet.Text = ViewState["TimePerRound"].ToString();
            ltScore.Text = ViewState["PointsPerRound"].ToString();
            btnNext.CssClass = "btn-done noVisible";
        }

        public void Confirm()
        {
            TotalPlayerScore = TotalPlayerScore + (int)_generalMatch.PointsPerRound + Convert.ToInt32(ViewState["PointsForCompletation"]);
            btnCnfrm.Visible = false;
            btnNext.Visible = true;
            MatchScoreInsertBLL insertpoints = new MatchScoreInsertBLL();
            Match _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.AchievedPoints = Convert.ToInt32(TotalPlayerScore);
            _match.Elapsed = Convert.ToInt32(lblTimeDataSet.Text);
            _match.IsCorrect = 1;

            insertpoints.Match = _match;
            try
            {
                insertpoints.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCnfrm_Click(object sender, EventArgs e)
        {
            #region MatchPlayLog Entry
            Common.Match _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.MatchTime = System.DateTime.Now.ToShortDateString();
            _match.MatchPlays = 1;


            MatchPlayLogBLL Log = new MatchPlayLogBLL();

            Log.Match = _match;
            try
            {
                Log.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MatchPlayLogEntry = true;
            #endregion

            Confirm();

            UpdatingTargetScore();

            LevelUp();

            Response.Redirect("QuizSelection.aspx", true);
        }

        protected void btnHome_Click(object sender, System.EventArgs e)
        {
            MatchScoreInsertBLL insertpoints = new MatchScoreInsertBLL();
            Match _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.AchievedPoints = 0;
            _match.Elapsed = 0;
            _match.IsCorrect = 0;

            insertpoints.Match = _match;
            try
            {
                insertpoints.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region MatchPlayLog Entry
            _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.MatchTime = System.DateTime.Now.ToShortDateString();
            _match.MatchPlays = 1;


            MatchPlayLogBLL Log = new MatchPlayLogBLL();

            Log.Match = _match;
            try
            {
                Log.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MatchPlayLogEntry = true;
            #endregion

            Response.Redirect("QuizSelection.aspx", true);
        }

        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            MatchScoreInsertBLL insertpoints = new MatchScoreInsertBLL();
            Match _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.AchievedPoints = 0;
            _match.Elapsed = 0;
            _match.IsCorrect = 0;

            insertpoints.Match = _match;
            try
            {
                insertpoints.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region MatchPlayLog Entry
            _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.MatchTime = System.DateTime.Now.ToShortDateString();
            _match.MatchPlays = 1;


            MatchPlayLogBLL Log = new MatchPlayLogBLL();

            Log.Match = _match;
            try
            {
                Log.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MatchPlayLogEntry = true;
            #endregion           

            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            User user = new User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["CurrentRound"]) < Convert.ToInt32(ViewState["NoOfRounds"]))
            {
                TotalPlayerScore = TotalPlayerScore + (int)_generalMatch.PointsPerRound;
                lblPoints.Text = TotalPlayerScore.ToString();
                Next();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "callScript()", true);
            }            
        }

        public void LevelUp()
        {
            #region Level Changing Logic

            #region Get Points
            Points point = new Points();
            point.UserID = Convert.ToInt32(Session["userid"]);
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

         
            #endregion

            UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
            int UserID = Convert.ToInt32(Session["userid"]);
            user.UserID = UserID;
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
                user.CurrentLevel = Convert.ToInt32(ViewState["CurrenLevel"]);
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
                                if (Convert.ToDecimal(dr["current_percentage"]) >= 100 && dr["achieved"].ToString().Equals(""))
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
                               }
                            }
                        }

                        if (userlevel.ResultSet.Tables[0].Rows[0]["popup_showed"].ToString().ToLower() == "0")
                        {
                            //done logic

                            PopupShowedUpdateBLL popup = new PopupShowedUpdateBLL();
                            popup.User = user;
                            try
                            {
                                popup.Invoke();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }


                        #region Page Reloading
                        UserLevelPercentBLL userPercent = new UserLevelPercentBLL();
                        
                        userPercent.User = user;
                        try
                        {
                            userPercent.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        int Level = 0;
                        if (userPercent.ResultSet != null && userPercent.ResultSet.Tables.Count > 0 && userPercent.ResultSet.Tables[0] != null && userPercent.ResultSet.Tables[0].Rows.Count > 0)
                        {
                            Level = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["current_level"]);
                        }

                        GetPopupShowed_LevelPerformanceBLL Next = new GetPopupShowed_LevelPerformanceBLL();
                        DataView dVNext = new DataView();
                        try
                        {
                            Next.Invoke();
                            dVNext = Next.ResultSet.Tables[0].DefaultView;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        dVNext.RowFilter = "user_id = " + Convert.ToInt32(Session["userid"]) + "AND current_level = " + Level;
                        DataTable dTNext = dVNext.ToTable();
                        int NextLevel = 0;
                        if (dTNext.Rows.Count == 1) { NextLevel = Convert.ToInt32(dTNext.Rows[0]["next_level"]); }

                       // LoadData(UserID, NextLevel);

                     //   ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('The player has completed all the targets and has been successfully Leveled Up')</script>", false);

                        //Response.Write("<script LANGUAGE='JavaScript' >alert('The player has completed all the targets and has been successfully Leveled Up')</script>");

                    //    Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString() + "&levelid=" + NextLevel, false);

                        #endregion
                    }
                    else
                    {
                        //LoadData(UserID, LevelID);
                    }
                }
            }
            #endregion
        }

        public void UpdatingTargetScore()
        {
            #region Updating Target Score with Match Score

            TotalScore();

            int UserID = Convert.ToInt32(Session["userid"]);
            int LevelID = Convert.ToInt32(ViewState["CurrenLevel"]);

            String UserPoints = "0";

            TargetViewBLL Target = new TargetViewBLL();
            try
            {
                Target.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DataView dvTarget = Target.ResultSet.Tables[0].DefaultView;
            dvTarget.RowFilter = "Level_ID = " + LevelID;

            DataTable dtTarget = dvTarget.ToTable();

            ScoreManualUpdateBLL score = new ScoreManualUpdateBLL();
           

            user.UserID = UserID;
            user.CurrentLevel = LevelID;

            for (int i = 0; i < dtTarget.Rows.Count; i++)
            {
                int TargetText = Convert.ToInt32(dtTarget.Rows[i]["KPI_ID"].ToString());


                if (Convert.ToInt32(ViewState["LinkedKPIID"]).Equals(TargetText))
                {
                    int TargetValue = Convert.ToInt32(dtTarget.Rows[i]["Target_Value"].ToString());
                   ViewState["targetvalue"]=TargetValue;

                    if (Convert.ToInt32(ViewState["TotalPlayerScore"]) < TargetValue)
                    {
                        ViewState["targetvalue"]=Convert.ToInt32(ViewState["TotalPlayerScore"]);
                        user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                        user.Score = Convert.ToInt32(ViewState["TotalPlayerScore"]);

                        break;
                    }
                    else if (Convert.ToInt32(ViewState["TotalPlayerScore"]) == TargetValue)
                    {
                        user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                        user.Score = Convert.ToInt32(ViewState["TotalPlayerScore"]);

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
                        dv.RowFilter = "KPI_ID = " + Convert.ToInt32(ViewState["LinkedKPIID"]);
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

                        break;
                    }
                    else if (Convert.ToInt32(ViewState["TotalPlayerScore"]) > TargetValue)
                    {
                        user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
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
                        dv.RowFilter = "KPI_ID = " + Convert.ToInt32(ViewState["LinkedKPIID"]);
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
                                    if (ex.Message.ToLower().Contains("duplicate"))
                                    { }
                                    else
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

                        break;
                    }
                }
            }
            if (Convert.ToInt32(ViewState["LinkedKPIID"]) > 0)
            {

                user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                user.CurrentLevel = LevelID;
                user.Score = Convert.ToInt32(ViewState["targetvalue"]);
                score.User = user;

                try
                {
                    score.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion
        }

        public void GetRelatedKPI()
        {
            #region Getting KPI
            PlayerMatchViewBLL Match_Selection = new PlayerMatchViewBLL();
            try
            {
                Match_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv_New = Match_Selection.ResultSet.Tables[3].DefaultView;
            dv_New.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]);
            DataTable dtMatch = dv_New.ToTable();

            if (dtMatch.Rows.Count > 0 && dtMatch.Rows.Count == 1) 
            { 
                if (dtMatch.Rows[0]["KPI_ID"].ToString().Equals("") || dtMatch.Rows[0]["KPI_ID"].ToString().Equals(null)) 
                { 
                    ViewState["LinkedKPIID"] = 0; 
                } 
                else 
                {
                    ViewState["LinkedKPIID"] = Convert.ToInt32(dtMatch.Rows[0]["KPI_ID"]);
                }
            }

            #endregion
        }

        public void TotalScore()
        {
            PlayerMatchViewBLL Match_Selection = new PlayerMatchViewBLL();
            try
            {
                Match_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = Match_Selection.ResultSet.Tables[0].DefaultView;
            dv.RowFilter = "UserID =" + Convert.ToInt32(Session["userid"]) + " AND MatchID =" +
                                                    Convert.ToInt32(Request.QueryString["matchid"]);
            
            DataRow[] drs = dv.ToTable().Select("MatchPoints = max(MatchPoints)");

            if (drs.Length > 0)
            {
                ViewState["TotalPlayerScore"] = Convert.ToInt32(drs[0]["MatchPoints"].ToString());
            }
        }

        public void NewNumber()
        {
            var nRounds = Convert.ToInt32(ViewState["NoOfRounds"]);
            if (MyNumber < nRounds)
                MyNumber = MyNumber + 1;
        }
        
        public void RandomDataElementMaking()
        {
           // RandomArray = new int[QuestionLimit+1];
            NumberofDataSets = dt.Rows.Count;
            //NumberofQuestions = NumberofQuestions +1;
            RandomArray = new int[NumberofDataSets];
            int Seed = (int)DateTime.Now.Ticks;
            HashSet<int> check = new HashSet<int>();
            Random randGen = new Random(Seed);
           // int XNumber = 0;
            for (int i = 0; i < NumberofDataSets; i++)
            {
                int curValue = randGen.Next(0, NumberofDataSets);
                while (check.Contains(curValue))
                {
                    curValue = randGen.Next(0, NumberofDataSets);
                }
                check.Add(curValue);
                RandomArray[i] = curValue;
            }
        }

        [WebMethod]
        public static bool UpdateScore(string score)
        {
            _generalMatch.PointsPerRound = Convert.ToInt32(score);
            return true;
        }

        protected static bool ValidateSeleccion ()
        {
            //var a = (DataTable)ViewState["CurrectRoundStade"];
            //var b = (DataTable)ViewState["RandomRoundState"];

            return true;
        }

        protected void btnTry_Click(object sender, EventArgs e)
        {
            MatchScoreInsertBLL insertpoints = new MatchScoreInsertBLL();
            Match _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.AchievedPoints = 0;
            _match.Elapsed = 0;
            _match.IsCorrect = 0;

            insertpoints.Match = _match;
            try
            {
                insertpoints.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region MatchPlayLog Entry
            _match = new Match();
            _match.UserID = Convert.ToInt32(Session["userid"]);
            _match.MatchID = Convert.ToInt32(Request.QueryString["matchid"]);
            _match.MatchTime = System.DateTime.Now.ToShortDateString();
            _match.MatchPlays = 1;


            MatchPlayLogBLL Log = new MatchPlayLogBLL();

            Log.Match = _match;
            try
            {
                Log.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MatchPlayLogEntry = true;
            #endregion

            #region Current Match
            MatchViewBLL getmatch = new MatchViewBLL();
            Match _gmatch = new Match();
            _gmatch.Where = " WHERE MatchID = " + Convert.ToInt32(Request.QueryString["matchid"]);
            getmatch.Match = _gmatch;
            try
            {
                getmatch.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dvMatch = getmatch.ResultSet.Tables[0].DefaultView;
            dtMatch = new DataTable();
            dtMatch = dvMatch.ToTable();
            ViewState["NoOfDataSet"] = Convert.ToInt32(dtMatch.Rows[0]["NoOfDataSet"]);
            ViewState["MaxPlaysPerDay"] = Convert.ToInt32(dtMatch.Rows[0]["MaxPlaysPerDay"]);
            ViewState["PointsForCompletation"] = Convert.ToInt32(dtMatch.Rows[0]["PointsForCompletation"]);
            lblPointsForCompletation.Text = dtMatch.Rows[0]["PointsForCompletation"].ToString();
            ViewState["NoOfRounds"] = Convert.ToInt32(dtMatch.Rows[0]["NoOfRounds"]);
            lblNoOfRounds.Text = dtMatch.Rows[0]["NoOfRounds"].ToString();
            #endregion

            PlayerMatchViewBLL Match_Selection = new PlayerMatchViewBLL();

            GetMatchPlayLogBLL LogN = new GetMatchPlayLogBLL();
            LogN.Invoke();
            dtLog = LogN.ResultSet;
            dvLog = dtLog.Tables[0].DefaultView;

            try
            {
                Match_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = Match_Selection.ResultSet.Tables[0].DefaultView;

            dv_New = Match_Selection.ResultSet.Tables[3].DefaultView;
            dt_New = Match_Selection.ResultSet.Tables[1];
            dt = dv.ToTable();

            dt.Columns.Add("MatchTime", typeof(DateTime));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt_New.Rows.Count; j++)
                {
                    if (dt.Rows[i]["MatchID"].ToString().Equals(dt_New.Rows[j]["MatchID"].ToString()))
                    {
                        dt.Rows[i]["MatchTime"] = dt_New.Rows[j]["MatchTime"];
                        break;
                    }
                }
            }

            // dv.RowFilter = "Distinct QuizID"; // = " + Convert.ToInt32(Session["userid"])
            dtMatch = dv_New.ToTable();

            DataView dvSelect = dt.DefaultView;
            DataView dvTimeCheck = dt_New.DefaultView;


            dvTimeCheck.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Session["userid"].ToString();
            dvSelect.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Session["userid"].ToString();

            //DataView dv_SelectionCheck = dt.DefaultView;
            //dv_SelectionCheck.RowFilter = "UserID = " + Session["userid"].ToString();

            //   dt_New = dv_New.ToTable();

            DataRow[] drTimeCheck = dvTimeCheck.ToTable().Select();

            DataRow[] drs = dvSelect.ToTable().Select("MatchPoints = max(MatchPoints)");

            DataView dvSelectTop = dt.DefaultView;

            dvSelectTop.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]);

            DataRow[] drsTop = dvSelectTop.ToTable().Select("MatchPoints = max(MatchPoints)");

            var canTry = true;

            if (dvTimeCheck.ToTable().Rows.Count > 0)
            {
                foreach (DataRow dr in dvTimeCheck.ToTable().Rows)
                {
                    DateTime Date = Convert.ToDateTime(dr["MatchTime"].ToString());
                    String DateString = Date.ToShortDateString();

                    dvLog.RowFilter = "MatchID =" + Convert.ToInt32(Request.QueryString["matchid"]) + " AND UserID = " + Convert.ToInt32(Session["userid"]); //+ " AND QuizTime = " + DateString


                    DataTable dtPlayLog = dvLog.ToTable();
                    int Playcount = 0;
                    for (int i = 0; i < dtPlayLog.Rows.Count; i++)
                    {
                        if (dtPlayLog.Rows[i]["MatchTime"].ToString().Equals(DateString))
                        {
                            Playcount = Playcount + 1;
                        }
                    }

                    if (DateString.Equals(System.DateTime.Now.ToShortDateString()))
                    {
                        if (Playcount >= Convert.ToInt32(ViewState["MaxPlaysPerDay"]))
                        {
                            ltDone.Visible = true;
                            canTry = false;
                            Response.Redirect("QuizSelection.aspx", true);
                        }
                        else
                        {
                            ltDone.Visible = false;
                            canTry = true;
                        }
                    }
                }
            }

            if (canTry) 
            {
                counter = 1;
                dt = new DataTable();
                dt_DataSets = new DataTable();
                ltScore.Text = "0";
                litWriteCode.Text = "";
                try
                {
                    LoadData(counter);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                lblTimeDataSet.Text = ViewState["TimePerRound"].ToString();
                ltScore.Text = ViewState["PointsPerRound"].ToString();
                lblSorry.CssClass = "noVisible";
                btnTry.CssClass = "btn-done noVisible";

                CurrenLevel = 0;

                TotalPlayerScore = 0;

                ltlDataSetNumber.Text = "Round # " + ViewState["CurrentRound"].ToString() + " of " + ViewState["NoOfRounds"].ToString() + " - " + ViewState["RoundName"].ToString(); // need to look into this

                MatchScoreDeleteBLL matchscore = new MatchScoreDeleteBLL();
                _match = new Match();
                _match.UserID = Convert.ToInt32(Session["userid"]);
                matchscore.Match = _match;
                try
                {
                    matchscore.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "callScript()", true);
                upMatch.Update();
            }
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            #region Generate Data element column
            DataTable ndt = (DataTable)ViewState["CurrectRoundStade"];

            string toWrite = "";

            toWrite = "<ul id='sortable' class='element-list fl connectedSortable'>";
            ids = ids + "#sortable";

            for (int i = 0; i < ndt.Rows.Count; i++)
            {

                #region 2 Elements
                if (Convert.ToInt32(ndt.Rows[i]["NoDataElements"]) == 2)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='even' class='correct-no match-dataset-text wrapword'>";

                    if (ndt.Rows[i]["DataElement1"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx1";
                }
                #endregion
                #region 3 elements
                else if (Convert.ToInt32(ndt.Rows[i]["NoDataElements"]) == 3)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='even' class='correct-no match-dataset-text wrapword w34'>";

                    if (ndt.Rows[i]["DataElement2"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='odd' class='correct-no match-dataset-text wrapword w34'>";

                    if (ndt.Rows[i]["DataElement1"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx2";
                }
                #endregion
                #region 4 Elements
                else if (Convert.ToInt32(ndt.Rows[i]["NoDataElements"]) == 4)
                {
                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='data1' class='correct-no match-dataset-text wrapword w34'>";

                    if (ndt.Rows[i]["DataElement3"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement3"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement3"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='data2' class='correct-no match-dataset-text wrapword w34'>";

                    if (ndt.Rows[i]["DataElement2"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement2"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";                    

                    toWrite = toWrite + "   <li class='option'>";
                    toWrite = toWrite + "       <div dataid='" + ndt.Rows[i]["DataSetID"].ToString() + "' datarel='data3' class='correct-no match-dataset-text wrapword w34'>";

                    if (ndt.Rows[i]["DataElement1"].ToString().Length > 50)
                        toWrite = toWrite + "           <span>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";
                    else
                        toWrite = toWrite + "           <span class='centerText'>" + ndt.Rows[i]["DataElement1"].ToString().Trim() + "</span>";

                    toWrite = toWrite + "       </div>";
                    toWrite = toWrite + "   </li>";

                    cssClassW34 = "wx3";
                }
                #endregion
            }
            toWrite = toWrite + "</ul>";

            ids = ids.TrimEnd(' ').TrimEnd(',');

            litWriteCode.Text = toWrite;
            #endregion

            lblSorry.CssClass = "";
            btnTry.CssClass = "btn-done";
            ltScore.Text = "0";
            lblTimeDataSet.Text = "0";
            progressBar.Style.Add("width", "0");

            upMatch.Update();
        }
    }
}