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

namespace LevelsPro.PlayerPanel
{
    public partial class QuizSelection : AuthorizedPage
    {
        public DataTable dt;
        public DataTable dt_New;
        public DataView dv_New;
        public DataView dvLog;
        public DataSet dtLog;
        public DataTable dtMandatoryQuizes; // for to check which quizes are mandatory .. and to highlight them
        public int TimeCheck_counter;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                if (Request.QueryString["check"] != null && Request.QueryString["check"].ToString() != "") // return check if there is no question for this role and level left
                {
                    mes.Visible = true; //show message
                    mes.Text = "There are no Questions Left in this Quiz for your level";
                }
                LoadData(); // load all data and also verify all checks of quiz
                TimeCheck_counter = 0;
            }

            lblUserName.Text = Session["displayname"].ToString() + Resources.TestSiteResources.Quiz; //name of user with quiz
        }

        public void LoadData()
        {
            Common.Quiz _quiz = new Quiz(); // common quiz class for quiz related tables to get all properties
            _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);

            Common.Match _match = new Match();
            _match.RoleID = Convert.ToInt32(Session["UserRoleID"]);
            _match.LevelID = Convert.ToInt32(Session["CurLevel"]);

            // _quiz.UserID = Convert.ToInt32(Session["userid"]);
            //_quiz.RoleID = Int32.Parse(Session["userid"].ToString());
            _quiz.LevelID= Convert.ToInt32(Session["CurLevel"]);
            PlayerQuizViewBLL QuizSelection = new PlayerQuizViewBLL();
            PlayerGamesViewBLL Games_Selection = new PlayerGamesViewBLL();

            GetGamesPlayLogBLL Log = new GetGamesPlayLogBLL();
            Log.Invoke();
            dtLog = Log.ResultSet;
            dvLog = dtLog.Tables[0].DefaultView;

            //Quiz_Selection.Quiz = _quiz;
            try
            {
                QuizSelection.Quiz = _quiz;
               // QuizSelection.Invoke();
                Games_Selection.Match = _match;
                Games_Selection.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = Games_Selection.ResultSet.Tables[0].DefaultView;
            dtMandatoryQuizes = Games_Selection.ResultSet.Tables[4];

            dv_New = Games_Selection.ResultSet.Tables[3].DefaultView;
           // dv_New.RowFilter = "LevelID = " + Convert.ToInt32(Session["CurLevel"]);
            dt_New = Games_Selection.ResultSet.Tables[1];
            dt = dv.ToTable();
            
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

           // dv.RowFilter = "Distinct QuizID"; // = " + Convert.ToInt32(Session["userid"])
            DataTable dtQuiz = dv_New.ToTable();

            dlGame.DataSource = dtQuiz;
            dlGame.DataBind();

            #region Commented Code
            //dt.Columns.Add("Check", typeof(int));
            //dt.Columns.Add("TopUser", typeof(String));

            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["DateTime"] != null && dr["DateTime"].ToString() != "")
            //    {
            //        DateTime Dt = Convert.ToDateTime(dr["DateTime"].ToString());

            //        if (dr["TopScorer"].Equals(dr["YourBest"]))
            //        {
            //            dr["TopUser"] = "You have the top score!";
            //        }
            //        else
            //        {
            //            dr["TopUser"] = dr["TopScorer"].ToString() + ", " + dr["TopScorerName"].ToString();
            //        }

            //        if (Dt.ToShortDateString().Equals(System.DateTime.Now.ToShortDateString()))
            //        {
            //            dr["Check"] = 1;
            //        }
            //        else
            //        {
            //            dr["Check"] = 0;
            //        }
            //    }
            //}

            //dlGame.DataSource = dt;
            //dlGame.DataBind();
            #endregion

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

                DataView dvSelect = dt.DefaultView;
                DataView dvTimeCheck = dt_New.DefaultView;

                
                dvTimeCheck.RowFilter = "QuizID =" + ltQuizID.Text.Trim() + " AND UserID = " + Session["userid"].ToString();
                dvSelect.RowFilter = "QuizID =" + ltQuizID.Text.Trim() + " AND UserID = " + Session["userid"].ToString();

                //DataView dv_SelectionCheck = dt.DefaultView;
                //dv_SelectionCheck.RowFilter = "UserID = " + Session["userid"].ToString();

             //   dt_New = dv_New.ToTable();

                DataRow[] drTimeCheck = dvTimeCheck.ToTable().Select();

                DataRow[] drs = dvSelect.ToTable().Select("QuizPoints = max(QuizPoints)");

                if (drs.Length > 0)
                {
                    ltUserBest.Text = drs[0]["QuizPoints"].ToString();
                }

                DataView dvSelectTop = dt.DefaultView;

                dvSelectTop.RowFilter = "QuizID =" + ltQuizID.Text.Trim();

                DataRow[] drsTop = dvSelectTop.ToTable().Select("QuizPoints = max(QuizPoints)");

                if (drsTop.Length > 0)
                {
                    ltTopScore.Text = drsTop[0]["QuizPoints"].ToString() + " " + drsTop[0]["FullName"].ToString();
                }

                //if (dvTimeCheck.ToTable().Rows.Count>0)
                //{
                //    foreach (DataRow dr in dvTimeCheck.ToTable().Rows)
                //    {
                       // DateTime Date = Convert.ToDateTime(dr["QuizTime"].ToString()); //assign quiz date to datetime
                       // String DateString = Date.ToShortDateString();
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
                    

                #region Commented Code
                /*
                //dvBest.RowFilter = "";
                //foreach (DataRow dr in dt.Rows)
                //{
                //    if (dr["Check"].Equals(1))
                //    {
                //        e.Item.CssClass = "qs-item qs-game-done"; // Played
                //        ltDone.Visible = true;
                //        //btn.CssClass = "already-played";
                //        //btn.Text = "You have \n already played\n this game";
                //        //btn.Enabled = false;
                //        btn.Visible = false;
                //    }
                //    else if (dr["Check"].Equals(0))
                //    {
                //        e.Item.CssClass = "qs-item qs-game-ny"; // Not Played
                //        ltDone.Visible = false;
                //        btn.CssClass = "green";
                //        btn.Text = "Play Game";
                //        btn.Enabled = true;
                //        btn.Visible = true;
                //    }
                //}
                 */
                #endregion
            
        

        
    }
}