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
using LevelsPro.Util;


namespace LevelsPro.PlayerPanel
{
    public partial class QuizPlay : AuthorizedPage
    {
        static int counter = 0;
        static int cntans1 = 0;
        static int cntans2 = 0;
        static int cntans3 = 0;
        static int cntans4 = 0;
        static int check = 0;
        static int QuestionLimit = 0;
        public static int[] RandomArray;
        static String Optselected = "";
        static DataTable dt_Questions;
        static DataTable dt = new DataTable();
       // static DataTable dtScore = new DataTable();
       // public int Seed = (int)DateTime.Now.Ticks;
        public Random a = new Random(System.DateTime.Now.Ticks.GetHashCode());
        public List<int> randomList = new List<int>();
        public static int MyNumber = 0;
        public static bool ReduceOption1 = false;
        public static bool ReduceOption2 = false;
        public static bool ReduceOption3 = false;
        public static bool ReduceOption4 = false;
        public bool QuizPlayLogEntry = false;
        public static int NumberofQuestions;
        public static DataSet dsLifeLine;
        public static int ReduceChoicesCounter=0;
        public static int ReplaceQuestionCounter = 0;
        public static int AddSecondsCounter = 0;
        private int checkSeconds = 0;
        private static int CurrenLevel;
        private static int LinkedKPIID;
        private static int TotalPlayerScore;
        private Common.User user = new Common.User();
        //
        static int counters = 0;
        static int timeSec = 0;//int.Parse(lblTimeQuestion.Text);
        static Decimal score = 0;//int.Parse(ltScore.Text);
        static int deduction = 0;//int.Parse(hdDeductionTime.Value);
        public DataView dvLog;
        public DataSet dtLog;
        static int sec = 0;
        static Decimal scoreTemp = 0;
        static Decimal values = 0;
        static bool PlayAvailable = false;
        private static string pageURL;
        //
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {

                    System.Uri url = Request.Url;
                    pageURL = url.AbsolutePath.ToString();
                    cntans1 = 0;
                    cntans2 = 0;
                    cntans3 = 0;
                    cntans4 = 0;
                    counter = 0;
                    dt = new DataTable();
                    dt_Questions = new DataTable();
                    ltScore.Text = "0";
                    check = 0;
                    checkSeconds = 0;
                    try
                    {
                        LoadData();
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                    if (PlayAvailable.Equals(true))
                    {
                        ReduceChoicesCounter = 0;
                        ReplaceQuestionCounter = 0;
                        AddSecondsCounter = 0;
                        CurrenLevel = 0;
                        LinkedKPIID = 0;
                        TotalPlayerScore = 0;
                        //dtScore.Columns.Add("UserID", typeof(int));
                        //dtScore.Columns.Add("QuizID", typeof(int));
                        //dtScore.Columns.Add("QuestionID", typeof(int));
                        //dtScore.Columns.Add("PointsAchieved", typeof(int));
                        // dtScore.Columns.Add("ElapsedTime", typeof(int));
                        //dtScore.Columns.Add("IsCorrect", typeof(int));
                        ReduceOption1 = false;
                        ReduceOption2 = false;
                        ReduceOption3 = false;
                        ReduceOption4 = false;
                        //QuizPlayLogEntry = false;

                        ltlQuestionNumber.Text = "Question # " + (counter + 1).ToString() + " of " + QuestionLimit.ToString(); // need to look into this

                        QuizScoreDeleteBLL quizscore = new QuizScoreDeleteBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        quizscore.Quiz = _quiz;
                        try
                        {
                            quizscore.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        GetLifeLinesBLL LifeLine = new GetLifeLinesBLL();

                        try
                        {
                            LifeLine.Invoke();
                            dsLifeLine = LifeLine.ResultSet;

                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        DataView dvLifeLine = dsLifeLine.Tables[0].DefaultView;
                        dvLifeLine.RowFilter = "UserID =" + Convert.ToInt32(Session["userid"]) + " AND QuizID =" +
                                                            Convert.ToInt32(Request.QueryString["quizid"]);

                        DataTable dtLifeline = dvLifeLine.ToTable();

                        for (int i = 0; i < dtLifeline.Rows.Count; i++)
                        {
                            String DateUsed = dtLifeline.Rows[i]["DateUsed"].ToString();
                            if (DateUsed.Equals(System.DateTime.Now.ToShortDateString()))
                            {
                                if (Convert.ToInt32(dtLifeline.Rows[i]["ReduceChoices_LifeLine"]) == 1)
                                {
                                    ReduceChoices.ImageUrl = "images/reduce-choices-disabled.png";
                                    ReduceChoicesCounter = 1;
                                }

                                if (Convert.ToInt32(dtLifeline.Rows[i]["ReplaceQuestion_LifeLine"]) == 1)
                                {
                                    ReplaceQuestion.ImageUrl = "images/replace-question-disabled.png";
                                    ReplaceQuestionCounter = 1;
                                }

                                if (Convert.ToInt32(dtLifeline.Rows[i]["AddCounter_LifeLine"]) == 1)
                                {
                                    AddSeconds.ImageUrl = "images/plus-5-sec-disabled.png";
                                    AddSecondsCounter = 1;
                                }
                            }
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData()
        {
            GetRelatedKPI();
            
            UserViewBLL levelid = new UserViewBLL();
            User us=new User();
            us.Where="Where UserID ="+  Convert.ToInt32(Session["userid"]);
            levelid.User=us;
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
            ViewState["CurrenLevel"] = Convert.ToInt32(dt1.Rows[0]["LevelID"]);
            Quiz _quiz = new Quiz();
            _quiz.LevelID = Convert.ToInt32(dt1.Rows[0]["LevelID"]);
            
            if (Request.QueryString["quizid"] != null && Request.QueryString["quizid"].ToString() != "")
            {
                _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
            }
            _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            
           
            PlayerQuizQuestionsViewBLL quiz = new PlayerQuizQuestionsViewBLL();
            quiz.Quiz = _quiz;
            try
            {
                quiz.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = quiz.ResultSet.Tables[0].DefaultView;
            DataView dvQuizPoints = quiz.ResultSet.Tables[1].DefaultView;
            dv.RowFilter = "SiteID =" + Convert.ToInt32(Session["siteid"]) + " OR SiteID = 0";
            dt = dv.ToTable(); // contains all questions
               
                GetGamesPlayLogBLL Log = new GetGamesPlayLogBLL();
                try
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Log.Invoke();
                        dtLog = Log.ResultSet;
                        dvLog = dtLog.Tables[0].DefaultView;
                        String DateString = System.DateTime.Now.ToShortDateString();
                        dvLog.RowFilter = "QuizID =" + Convert.ToInt32(Request.QueryString["quizid"]) + " AND UserID = " + Convert.ToInt32(Session["userid"].ToString()); //+ " AND QuizTime = " + DateString


                        DataTable dtPlayLog = dvLog.ToTable();

                        int Playcount = 0;
                        for (int i = 0; i < dtPlayLog.Rows.Count; i++)
                        {
                            if (dtPlayLog.Rows[i]["QuizTime"].ToString().Equals(DateString))
                            {
                                Playcount = Playcount + 1;
                            }
                        }

                        if (DateString.Equals(System.DateTime.Now.ToShortDateString()))
                        {
                            if (Playcount >= Convert.ToInt32(dt.Rows[0]["LimitGame"]))
                            {
                                PlayAvailable = false;
                            }
                            else
                            {
                                PlayAvailable = true;

                            }

                        }
                        else
                        {
                            PlayAvailable = true;
                        }

                    }
                    if (PlayAvailable.Equals(true))
                    {
                        DataTable dtQuizPoints = new DataTable();
                        dvQuizPoints.RowFilter = "UserID = " + Convert.ToInt32(Session["userid"]) + " AND QuizId = " + Convert.ToInt32(Request.QueryString["quizid"]);

                        dtQuizPoints = dvQuizPoints.ToTable();
                        if (dt != null && dt.Rows.Count > 0 && dtQuizPoints != null && dtQuizPoints.Rows.Count > 0)
                        {
                            int cont = dt.Rows.Count;
                            for (int k = 0; k < cont; k++)
                            {
                                if (cont != -1 && k != -1)
                                {
                                    if (Convert.ToInt32(dt1.Rows[0]["LevelID"]) == Convert.ToInt32(dt.Rows[k]["LevelID"]))
                                    {


                                    }
                                    else
                                    {
                                        dt.Rows.RemoveAt(k);
                                        dt.AcceptChanges();
                                        k--;
                                        cont--;

                                    }
                                }
                            

                            //--------- Randomized Question Logic -----------------//



                            //-----------------------------------------------------//


                            //int count = dt.Rows.Count;
                            //for (int i = 0; i < count; i++)
                            //{

                            //    for (int j = 0; j < dtQuizPoints.Rows.Count; j++)
                            //    {
                            //        if (i == -1 && count !=0)
                            //        { i = 0; }
                            //      if(i !=-1)
                            //      {
                            //        if (dt.Rows[i]["QuestionID"].Equals(dtQuizPoints.Rows[j]["QuestionID"]))
                            //        {
                            //            dt.Rows[i].Delete();
                            //            dt.AcceptChanges();
                            //            count--;
                            //            i--;
                            //            break;

                            //        }
                            //          }

                            //    }


                            //}
                        }
                            if (dt != null && dt.Rows.Count > 0)
                            {

                                if (dt.Rows.Count > Convert.ToInt32(dt.Rows[0]["NoQuestions"]))
                                {
                                    QuestionLimit = Convert.ToInt32(dt.Rows[0]["NoQuestions"]);
                                }
                                else
                                {
                                    QuestionLimit = dt.Rows.Count;
                                }

                                RandomQuestionMaking();

                                if (counter < QuestionLimit)
                                {
                                    NewNumber();
                                    ltQuestion.Text = dt.Rows[RandomArray[counter]]["QuestionText"].ToString();
                                    if (MyNumber == 1)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                    }

                                    else if (MyNumber == 2)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                    }

                                    else if (MyNumber == 3)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                    }

                                    else if (MyNumber == 4)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                    }
                                    lblExplain.Text = dt.Rows[RandomArray[counter]]["QuestionExplanation"].ToString();
                                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[counter]]["QuestionImage"].ToString();
                                }
                                ////by atizaz//
                                //lblTimeQuestion.Text = dt.Rows[RandomArray[counter]]["TimeQuestion"].ToString();
                                //ltScore.Text = dt.Rows[RandomArray[counter]]["QuestionPoints"].ToString();
                                //hdDeductionTime.Value = dt.Rows[RandomArray[counter]]["DeductionTime"].ToString();
                                ///////////////
                            }
                            else
                            {
                                Response.Redirect("QuizSelection.aspx?check=1");
                            }




                        }
                        else if (dt != null && dt.Rows.Count > 0)
                        {
                            int cont = dt.Rows.Count;
                            for (int k = 0; k < cont; k++)
                            {
                                if (cont != -1 && k != -1)
                                {
                                    if (Convert.ToInt32(dt1.Rows[0]["LevelID"]) == Convert.ToInt32(dt.Rows[k]["LevelID"]))
                                    {


                                    }
                                    else
                                    {
                                        dt.Rows.RemoveAt(k);
                                        dt.AcceptChanges();
                                        k--;
                                        cont--;

                                    }
                                }

                            }
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows.Count > Convert.ToInt32(dt.Rows[0]["NoQuestions"]))
                                {
                                    QuestionLimit = Convert.ToInt32(dt.Rows[0]["NoQuestions"]);
                                }
                                else
                                {
                                    QuestionLimit = dt.Rows.Count;
                                }
                                RandomQuestionMaking();



                                if (counter < QuestionLimit)
                                {
                                    NewNumber();
                                    ltQuestion.Text = dt.Rows[RandomArray[counter]]["QuestionText"].ToString();
                                    if (MyNumber == 1)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                    }

                                    else if (MyNumber == 2)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                    }

                                    else if (MyNumber == 3)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                    }

                                    else if (MyNumber == 4)
                                    {
                                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                                    }
                                    lblExplain.Text = dt.Rows[RandomArray[counter]]["QuestionExplanation"].ToString();
                                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[counter]]["QuestionImage"].ToString();
                                }
                                //lblTimeQuestion.Text = dt.Rows[RandomArray[counter]]["TimeQuestion"].ToString();
                                //ltScore.Text = dt.Rows[RandomArray[counter]]["QuestionPoints"].ToString();
                                //hdDeductionTime.Value = dt.Rows[RandomArray[counter]]["DeductionTime"].ToString();
                            }
                        }
                        //by atizaz//
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lblTimeQuestion.Text = dt.Rows[RandomArray[counter]]["TimeQuestion"].ToString();
                            ltScore.Text = dt.Rows[RandomArray[counter]]["QuestionPoints"].ToString();
                            hdDeductionTime.Value = dt.Rows[RandomArray[counter]]["DeductionTime"].ToString();
                            //
                            counters = 0;
                            scoreTemp = 0;
                            values = 0;
                            timeSec = 0;
                            score = 0;
                            deduction = 0;

                            timeSec = int.Parse(lblTimeQuestion.Text);
                            score = int.Parse(ltScore.Text);
                            deduction = int.Parse(hdDeductionTime.Value);
                            sec = timeSec;
                            //scoreTemp = score / (timeSec - deduction);
                            scoreTemp = score / (timeSec);
                            values = 100 - (100 / timeSec);
                            TimerQuestion.Enabled = true;
                        }
                        else
                        {
                            Response.Redirect("QuizSelection.aspx?check=1");

                        }
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Your Playable Limit is reached, you cannot play this game for today');</script>");
                            string jScript = "<script>window.close();</script>";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
                        }
                        else
                        {
                            Response.Redirect("QuizSelection.aspx?check=1");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

        }


        public void Next()
        {
            if (check == 1)
            {
                //QuizScoreDeleteBLL quizscore = new QuizScoreDeleteBLL();
                //Quiz _quiz = new Quiz();
                //_quiz.UserID = Convert.ToInt32(Session["userid"]);
                //quizscore.Quiz = _quiz;
                //try
                //{
                //    quizscore.Invoke();
                //}
                //catch (Exception ex)
                //{
                //}
                //QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                //Quiz _quiz = new Quiz();
                //if (dtScore != null && dtScore.Rows.Count > 0)
                //{
                //    QuizScoreDeleteBLL quizscore = new QuizScoreDeleteBLL();
                //    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                //    quizscore.Quiz = _quiz;
                //    try
                //    {
                //        quizscore.Invoke();
                //    }
                //    catch (Exception ex)
                //    {
                //    }
                    //foreach (DataRow drow in dtScore.Rows)
                    //{
                        //_quiz.UserID = Convert.ToInt32(drow["UserID"]);
                        //_quiz.QuizID = Convert.ToInt32(drow["QuizID"]);
                        //_quiz.QuestionID = Convert.ToInt32(drow["QuestionID"]);
                        //_quiz.AchievedPoints = Convert.ToInt32(drow["PointsAchieved"]);
                        //_quiz.Elapsed = Convert.ToInt32(drow["ElapsedTime"]);
                        //_quiz.IsCorrect = Convert.ToInt32(drow["IsCorrect"]);

                        //insertpoints.Quiz = _quiz;
                        //try
                        //{
                        //    insertpoints.Invoke();
                        //}
                        //catch (Exception ex)
                        //{
                        //}
                    //}

                        //_quiz.UserID = Convert.ToInt32(Session["userid"]);
                        //_quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        //_quiz.QuizTime = System.DateTime.Now.ToShortDateString();


                        //QuizPlayLogBLL Log = new QuizPlayLogBLL();

                        //Log.Quiz = _quiz;
                        //try
                        //{
                        //    Log.Invoke();
                        //}
                        //catch (Exception ex)
                        //{
                        //}

               
 //}


                       // dtScore = new DataTable();

                        Response.Redirect("QuizResult.aspx?check= " + Convert.ToInt32(Request.QueryString["quizid"]));
                        btnNext.Visible = false;
                        lblExplain.Visible = false;
                        AddSeconds.Visible = true;
                        ReduceChoices.Visible = true;
                        ReplaceQuestion.Visible = true;
                        explain.Visible = false;
                        counter = 0;
                        check = 0;
                        cntans1 = 0;
                        cntans2 = 0;
                        cntans3 = 0;
                        cntans4 = 0;
                        ReduceOption1 = false;
                        ReduceOption2 = false;
                        ReduceOption3 = false;
                        ReduceOption4 = false;

                
            }
            else
            {
                btnNext.Visible = false;
                explain.Visible = false;
                lblExplain.Visible = false;
                AddSeconds.Visible = true;
                ReduceChoices.Visible = true;
                ReplaceQuestion.Visible = true;

                counter = counter + 1;
                ltlQuestionNumber.Text = "Question # " + (counter + 1).ToString() + " of " + QuestionLimit.ToString();
                if (counter < QuestionLimit - 1)
                {

                    btnAnswer1.OnClientClick = "return true;";
                    btnAnswer2.OnClientClick = "return true;";
                    btnAnswer3.OnClientClick = "return true;";
                    btnAnswer4.OnClientClick = "return true;";

                    NewNumber();
                    ltQuestion.Text = dt.Rows[RandomArray[counter]]["QuestionText"].ToString();
                    if (MyNumber == 1)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                    }
                    
                    else if (MyNumber == 2)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                    }
                    
                    else if (MyNumber == 3)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                    }

                    else if (MyNumber == 4)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                    }
                    

                    lblExplain.Text = dt.Rows[RandomArray[counter]]["QuestionExplanation"].ToString();
                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[counter]]["QuestionImage"].ToString();
                   

                }
                else if (counter < QuestionLimit)
                {
                    btnAnswer1.OnClientClick = "return true;";
                    btnAnswer2.OnClientClick = "return true;";
                    btnAnswer3.OnClientClick = "return true;";
                    btnAnswer4.OnClientClick = "return true;";


                    
                   
                    NewNumber();
                    ltQuestion.Text = dt.Rows[RandomArray[counter]]["QuestionText"].ToString();
                    if (MyNumber == 1)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                    }

                    else if (MyNumber == 2)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                    }

                    else if (MyNumber == 3)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                    }

                    else if (MyNumber == 4)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[counter]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[counter]]["Answer4"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[counter]]["Answer2"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[counter]]["Answer3"].ToString();
                    }
                   
                    lblExplain.Text = dt.Rows[RandomArray[counter]]["QuestionExplanation"].ToString();
                
                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[counter]]["QuestionImage"].ToString();
                   
                    check = 1;
                }
                //by atizaz//
                lblTimeQuestion.Text = dt.Rows[RandomArray[counter]]["TimeQuestion"].ToString();
                ltScore.Text = dt.Rows[RandomArray[counter]]["QuestionPoints"].ToString();
                hdDeductionTime.Value = dt.Rows[RandomArray[counter]]["DeductionTime"].ToString();
                //
                cntans1 = 0;
                cntans2 = 0;
                cntans3 = 0;
                cntans4 = 0;

                counters = 0;
                scoreTemp = 0;
                values = 0;
                timeSec = 0;
                score = 0;
                deduction = 0;

                timeSec = int.Parse(lblTimeQuestion.Text);
                score = int.Parse(ltScore.Text);
                deduction = int.Parse(hdDeductionTime.Value);
                sec = timeSec;
                //scoreTemp = score / (timeSec - deduction);
                scoreTemp = score / (timeSec);
                values = 100 - (100 / timeSec);
                TimerQuestion.Enabled = true;
                //
                /////////////
            }

        }

        protected void btnAnswer1_Click(object sender, EventArgs e)
        {
            if (cntans1 == 0)
            {
                btnAnswer1.Attributes["Class"] = "yellow option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Optselected = "btnAnswer1";
                btnCnfrm.Visible = true;
                cntans1++;
                cntans2 = 0;
                cntans3 = 0;
                cntans4 = 0;
            }
            else
            { 
                btnAnswer1.OnClientClick = "return false";
                btnAnswer2.OnClientClick = "return true";
                btnAnswer3.OnClientClick = "return true";
                btnAnswer4.OnClientClick = "return true";
            }
           

        }

        protected void btnAnswer2_Click(object sender, EventArgs e)
        {
          if (cntans2 ==0)
             {
                btnAnswer2.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Optselected = "btnAnswer2";
                btnCnfrm.Visible = true;
                cntans2++;
                cntans1 = 0;
                cntans3 = 0;
                cntans4 = 0;
            }
          else
          {
                btnAnswer2.OnClientClick = "return false";
                btnAnswer1.OnClientClick = "return true";
                btnAnswer3.OnClientClick = "return true";
                btnAnswer4.OnClientClick = "return true";
            }
         

        }

        protected void btnAnswer3_Click(object sender, EventArgs e)
        {
          if(cntans3==0)
            {
                btnAnswer3.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Optselected = "btnAnswer3";
                btnCnfrm.Visible = true;
                cntans3++;
                cntans1 = 0;
                cntans2 = 0;
                cntans4 = 0;
            }
          else
            {
                btnAnswer3.OnClientClick = "return false";
                btnAnswer2.OnClientClick = "return true";
                btnAnswer1.OnClientClick = "return true";
                btnAnswer4.OnClientClick = "return true";
            }
            

        }

        protected void btnAnswer4_Click(object sender, EventArgs e)
        {
            if(cntans4 == 0)
            {
                btnAnswer4.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";

                Optselected = "btnAnswer4";

                btnCnfrm.Visible = true;
                cntans4++;
                cntans1 = 0;
                cntans2 = 0;
                cntans3 = 0;
            }
            else
            {
                btnAnswer4.OnClientClick = "return false";
                btnAnswer2.OnClientClick = "return true";
                btnAnswer3.OnClientClick = "return true";
                btnAnswer1.OnClientClick = "return true";
            }
           

        }


        public void Confirm()
        {
            ViewState["QuestionScore"] = 0;
            btnCnfrm.Visible = false;
            btnNext.Visible = true;
            explain.Visible = true;
            AddSeconds.Visible = false;
            ReduceChoices.Visible = false;
            ReplaceQuestion.Visible = false;
            lblExplain.Visible = true;
            btnAnswer1.OnClientClick = "return false;";
            btnAnswer2.OnClientClick = "return false;";
            btnAnswer3.OnClientClick = "return false;";
            btnAnswer4.OnClientClick = "return false;";

            if(Optselected.Equals("noanswer"))
            {
                QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                Quiz _quiz = new Quiz();
                _quiz.UserID = Convert.ToInt32(Session["userid"]);
                _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                _quiz.AchievedPoints = 0;
                _quiz.Elapsed = 0;
                _quiz.IsCorrect = 0;

                insertpoints.Quiz = _quiz;
                try
                {
                    insertpoints.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer1.Attributes["class"] = "correct option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";
                
                }
                else if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer2.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";
                }
                else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer3.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";
                }
                else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer4.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                }
               
            }
            
            else if (Optselected.Equals("btnAnswer1"))
            {
                #region Button 1 Logic
                if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer1.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                    ViewState["QuestionScore"] = Convert.ToInt32(ltScore.Text);
                    _quiz.AchievedPoints = Convert.ToInt32(ltScore.Text);
                    _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                    _quiz.IsCorrect = 1;

                    insertpoints.Quiz = _quiz;
                    try
                    {
                        insertpoints.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                 
                    //ltScore.Text = (Convert.ToInt32(ltScore.Text) + Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionPoints"])).ToString();
                    //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), Convert.ToInt32(ltScore.Text), Convert.ToInt32(lblTimeQuestion.Text), 1);
                    //dtScore.AcceptChanges();

                }
                else // for wrong answer
                {
                    btnAnswer1.Attributes["class"] = "wrong option";

                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                       insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                       insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }


                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                       insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                   
                }
                #endregion
            }
            else if (Optselected.Equals("btnAnswer2"))
            {
                #region Button 2 Logic
                if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer2.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                    ViewState["QuestionScore"] = Convert.ToInt32(ltScore.Text);
                    _quiz.AchievedPoints = Convert.ToInt32(ltScore.Text);
                    _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                    _quiz.IsCorrect = 1;

                    insertpoints.Quiz = _quiz;
                    try
                    {
                        insertpoints.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //ltScore.Text = (Convert.ToInt32(ltScore.Text) + Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionPoints"])).ToString();
                    //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), Convert.ToInt32(ltScore.Text), Convert.ToInt32(lblTimeQuestion.Text), 1);
                    //dtScore.AcceptChanges();
                }
                else // for wrong answer
                {
                    btnAnswer2.Attributes["class"] = "wrong option";
                    if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                   
                }
                #endregion
            }
            else if (Optselected.Equals("btnAnswer3"))
            {
                #region Button 3 Logic
                if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer3.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                    ViewState["QuestionScore"] = Convert.ToInt32(ltScore.Text);
                    _quiz.AchievedPoints = Convert.ToInt32(ltScore.Text);
                    _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                    _quiz.IsCorrect = 1;

                    insertpoints.Quiz = _quiz;
                    try
                    {
                        insertpoints.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                   // ltScore.Text = (Convert.ToInt32(ltScore.Text) + Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionPoints"])).ToString();
                    //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), Convert.ToInt32(ltScore.Text), Convert.ToInt32(lblTimeQuestion.Text), 1);
                    //dtScore.AcceptChanges();
                }
                else // for wrong answer
                {
                    btnAnswer3.Attributes["class"] = "wrong option";
                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                   
                }
                #endregion
            }
            else if (Optselected.Equals("btnAnswer4"))
            {
                #region Button 4 Logic
                if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                {
                    btnAnswer4.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                    ViewState["QuestionScore"] = Convert.ToInt32(ltScore.Text);
                    _quiz.AchievedPoints = Convert.ToInt32(ltScore.Text);
                    _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                    _quiz.IsCorrect = 1;

                    insertpoints.Quiz = _quiz;
                    try
                    {
                        insertpoints.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //ltScore.Text = (Convert.ToInt32(ltScore.Text) + Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionPoints"])).ToString();
                    //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), Convert.ToInt32(ltScore.Text), Convert.ToInt32(lblTimeQuestion.Text), 1);
                    //dtScore.AcceptChanges();
                }
                else // for wrong answer
                {
                    btnAnswer4.Attributes["class"] = "wrong option";

                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();  
                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                    else if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
                        _quiz.AchievedPoints = 0;
                        _quiz.Elapsed = Convert.ToInt32(lblTimeQuestion.Text);
                        _quiz.IsCorrect = 0;

                        insertpoints.Quiz = _quiz;
                        try
                        {
                            insertpoints.Invoke();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //dtScore.Rows.Add(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Request.QueryString["quizid"]), Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]), 0, Convert.ToInt32(lblTimeQuestion.Text), 0);
                        //dtScore.AcceptChanges();
                    }
                   
                }
                #endregion
            }
            //else
            //{
            //    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
            //    Quiz _quiz = new Quiz();
            //    _quiz.UserID = Convert.ToInt32(Session["userid"]);
            //    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
            //    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[counter]]["QuestionID"]);
            //    _quiz.AchievedPoints = 0;
            //    _quiz.Elapsed = 0;
            //    _quiz.IsCorrect = 0;

            //    insertpoints.Quiz = _quiz;
            //    try
            //    {
            //        insertpoints.Invoke();
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}
           
          
        }

        protected void btnCnfrm_Click(object sender, EventArgs e)
        {
            TimerQuestion.Enabled = false;
           
            #region QuizPlayLog Entry
            if (counter == 0)
            {
                Common.Quiz _quiz = new Quiz();
                _quiz.UserID = Convert.ToInt32(Session["userid"]);
                _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                _quiz.QuizTime = System.DateTime.Now.ToShortDateString();


                QuizPlayLogBLL Log = new QuizPlayLogBLL();

                Log.Quiz = _quiz;
                try
                {
                    Log.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                QuizPlayLogEntry = true;
            }
            #endregion

            Confirm();

            UpdatingTargetScore(Convert.ToInt32(ViewState["QuestionScore"]));
        }

        protected void btnHome_Click(object sender, System.EventArgs e)
        {
            if ((Session["TipsLinkage"] != null || Session["TipsLinkage"] != "") && Session["TipsLinkage"].Equals("true"))
            {
                string jScript = "<script>window.close();</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
            }
            else
            {
                Response.Redirect("PlayerHome.aspx");
            }
        }

        protected void btnLogout_Click(object sender, System.EventArgs e)
        {
            if ((Session["TipsLinkage"] != null || Session["TipsLinkage"] != "") && Session["TipsLinkage"].Equals("true"))
            {
                string jScript = "<script>window.close();</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "keyClientBlock", jScript);
            }
            else
            {
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
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (QuestionLimit == 1)
            {
                check = 1; 
            }
            btnAnswer1.Attributes["Class"] = "qbtn option";
            btnAnswer2.Attributes["Class"] = "qbtn option";
            btnAnswer3.Attributes["Class"] = "qbtn option";
            btnAnswer4.Attributes["Class"] = "qbtn option";
            Next();
            LevelUp();
           
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
            user.UserID = Convert.ToInt32(Session["userid"]);
            user.CurrentLevel =Convert.ToInt32(ViewState["CurrenLevel"]);
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

                            

                            //
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

        public void UpdatingTargetScore(int QuestionScore)
        {
            #region Updating Target Score with Quiz Score

            //TotalScore();

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
            dvTarget.RowFilter = "Level_ID = " + LevelID + "AND Role_ID = " + Convert.ToInt32(Session["UserRoleID"]);

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
                    

                    if (QuestionScore + Convert.ToInt32(ViewState["TargetCurrentScore"])  < TargetValue)
                    {
                        user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                        user.Score = QuestionScore + Convert.ToInt32(ViewState["TargetCurrentScore"]);// QuestionScore
                        ViewState["TargetCurrentScore"] = QuestionScore + Convert.ToInt32(ViewState["TargetCurrentScore"]);
                        break;
                    }
                    else if (QuestionScore + Convert.ToInt32(ViewState["TargetCurrentScore"]) >= TargetValue)
                    {
                        user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                        user.Score = TargetValue;
                        ViewState["TargetCurrentScore"] = TargetValue;
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
                                    //throw ex;
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
                user.Score = Convert.ToInt32(ViewState["TargetCurrentScore"]);
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

            Common.Quiz _quiz = new Quiz();
            _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            _quiz.LevelID = Convert.ToInt32(Session["CurLevel"]);

            PlayerQuizViewBLL Quiz_Selection = new PlayerQuizViewBLL();
            try
            {
                Quiz_Selection.Quiz = _quiz;
                Quiz_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv_New = Quiz_Selection.ResultSet.Tables[3].DefaultView;
            dv_New.RowFilter = "QuizID =" + Convert.ToInt32(Request.QueryString["quizid"]);
            DataTable dtQuiz = dv_New.ToTable();

            

            if (dtQuiz.Rows.Count > 0 && dtQuiz.Rows.Count == 1) { if (dtQuiz.Rows[0]["KPI_ID"].ToString().Equals("") || dtQuiz.Rows[0]["KPI_ID"].ToString().Equals(null)) { ViewState["LinkedKPIID"] = 0; }
            else 
            { 
                ViewState["LinkedKPIID"] = Convert.ToInt32(dtQuiz.Rows[0]["KPI_ID"]);
                DataView dv_TargetScore = Quiz_Selection.ResultSet.Tables[5].DefaultView;
                dv_TargetScore.RowFilter = "User_ID =" + Convert.ToInt32(Session["userid"]) + "AND Type_ID =" + Convert.ToInt32(ViewState["LinkedKPIID"]);
                DataTable dt_TargetScore = dv_TargetScore.ToTable();
                if (dt_TargetScore.Rows.Count > 0)
                {
                        ViewState["TargetCurrentScore"] = dt_TargetScore.Rows[0]["Score"].ToString();
                    
                }
                else
                {
                    ViewState["TargetCurrentScore"] = 0;
                }
            } 
            }

            #endregion
        }

        //public void TotalScore()
        //{

        //    Common.Quiz _quiz = new Quiz();
        //    _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);
        //    _quiz.LevelID = Convert.ToInt32(Session["CurLevel"]);

        //    PlayerQuizViewBLL Quiz_Selection = new PlayerQuizViewBLL();
        //    try
        //    {
        //        Quiz_Selection.Quiz = _quiz;
        //        Quiz_Selection.Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    DataView dv = Quiz_Selection.ResultSet.Tables[0].DefaultView;
        //    dv.RowFilter = "UserID =" + Convert.ToInt32(Session["userid"]) + " AND QuizID =" +
        //                                            Convert.ToInt32(Request.QueryString["quizid"]);
            
        //    DataRow[] drs = dv.ToTable().Select("QuizPoints = max(QuizPoints)");

        //    if (drs.Length > 0)
        //    {
        //        ViewState["TotalPlayerScore"] = Convert.ToInt32(drs[0]["QuizPoints"].ToString());
        //    }
        //}

        #region Quiz Internal Playing Rules & Events
        public void NewNumber()
        {
            MyNumber = a.Next(1, 5);
        }
        public void RandomQuestionMaking()
        {
           // RandomArray = new int[QuestionLimit+1];
            NumberofQuestions = dt.Rows.Count;
            //NumberofQuestions = NumberofQuestions +1;
            RandomArray = new int[NumberofQuestions];
            int Seed = (int)DateTime.Now.Ticks;
            HashSet<int> check = new HashSet<int>();
            Random randGen = new Random(Seed);
           // int XNumber = 0;
            for (int i = 0; i < NumberofQuestions; i++)
            {
                int curValue = randGen.Next(0, NumberofQuestions);
                while (check.Contains(curValue))
                {
                    curValue = randGen.Next(0, NumberofQuestions);
                }
                check.Add(curValue);
                RandomArray[i] = curValue;
            }
        }

        protected void ReduceChoices_Click(object sender, ImageClickEventArgs e)
        {
            if (ReduceChoicesCounter == 1)
            {
                ReduceChoices.OnClientClick = "return false;";
            }
            else
            {

                ReduceChoices.OnClientClick = "return false;";
                ImageButton Imgbtn = (ImageButton)(sender);
                Imgbtn.ImageUrl = "images/reduce-choices-disabled.png";
                while (true)
                {
                    NewNumber();

                    #region First Reduce Choice Logic
                    if (MyNumber.Equals(1))
                    {
                        if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer1.OnClientClick = "return false;";
                            btnAnswer1.Attributes["class"] = "disabled option";
                            ReduceOption1 = true;
                            break;
                        }
                    }
                    else if (MyNumber.Equals(2))
                    {
                        if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer2.OnClientClick = "return false;";
                            btnAnswer2.Attributes["class"] = "disabled option";
                            ReduceOption2 = true;
                            break;
                        }
                    }

                    else if (MyNumber.Equals(3))
                    {
                        if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer3.OnClientClick = "return false;";
                            btnAnswer3.Attributes["class"] = "disabled option";
                            ReduceOption3 = true;
                            break;
                        }
                    }

                    else if (MyNumber.Equals(4))
                    {
                        if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer4.OnClientClick = "return false;";
                            btnAnswer4.Attributes["class"] = "disabled option";
                            ReduceOption4 = true;
                            break;
                        }
                    }
                    #endregion
                }

                while (true)
                {
                    NewNumber();

                    #region Second Reduce Choice Logic
                    if (MyNumber.Equals(1))
                    {
                        if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (ReduceOption1 == false)
                            {
                                btnAnswer1.OnClientClick = "return false;";
                                btnAnswer1.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }
                    else if (MyNumber.Equals(2))
                    {
                        if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (ReduceOption2 == false)
                            {
                                btnAnswer2.OnClientClick = "return false;";
                                btnAnswer2.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }

                    else if (MyNumber.Equals(3))
                    {
                        if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (ReduceOption3 == false)
                            {
                                btnAnswer3.OnClientClick = "return false;";
                                btnAnswer3.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }

                    else if (MyNumber.Equals(4))
                    {
                        if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[counter]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (ReduceOption1 == false)
                            {
                                btnAnswer4.OnClientClick = "return false;";
                                btnAnswer4.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }
                    #endregion
                }

                #region  Insertion to Lifelines Table
                Common.LifeLine _lifeline = new LifeLine();
                _lifeline.UserID = Convert.ToInt32(Session["userid"]);
                _lifeline.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                _lifeline.DateUsed = System.DateTime.Now.ToShortDateString();
                _lifeline.ReduceChoices = 1;
                _lifeline.ReplaceQuestion = 0;
                _lifeline.AddCounter = 0;

                LifeLineInsertBLL Lifeline = new LifeLineInsertBLL();
                Lifeline.Lifeline = _lifeline;

                try
                {
                    Lifeline.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            
        }

        protected void ReplaceQuestion_Click(object sender, ImageClickEventArgs e)
        {
            if (ReplaceQuestionCounter == 1)
            {
                ReplaceQuestion.OnClientClick = "return false;";
            }
            else
            {
                if (check == 1)
                {
                    ReplaceQuestion.OnClientClick = "javascript:alert('You are at the last question of the quiz, you cannot use this Lifeline');";
                }
                else
                {
                    ReplaceQuestion.OnClientClick = "return false;";
                    ImageButton Imgbtn = (ImageButton)(sender);
                    Imgbtn.ImageUrl = "images/replace-question-disabled.png";

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > Convert.ToInt32(dt.Rows[0]["NoQuestions"]))
                        {
                            QuestionLimit = QuestionLimit + 1;
                        }
                        else
                        {
                            QuestionLimit = dt.Rows.Count;
                        }
                    }
                    if (QuestionLimit == 1)
                    {
                        check = 1;
                        // btnNext.Text = "Done";
                    }

                    #region Insertion to Lifelines Table
                    Common.LifeLine _lifeline = new LifeLine();
                    _lifeline.UserID = Convert.ToInt32(Session["userid"]);
                    _lifeline.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _lifeline.DateUsed = System.DateTime.Now.ToShortDateString();
                    _lifeline.ReduceChoices = 0;
                    _lifeline.ReplaceQuestion = 1;
                    _lifeline.AddCounter = 0;

                    LifeLineInsertBLL Lifeline = new LifeLineInsertBLL();
                    Lifeline.Lifeline = _lifeline;

                    try
                    {
                        Lifeline.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion

                    btnAnswer1.Attributes["Class"] = "qbtn option";
                    btnAnswer2.Attributes["Class"] = "qbtn option";
                    btnAnswer3.Attributes["Class"] = "qbtn option";
                    btnAnswer4.Attributes["Class"] = "qbtn option";

                    Next();
                }
            }
        }

        protected void TimerQuestion_Tick(object sender, EventArgs e)
        {
            counters = counters + 1;
            if (counters > deduction)
            {
                score = score - scoreTemp;
                sec -= 1;
                values = values - (100 / timeSec);
                
               
            }
            
            ltScore.Text = Math.Round(score, 0).ToString();
           // values = values - (100 / timeSec);
            progressBar.Style.Add("width", values + "%");
           // sec -= 1;
            lblTimeQuestion.Text = sec.ToString();
            
            if (counters >= (timeSec + deduction))
            {
                lblTimeQuestion.Text="0";
                progressBar.Style.Add("width","0%");
                ltScore.Text="0";
                TimerQuestion.Enabled = false;
                Optselected = "noanswer";
                btnCnfrm_Click(null, null);
            }
            
        }

        protected void AddSeconds_Click(object sender, ImageClickEventArgs e)
        {
            if (counters > (deduction + 5))
            {
                if (AddSecondsCounter == 1)
                {
                     AddSeconds.OnClientClick = "return false;";
                }
                else
                {
                    AddSeconds.OnClientClick = "return false;";
                    TimerQuestion.Enabled = false;
                    ImageButton Imgbtn = (ImageButton)(sender);
                    Imgbtn.ImageUrl = "images/plus-5-sec-disabled.png";
                    if ((sec + 5) <= timeSec)
                    {
                        counters = counters - 5;
                        sec = sec + 5;
                        score = score + (scoreTemp * 5);
                        values = values + ((100 / timeSec) * 5);
                        progressBar.Style.Add("width", values + "%");
                        lblTimeQuestion.Text = sec.ToString();
                        ltScore.Text = Math.Round(score, 0).ToString();
                        AddSeconds.Enabled = false;

                    }
                    TimerQuestion.Enabled = true;

                    #region Insertion to Lifelines Table
                    Common.LifeLine _lifeline = new LifeLine();
                    _lifeline.UserID = Convert.ToInt32(Session["userid"]);
                    _lifeline.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _lifeline.DateUsed = System.DateTime.Now.ToShortDateString();
                    _lifeline.ReduceChoices = 0;
                    _lifeline.ReplaceQuestion = 0;
                    _lifeline.AddCounter = 1;

                    LifeLineInsertBLL Lifeline = new LifeLineInsertBLL();
                    Lifeline.Lifeline = _lifeline;

                    try
                    {
                        Lifeline.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    #endregion


                }
            }

        }
        #endregion
    }
}