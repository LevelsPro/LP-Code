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
using log4net;


namespace LevelsPro.PlayerPanel
{
    public partial class QuizPlay : AuthorizedPage
    {
        
        
       
       // public int[] RandomArray;
        
        static DataTable dt_Questions; //not so used
       

        public Random a = new Random(System.DateTime.Now.Ticks.GetHashCode());
        public List<int> randomList = new List<int>();

       
       

        private int checkSeconds = 0; // unused
        private static int CurrenLevel; // unused
        private static int LinkedKPIID; // unused
        private static int TotalPlayerScore; //unused

        private Common.User user = new Common.User();

        public DataView dvLog;
        public DataSet dtLog;
       
        
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

                ViewState["TargetCurrentScore"] = 0;
                ViewState["QuizPlayLogEntry"] = false;
                ViewState["PlayAvailable"] = false;
                Session["counter"] = 0;
                Session["cntans1"] = 0;
                Session["cntans2"] = 0;
                Session["cntans3"] = 0;
                Session["cntans4"] = 0;
                Session["QuestionLimit"] = 0;

                Session["counters"] = 0;
                Session["timeSec"] = 0;
                Session["score"] = 0;
                Session["deduction"] = 0;
                Session["sec"] = 0;
                Session["scoreTemp"] = 0;
                Session["values"] = 0;
                Session["dt"] = 0;

                Session["MyNumber"] = 0;
                Session["NumberofQuestions"] = 0 ;

                Session["Optselected"] = "";
                Session["check"] = 0;

                Session["ReduceOption1"] = false;
                Session["ReduceOption2"] = false;
                Session["ReduceOption3"] = false;
                Session["ReduceOption4"] = false;

                Session["ReduceChoicesCounter"] = 0;
                Session["ReplaceQuestionCounter"] = 0;
                Session["AddSecondsCounter"] = 0;

                dt_Questions = new DataTable();
                ltScore.Text = "0";
                
                checkSeconds = 0;
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                if (bool.Parse(ViewState["PlayAvailable"].ToString()).Equals(true))
                {
                    Session["ReduceChoicesCounter"] = 0;
                    Session["ReplaceQuestionCounter"] = 0;
                    Session["AddSecondsCounter"] = 0;
                    CurrenLevel = 0;
                    LinkedKPIID = 0;
                    TotalPlayerScore = 0;
                    Session["ReduceOption1"] = false;
                    Session["ReduceOption2"] = false;
                    Session["ReduceOption3"] = false;
                    Session["ReduceOption4"] = false;


                    ltlQuestionNumber.Text = "Question # " + (Int32.Parse(Session["counter"].ToString()) + 1).ToString() + " of " + Session["QuestionLimit"].ToString(); // need to look into this

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
                    DataSet dsLifeLine;
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
                                Session["ReduceChoicesCounter"] = 1;
                            }

                            if (Convert.ToInt32(dtLifeline.Rows[i]["ReplaceQuestion_LifeLine"]) == 1)
                            {
                                ReplaceQuestion.ImageUrl = "images/replace-question-disabled.png";
                                Session["ReplaceQuestionCounter"] = 1;
                            }

                            if (Convert.ToInt32(dtLifeline.Rows[i]["AddCounter_LifeLine"]) == 1)
                            {
                                AddSeconds.ImageUrl = "images/plus-5-sec-disabled.png";
                                Session["AddSecondsCounter"] = 1;
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData()
        {
            GetRelatedKPI();
            
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
            Session["dt"] = dv.ToTable(); // contains all questions
            DataTable dt = (DataTable)Session["dt"];
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
                            ViewState["PlayAvailable"] = false;
                        }
                        else
                        {
                            ViewState["PlayAvailable"] = true;

                        }

                    }
                    else
                    {
                        ViewState["PlayAvailable"] = true;
                    }

                }
                if (bool.Parse(ViewState["PlayAvailable"].ToString()).Equals(true))
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

                        }
                        if (dt != null && dt.Rows.Count > 0)
                        {

                            if (dt.Rows.Count > Convert.ToInt32(dt.Rows[0]["NoQuestions"]))
                            {
                                Session["QuestionLimit"] = Convert.ToInt32(dt.Rows[0]["NoQuestions"]);
                            }
                            else
                            {
                                Session["QuestionLimit"] = dt.Rows.Count;
                            }

                            RandomQuestionMaking();
                            int[] RandomArray = (int[])Session["RandomArray"];


                            if (Int32.Parse(Session["counter"].ToString()) < Int32.Parse(Session["QuestionLimit"].ToString()))
                            {
                                NewNumber();
                                ltQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionText"].ToString();
                                if (Convert.ToInt32(Session["MyNumber"]) == 1)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 2)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 3)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 4)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                }
                                lblExplain.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionExplanation"].ToString();
                                imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionImage"].ToString();
                            }

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
                                Session["QuestionLimit"] = Convert.ToInt32(dt.Rows[0]["NoQuestions"]);
                            }
                            else
                            {
                                Session["QuestionLimit"] = dt.Rows.Count;
                            }
                            RandomQuestionMaking();
                            int[] RandomArray = (int[])Session["RandomArray"];



                            if (Int32.Parse(Session["counter"].ToString()) < Int32.Parse( Session["QuestionLimit"].ToString()))
                            {
                                NewNumber();
                                ltQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionText"].ToString();
                                if (Convert.ToInt32(Session["MyNumber"]) == 1)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 2)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 3)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                }

                                else if (Convert.ToInt32(Session["MyNumber"]) == 4)
                                {
                                    btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                                    btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                                    btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                                    btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                                }
                                lblExplain.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionExplanation"].ToString();
                                imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionImage"].ToString();
                            }

                        }
                    }
                    //by atizaz//
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int[] RandomArray = (int[])Session["RandomArray"];

                        lblTimeQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["TimeQuestion"].ToString();
                        ltScore.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionPoints"].ToString();
                        hdDeductionTime.Value = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["DeductionTime"].ToString();
                        //
                        Session["counters"] = 0;
                        Session["scoreTemp"] = 0;
                        Session["values"] = 0;
                        Session["timeSec"] = 0;
                        Session["score"] = 0;
                        Session["deduction"] = 0;

                        Session["timeSec"] = int.Parse(lblTimeQuestion.Text);
                        Session["score"] = Decimal.Parse(ltScore.Text);
                        Session["deduction"] = int.Parse(hdDeductionTime.Value);
                        Session["sec"] = Convert.ToInt32(Session["timeSec"]);
                        //scoreTemp = score / (timeSec - deduction);
                        Session["scoreTemp"] = Convert.ToDecimal(Session["score"]) / (Convert.ToInt32(Session["timeSec"]));
                        Session["values"] = 100 - (100 / Convert.ToInt32(Session["timeSec"]));
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
            int[] RandomArray = (int[])Session["RandomArray"];
            DataTable dt = (DataTable)Session["dt"];
            if (Convert.ToInt32( Session["check"]) == 1)
            {

                LevelUp();
                ViewState["TargetCurrentScore"] = 0;
                Response.Redirect("QuizResult.aspx?check= " + Convert.ToInt32(Request.QueryString["quizid"]));
                btnNext.Visible = false;
                lblExplain.Visible = false;
                AddSeconds.Visible = true;
                ReduceChoices.Visible = true;
                ReplaceQuestion.Visible = true;
                explain.Visible = false;
                Session["counter"] = 0;
                Session["check"] = 0;
                Session["cntans1"] = 0;
                Session["cntans2"] = 0;
                Session["cntans3"] = 0;
                Session["cntans4"] = 0;
                Session["ReduceOption1"] = false;
                Session["ReduceOption2"] = false;
                Session["ReduceOption3"] = false;
                Session["ReduceOption4"] = false;


            }
            else
            {
                btnNext.Visible = false;
                explain.Visible = false;
                lblExplain.Visible = false;
                AddSeconds.Visible = true;
                ReduceChoices.Visible = true;
                ReplaceQuestion.Visible = true;

                Session["counter"] = Int32.Parse(Session["counter"].ToString()) + 1;
                ltlQuestionNumber.Text = "Question # " + (Int32.Parse(Session["counter"].ToString()) + 1).ToString() + " of " + Session["QuestionLimit"].ToString();
                if (Int32.Parse(Session["counter"].ToString()) < Int32.Parse( Session["QuestionLimit"].ToString()) - 1)
                {

                    btnAnswer1.OnClientClick = "return true;";
                    btnAnswer2.OnClientClick = "return true;";
                    btnAnswer3.OnClientClick = "return true;";
                    btnAnswer4.OnClientClick = "return true;";

                    NewNumber();
                    ltQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionText"].ToString();
                    if (Convert.ToInt32(Session["MyNumber"]) == 1)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 2)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 3)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 4)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                    }


                    lblExplain.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionExplanation"].ToString();
                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionImage"].ToString();


                }
                else if (Int32.Parse(Session["counter"].ToString()) < Int32.Parse( Session["QuestionLimit"].ToString()))
                {
                    btnAnswer1.OnClientClick = "return true;";
                    btnAnswer2.OnClientClick = "return true;";
                    btnAnswer3.OnClientClick = "return true;";
                    btnAnswer4.OnClientClick = "return true;";




                    NewNumber();
                    ltQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionText"].ToString();
                    if (Convert.ToInt32(Session["MyNumber"]) == 1)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 2)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 3)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]) == 4)
                    {
                        btnAnswer1.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer1"].ToString();
                        btnAnswer2.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer4"].ToString();
                        btnAnswer3.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer2"].ToString();
                        btnAnswer4.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["Answer3"].ToString();
                    }

                    lblExplain.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionExplanation"].ToString();

                    imgQuestion.ImageUrl = "../" + ConfigurationSettings.AppSettings["QuestionPath"].ToString() + dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionImage"].ToString();

                    Session["check"] = 1;
                }
                //by atizaz//
                lblTimeQuestion.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["TimeQuestion"].ToString();
                ltScore.Text = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionPoints"].ToString();
                hdDeductionTime.Value = dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["DeductionTime"].ToString();
                //
                Session["cntans1"] = 0;
                Session["cntans2"] = 0;
                Session["cntans3"] = 0;
                Session["cntans4"] = 0;

                Session["counters"] = 0;
                Session["scoreTemp"] = 0;
                Session["values"] = 0;
                Session["timeSec"] = 0;
                Session["score"] = 0;
                Session["deduction"] = 0;

                Session["timeSec"] = int.Parse(lblTimeQuestion.Text);
                Session["score"] = int.Parse(ltScore.Text);
                Session["deduction"] = int.Parse(hdDeductionTime.Value);
                Session["sec"] = Convert.ToInt32(Session["timeSec"]);
                //scoreTemp = score / (timeSec - deduction);
                Session["scoreTemp"] = Convert.ToDecimal(Session["score"]) / (Convert.ToInt32(Session["timeSec"]));
                Session["values"] = 100 - (100 / Convert.ToInt32(Session["timeSec"]));
                TimerQuestion.Enabled = true;
                LevelUp();
                //
                /////////////
            }

        }

        protected void btnAnswer1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(Session["cntans1"].ToString()) == 0)
            {
                btnAnswer1.Attributes["Class"] = "yellow option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Session["Optselected"] = "btnAnswer1";
                btnCnfrm.Visible = true;
                Session["cntans1"] = Int32.Parse(Session["cntans1"].ToString()) + 1;
                Session["cntans2"] = 0;
                Session["cntans3"] = 0;
                Session["cntans4"] = 0;
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
            if (Int32.Parse(Session["cntans2"].ToString()) == 0)
            {
                btnAnswer2.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Session["Optselected"] = "btnAnswer2";
                btnCnfrm.Visible = true;
                Session["cntans1"] = 0;
                Session["cntans2"] = Int32.Parse(Session["cntans2"].ToString()) + 1;
                Session["cntans3"] = 0;
                Session["cntans4"] = 0;
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
            if (Int32.Parse(Session["cntans3"].ToString()) == 0)
            {
                btnAnswer3.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer4.Attributes["Class"] = "qbtn option";
                Session["Optselected"] = "btnAnswer3";
                btnCnfrm.Visible = true;
                Session["cntans1"] = 0;
                Session["cntans2"] = 0;
                Session["cntans3"] = Int32.Parse(Session["cntans3"].ToString()) + 1;
                Session["cntans4"] = 0;
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
            if (Int32.Parse(Session["cntans4"].ToString()) == 0)
            {
                btnAnswer4.Attributes["Class"] = "yellow option";
                btnAnswer1.Attributes["Class"] = "qbtn option";
                btnAnswer2.Attributes["Class"] = "qbtn option";
                btnAnswer3.Attributes["Class"] = "qbtn option";

                Session["Optselected"] = "btnAnswer4";

                btnCnfrm.Visible = true;
                Session["cntans1"] = 0;
                Session["cntans2"] = 0;
                Session["cntans3"] = 0;
                Session["cntans4"] = Int32.Parse(Session["cntans4"].ToString()) + 1;
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
            int[] RandomArray = (int[])Session["RandomArray"];
            DataTable dt = (DataTable)Session["dt"];
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

            if (Session["Optselected"].ToString().Equals("noanswer"))
            {
                QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                Quiz _quiz = new Quiz();
                _quiz.UserID = Convert.ToInt32(Session["userid"]);
                _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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


                if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer1.Attributes["class"] = "correct option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";

                }
                else if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer2.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";
                }
                else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer3.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                    btnAnswer4.Attributes["class"] = "disabled option";
                }
                else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer4.Attributes["class"] = "correct option";
                    btnAnswer1.Attributes["class"] = "disabled option";
                    btnAnswer3.Attributes["class"] = "disabled option";
                    btnAnswer2.Attributes["class"] = "disabled option";
                }

            }

            else if (Session["Optselected"].ToString().Equals("btnAnswer1"))
            {
                #region Button 1 Logic
                if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer1.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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


                }
                else // for wrong answer
                {
                    btnAnswer1.Attributes["class"] = "wrong option";

                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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



                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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


                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }

                }
                #endregion
            }
            else if (Session["Optselected"].ToString().Equals("btnAnswer2"))
            {
                #region Button 2 Logic
                if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer2.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                }
                else // for wrong answer
                {
                    btnAnswer2.Attributes["class"] = "wrong option";
                    if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }

                }
                #endregion
            }
            else if (Session["Optselected"].ToString().Equals("btnAnswer3"))
            {
                #region Button 3 Logic
                if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer3.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                }
                else // for wrong answer
                {
                    btnAnswer3.Attributes["class"] = "wrong option";
                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer4.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }

                }
                #endregion
            }
            else if (Session["Optselected"].ToString().Equals("btnAnswer4"))
            {
                #region Button 4 Logic
                if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                {
                    btnAnswer4.Attributes["class"] = "correct option";
                    QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                    Quiz _quiz = new Quiz();
                    _quiz.UserID = Convert.ToInt32(Session["userid"]);
                    _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                    _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                }
                else // for wrong answer
                {
                    btnAnswer4.Attributes["class"] = "wrong option";

                    if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer2.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer3.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }
                    else if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"]))
                    {
                        btnAnswer1.Attributes["class"] = "correct option";
                        QuizScoreInsertBLL insertpoints = new QuizScoreInsertBLL();
                        Quiz _quiz = new Quiz();
                        _quiz.UserID = Convert.ToInt32(Session["userid"]);
                        _quiz.QuizID = Convert.ToInt32(Request.QueryString["quizid"]);
                        _quiz.QuestionID = Convert.ToInt32(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["QuestionID"]);
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

                    }

                }
                #endregion
            }



        }

        protected void btnCnfrm_Click(object sender, EventArgs e)
        {
            TimerQuestion.Enabled = false;

            #region QuizPlayLog Entry
            if (Int32.Parse(Session["counter"].ToString()) == 0)
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

                ViewState["QuizPlayLogEntry"] = true;
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
            if (Int32.Parse( Session["QuestionLimit"].ToString()) == 1)
            {
                Session["check"] = 1;
            }
            btnAnswer1.Attributes["Class"] = "qbtn option";
            btnAnswer2.Attributes["Class"] = "qbtn option";
            btnAnswer3.Attributes["Class"] = "qbtn option";
            btnAnswer4.Attributes["Class"] = "qbtn option";
            Next();

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
            user.CurrentLevel = Convert.ToInt32(ViewState["CurrenLevel"]);
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

            user.UserID = UserID;
            user.CurrentLevel = LevelID;

            for (int i = 0; i < dtTarget.Rows.Count; i++)
            {
                int TargetText = Convert.ToInt32(dtTarget.Rows[i]["KPI_ID"].ToString());


                if (Convert.ToInt32(ViewState["LinkedKPIID"]).Equals(TargetText))
                {
                    int TargetValue = Convert.ToInt32(dtTarget.Rows[i]["Target_Value"].ToString());


                    if (QuestionScore + Convert.ToInt32(ViewState["TargetCurrentScore"]) < TargetValue)
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

                user.Measure = ViewState["KPI_Type"].ToString().Substring(0, 3);
                user.KPIID = Convert.ToInt32(ViewState["LinkedKPIID"]);
                user.Score = Convert.ToInt32(ViewState["TargetCurrentScore"]);
                user.EntryDate = Convert.ToDateTime(DateTime.Now);

                try
                {

                    if (ViewState["KPI_Type"].ToString().ToLower().Substring(0, 3) == "max")
                    {

                        ScoreInsertAutoBLL score = new ScoreInsertAutoBLL();
                        score.User = user;
                        score.Invoke();
                    }
                    else
                    {
                        ScoreManualUpdateBLL score = new ScoreManualUpdateBLL();
                        score.User = user;
                        score.Invoke();
                    }
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



            if (dtQuiz.Rows.Count > 0 && dtQuiz.Rows.Count == 1)
            {
                if (dtQuiz.Rows[0]["KPI_ID"].ToString().Equals("") || dtQuiz.Rows[0]["KPI_ID"].ToString().Equals(null)) { ViewState["LinkedKPIID"] = 0; }
                else
                {
                    Session["LinkedKPIID"] = Convert.ToInt32(dtQuiz.Rows[0]["KPI_ID"]);
                    ViewState["LinkedKPIID"] = Convert.ToInt32(dtQuiz.Rows[0]["KPI_ID"]);

                    KPIViewBLL kpi = new KPIViewBLL();
                    bool isMaxKPI = false;
                    try
                    {

                        kpi.Invoke();

                        var dvKPI = kpi.ResultSet.Tables[0].DefaultView;
                        dvKPI.RowFilter = "KPI_ID = " + Convert.ToInt32(ViewState["LinkedKPIID"]);
                        DataTable dT = new DataTable();
                        dT = dvKPI.ToTable();
                        ViewState["KPI_Type"] = dT.Rows[0]["KPI_Type_Name"].ToString();
                        isMaxKPI= dT.Rows[0]["KPI_Type_Name"].ToString().Substring(0, 3).ToLower()=="max";

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    if (!isMaxKPI)
                    {

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
                    else
                    {
                        ViewState["TargetCurrentScore"] = 0;
                    }
                }
            }

            #endregion
        }

        #region Quiz Internal Playing Rules & Events
        public void NewNumber()
        {
            Session["MyNumber"] = a.Next(1, 5);
        }
        public void RandomQuestionMaking()
        {
            DataTable dt = (DataTable)Session["dt"];
            // RandomArray = new int[QuestionLimit+1];
            Session["NumberofQuestions"] = dt.Rows.Count;
            //NumberofQuestions = NumberofQuestions +1;
            
            int [] RandomArrayQuestions = new int[Convert.ToInt32(Session["NumberofQuestions"])];
            
            
            int Seed = (int)DateTime.Now.Ticks;
            HashSet<int> check = new HashSet<int>();
            Random randGen = new Random(Seed);
            // int XNumber = 0;
            for (int i = 0; i < Convert.ToInt32(Session["NumberofQuestions"]); i++)
            {
                int curValue = randGen.Next(0, Convert.ToInt32(Session["NumberofQuestions"]));
                while (check.Contains(curValue))
                {
                    curValue = randGen.Next(0, Convert.ToInt32(Session["NumberofQuestions"]));
                }
                check.Add(curValue);
                RandomArrayQuestions[i] = curValue;
            }

            Session["RandomArray"] = RandomArrayQuestions;
        }

        protected void ReduceChoices_Click(object sender, ImageClickEventArgs e)
        {
            DataTable dt = (DataTable)Session["dt"];
            int[] RandomArray = (int[])Session["RandomArray"];

            if (Convert.ToInt32(Session["ReduceChoicesCounter"]) == 1)
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
                    if (Convert.ToInt32(Session["MyNumber"]).Equals(1))
                    {
                        if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer1.OnClientClick = "return false;";
                            btnAnswer1.Attributes["class"] = "disabled option";
                            Session["ReduceOption1"] = true;
                            break;
                        }
                    }
                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(2))
                    {
                        if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer2.OnClientClick = "return false;";
                            btnAnswer2.Attributes["class"] = "disabled option";
                            Session["ReduceOption2"] = true;
                            break;
                        }
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(3))
                    {
                        if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer3.OnClientClick = "return false;";
                            btnAnswer3.Attributes["class"] = "disabled option";
                            Session["ReduceOption3"] = true;
                            break;
                        }
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(4))
                    {
                        if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            btnAnswer4.OnClientClick = "return false;";
                            btnAnswer4.Attributes["class"] = "disabled option";
                            Session["ReduceOption4"] = true;
                            break;
                        }
                    }
                    #endregion
                }

                while (true)
                {
                    NewNumber();

                    #region Second Reduce Choice Logic
                    if (Convert.ToInt32(Session["MyNumber"]).Equals(1))
                    {
                        if (btnAnswer1.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (Convert.ToBoolean(Session["ReduceOption1"]) == false)
                            {
                                btnAnswer1.OnClientClick = "return false;";
                                btnAnswer1.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }
                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(2))
                    {
                        if (btnAnswer2.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (Convert.ToBoolean( Session["ReduceOption2"] ) == false)
                            {
                                btnAnswer2.OnClientClick = "return false;";
                                btnAnswer2.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(3))
                    {
                        if (btnAnswer3.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (Convert.ToBoolean(Session["ReduceOption3"]) == false)
                            {
                                btnAnswer3.OnClientClick = "return false;";
                                btnAnswer3.Attributes["class"] = "disabled option";
                                break;
                            }
                        }
                    }

                    else if (Convert.ToInt32(Session["MyNumber"]).Equals(4))
                    {
                        if (btnAnswer4.Text.Equals(dt.Rows[RandomArray[Int32.Parse(Session["counter"].ToString())]]["CorrectAnswer"].ToString())) { }
                        else
                        {
                            if (Convert.ToBoolean(Session["ReduceOption1"]) == false)
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
            DataTable dt = (DataTable)Session["dt"];   
            if (Convert.ToInt32(Session["ReplaceQuestionCounter"]) == 1)
            {
                ReplaceQuestion.OnClientClick = "return false;";
            }
            else
            {
                if (Convert.ToInt32( Session["check"]) == 1)
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
                            Session["QuestionLimit"] = Int32.Parse( Session["QuestionLimit"].ToString()) + 1;
                        }
                        else
                        {
                            Session["QuestionLimit"] = dt.Rows.Count;
                        }
                    }
                    if (Int32.Parse(Session["QuestionLimit"].ToString()) == 1)
                    {
                        Session["check"] = 1;
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
            Session["counters"] = Int32.Parse(Session["counters"].ToString()) + 1;
            if (Int32.Parse(Session["counters"].ToString()) > Convert.ToInt32(Session["deduction"]))
            {
                Session["score"] = Convert.ToDecimal( Session["score"]) - Decimal.Parse( Session["scoreTemp"].ToString());
                Session["sec"] = Convert.ToInt32( Session["sec"]) - 1;
                Session["values"] = Convert.ToDecimal(Session["values"]) - (100 / Convert.ToInt32(Session["timeSec"]));


            }

            ltScore.Text = Math.Round(Convert.ToDouble( Session["score"]), 0).ToString();
            // values = values - (100 / timeSec);
            progressBar.Style.Add("width", Convert.ToDecimal(Session["values"]) + "%");
            // sec -= 1;
            lblTimeQuestion.Text = Session["sec"].ToString();

            if (Int32.Parse(Session["counters"].ToString()) >= (Convert.ToInt32(Session["timeSec"]) + Convert.ToInt32(Session["deduction"])))
            {
                lblTimeQuestion.Text = "0";
                progressBar.Style.Add("width", "0%");
                ltScore.Text = "0";
                TimerQuestion.Enabled = false;
                Session["Optselected"] = "noanswer";
                btnCnfrm_Click(null, null);
            }

        }

        protected void AddSeconds_Click(object sender, ImageClickEventArgs e)
        {
            if (Int32.Parse(Session["counters"].ToString()) > (Convert.ToInt32(Session["deduction"]) + 5))
            {
                if (Convert.ToInt32(Session["AddSecondsCounter"]) == 1)
                {
                    AddSeconds.OnClientClick = "return false;";
                }
                else
                {
                    AddSeconds.OnClientClick = "return false;";
                    TimerQuestion.Enabled = false;
                    ImageButton Imgbtn = (ImageButton)(sender);
                    Imgbtn.ImageUrl = "images/plus-5-sec-disabled.png";
                    if ((Int32.Parse( Session["sec"].ToString()) + 5) <= Convert.ToInt32(Session["timeSec"]))
                    {
                        Session["counters"] = Int32.Parse(Session["counters"].ToString()) - 5;
                        Session["sec"] = Int32.Parse(Session["sec"].ToString()) + 5;
                        Session["score"] = Convert.ToDecimal(Session["score"]) + (Convert.ToDecimal( Session["scoreTemp"]) * 5);
                        Session["values"] = Convert.ToDecimal(Session["values"]) + ((100 / Convert.ToInt32(Session["timeSec"])) * 5);
                        progressBar.Style.Add("width", Convert.ToDecimal(Session["values"]) + "%");
                        lblTimeQuestion.Text = Session["sec"].ToString();
                        ltScore.Text = Math.Round(Convert.ToDouble(Session["score"]), 0).ToString();
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