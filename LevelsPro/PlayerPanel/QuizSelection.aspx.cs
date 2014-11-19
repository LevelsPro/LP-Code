using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using Common;
using BusinessLogic.Reports;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using BusinessLogic.Update;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class QuizSelection : AuthorizedPage
    {
        public DataTable dt;
        public DataTable dt_New;
        public DataView dv_New;
        public DataView dvLog;
        public DataSet dtLog;
        public DataTable dtTopScores; //for User's best and TOp Score Logic
        public DataTable dtMandatoryQuizes; // for to check which quizes are mandatory .. and to highlight them
        public int TimeCheck_counter;
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
                
                if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() != "") // return check if there is no question for this role and level left
                {
                    mes.Visible = true; //show message
                    mes.Text = "There are no Questions for this Quiz";
                }
                
                try
                {
                    LoadData(); // load all data and also verify all checks of quiz
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                TimeCheck_counter = 0;
            }

            lblUserName.Text = Session["displayname"].ToString() + Resources.TestSiteResources.Quiz; //name of user with quiz
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

        public void LoadData()
        {
            Common.Quiz _quiz = new Quiz(); // common quiz class for quiz related tables to get all properties
            _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);

            Common.Match _match = new Match();
            _match.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            _match.LevelID = Convert.ToInt32(Session["CurLevel"]);

            
            _quiz.LevelID= Convert.ToInt32(Session["CurLevel"]);
            PlayerQuizViewBLL QuizSelection = new PlayerQuizViewBLL();
            PlayerGamesViewBLL Games_Selection = new PlayerGamesViewBLL();

            GetGamesPlayLogBLL Log = new GetGamesPlayLogBLL();
            Log.Invoke();
            dtLog = Log.ResultSet;
            dvLog = dtLog.Tables[0].DefaultView;

           
            try
            {
                QuizSelection.Quiz = _quiz;
                QuizSelection.Invoke();
                Games_Selection.Match = _match;
                Games_Selection.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv = Games_Selection.ResultSet.Tables[0].DefaultView;
            dtMandatoryQuizes = Games_Selection.ResultSet.Tables[4];

            dv_New = Games_Selection.ResultSet.Tables[3].DefaultView;
           
            dt_New = Games_Selection.ResultSet.Tables[1];
            dt = dv.ToTable();

            dtTopScores = Games_Selection.ResultSet.Tables[6];

            dt.Columns.Add("QuizTime", typeof(DateTime));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt_New.Rows.Count; j++)
                {
                    if (dt.Rows[i]["QuizID"].ToString().Equals(dt_New.Rows[j]["QuizID"].ToString()))
                    {
                        dt.Rows[i]["QuizTime"] = dt_New.Rows[j]["QuizTime"];
                        break;
                    }
                }
            }
            DataTable dtQuiz = dv_New.ToTable();
            //For Sorting the DataList, with Mandatory and Non Mandatory Games

            for (int i = 0; i < dtQuiz.Rows.Count; i++) // Placing 1 in the Mandatory Column whenever QuizID matches from ResultSet 3 and 4 of the SP
            {
                for (int j = 0; j < dtMandatoryQuizes.Rows.Count; j++)
                {
                    if (dtQuiz.Rows[i]["QuizID"].ToString().Equals(dtMandatoryQuizes.Rows[j]["QuizID"].ToString()))
                    {
                        dtQuiz.Rows[i]["Mandatory"] = "1";
                    }
                }
            }

            DataView SortdtQuiz = dtQuiz.DefaultView;
            SortdtQuiz.Sort = "Mandatory DESC";
            dtQuiz = SortdtQuiz.ToTable();
                //----------------------------------------------------------------



            dlGame.DataSource = dtQuiz;
            dlGame.DataBind();

          

        }
        protected void dlGame_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName.Equals("StartGame"))
            {
                mes.Visible = false;
                String QuizID = e.CommandArgument.ToString().Split('-')[0];
                String Type = e.CommandArgument.ToString().Split('-')[1];
                //Session["QuizID"] = QuizID;
                if (Type == "Quiz")
                    Response.Redirect("QuizPlay.aspx?quizid=" + QuizID);
                else
                    Response.Redirect("MatchPlay.aspx?matchid=" + QuizID);
            }

        }

        protected void btnHome_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("PlayerHome.aspx");
        }

        protected void btnLogOut_Click(object sender, System.EventArgs e)
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

        protected void dlGame_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = e.Item.FindControl("btnStartQuiz") as Button;
                Literal ltDone = e.Item.FindControl("ltDone") as Literal;
                Literal ltUserBest = e.Item.FindControl("ltUserBest") as Literal;
                Literal ltTopScore = e.Item.FindControl("ltTopScore") as Literal;
                Literal ltQuizID = e.Item.FindControl("ltQuizID") as Literal;
                Literal ltGameType = e.Item.FindControl("ltType") as Literal;
                Literal ltLimitPlayable = e.Item.FindControl("ltPlayableLimit") as Literal;
                HtmlGenericControl AlreadyPlayed = e.Item.FindControl("Played") as HtmlGenericControl;
                HtmlGenericControl Playing = e.Item.FindControl("Play") as HtmlGenericControl;
                HtmlGenericControl ItemContainer = e.Item.FindControl("dlDiv") as HtmlGenericControl;

                Session["ltLimitPlayable"] = ltLimitPlayable.Text.ToString();
                DataView dvSelect = dt.DefaultView;
                DataView dvTimeCheck = dt_New.DefaultView;

                
                dvTimeCheck.RowFilter = "QuizID =" + ltQuizID.Text.Trim() + " AND UserID = " + Session["userid"].ToString();
                dvSelect.RowFilter = "QuizID =" + ltQuizID.Text.Trim() + " AND UserID = " + Session["userid"].ToString();

                DataRow[] drTimeCheck = dvTimeCheck.ToTable().Select();

                

                DataView UserScore = dtTopScores.DefaultView;
                UserScore.RowFilter = "QuizID =" + ltQuizID.Text.Trim() + " AND UserID = " + Session["userid"].ToString();
                DataRow[] drs = UserScore.ToTable().Select();
                
                if (drs.Length > 0)
                {
                    ltUserBest.Text = drs[0]["Total"].ToString();
                }

                DataView dvSelectTop = dt.DefaultView;

                dvSelectTop.RowFilter = "QuizID =" + ltQuizID.Text.Trim();

                DataView TopScore = dtTopScores.DefaultView;
                TopScore.RowFilter = "QuizID =" + ltQuizID.Text.Trim();

                DataRow[] drsTop = TopScore.ToTable().Select("Total = max(Total)");

                if (drsTop.Length > 0)
                {
                    ltTopScore.Text = drsTop[0]["Total"].ToString() + " " + drsTop[0]["U_FirstName"].ToString() + " " + drsTop[0]["U_LastName"].ToString();
                }

               
                String DateString = System.DateTime.Now.ToShortDateString();
                dvLog.RowFilter = "QuizID =" + Convert.ToInt32(ltQuizID.Text.Trim()) + " AND UserID = " + Convert.ToInt32(Session["userid"].ToString()); //+ " AND QuizTime = " + DateString

                        
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
                        if (Playcount >= Convert.ToInt32(ltLimitPlayable.Text.ToString()))
                        {
                            AlreadyPlayed.Visible = true;
                            Playing.Visible = false;
                            ItemContainer.Attributes["class"] = "qs-item qs-game-done";
                        }
                        else
                        {
                            AlreadyPlayed.Visible = false;
                            Playing.Visible = true;
                            for (int i = 0; i < dtMandatoryQuizes.Rows.Count; i++)
                            {
                                if (ltQuizID.Text.Equals(dtMandatoryQuizes.Rows[i]["QuizID"].ToString()))
                                {
                                    ItemContainer.Attributes["class"] = "qs-item qs-game-important";
                                    break;
                                }
                                else
                                {
                                    ItemContainer.Attributes["class"] = "qs-item qs-game-ny";
                                }
                            }
                                        
                        }
                        //  ItemContainer.Attributes.CssStyle = "qs-item qs-game-done";

                    }
                    else
                    {
                        AlreadyPlayed.Visible = false;
                        Playing.Visible = true;
                        for (int i = 0; i < dtMandatoryQuizes.Rows.Count; i++)
                        {
                            if (ltQuizID.Text.Equals(dtMandatoryQuizes.Rows[i]["QuizID"].ToString()))
                            {
                                ItemContainer.Attributes["class"] = "qs-item qs-game-important";
                                break;
                            }
                            else
                            {
                                ItemContainer.Attributes["class"] = "qs-item qs-game-ny";
                            }
                        }
                        //ItemContainerPlayed.Visible = false;
                    }
            }
        }
       
    }
}