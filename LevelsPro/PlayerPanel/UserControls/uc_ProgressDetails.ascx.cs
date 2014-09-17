using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using AjaxControlToolkit;
using Common;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_ProgressDetails : System.Web.UI.UserControl
    {
        public DataView dvLog;
        public DataSet dtLog;
        public static String TipsLink = "";
        public static bool PlayAvailable = false;

        protected void Page_Load(object sender, EventArgs e)
        {
                hpl.Visible = true;
           
        }

        public void LoadTargetDescription(int targetid)
        {
            Session["targetid"]=targetid;
            TargetDesciptionViewBLL desc = new TargetDesciptionViewBLL();
           
            try
            {               
                desc.Invoke();
            }

            catch (Exception ex)
            {
            }

            DataView dv = desc.ResultSet.Tables[0].DefaultView;
            dv.RowFilter = "Target_ID=" + targetid;           
            DataTable dt = dv.ToTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                lblheading.Text = dt.Rows[0]["KPIName"].ToString();
                //pdesc.InnerText = dt.Rows[0]["KPIDesc"].ToString();
                string descs = dt.Rows[0]["KPIDesc"].ToString();
                String TipsDESC = dt.Rows[0]["TipsDesc"].ToString();
                String TipsLink = dt.Rows[0]["TipsLink"].ToString();
                bool QuizPart = false;

                if (TipsDESC != null && TipsDESC != "" && TipsLink != null && TipsLink != "")
                {
                    hpl.Text = TipsDESC;
                    hpl.NavigateUrl = TipsLink;
                    lbldesc.Text = descs;
                }
                else
                {
                    hpl.Visible = false;
                }

                if (TipsLink.Contains("QuizPlay.aspx").Equals(true))
                {
                    QuizPart = true;
                }
                else
                {
                    QuizPart = false;
                }

                if (QuizPart == true)
                {

                    String[] TipsParts = TipsLink.Split('=');

                    #region Checking Limit of Quiz
                    Quiz _quiz = new Quiz();
                    _quiz.LevelID = Convert.ToInt32(ReuseableItems.PlayerCurrentLevelID_PlayerPanel.ToString());
                    _quiz.QuizID = Convert.ToInt32(TipsParts[1]);
                    _quiz.RoleID = Convert.ToInt32(Session["UserRoleID"]);


                    PlayerQuizQuestionsViewBLL quiz = new PlayerQuizQuestionsViewBLL();
                    quiz.Quiz = _quiz;
                    try
                    {
                        quiz.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }
                    DataView dvResult = quiz.ResultSet.Tables[0].DefaultView;
                    DataView dvQuizPoints = quiz.ResultSet.Tables[1].DefaultView;
                    dvResult.RowFilter = "SiteID =" + Convert.ToInt32(Session["siteid"]) + " OR SiteID = 0";
                    DataTable dtLimit = dvResult.ToTable(); // contains all questions
                    #endregion

                    #region Checking PlayLimit
                    GetGamesPlayLogBLL Log = new GetGamesPlayLogBLL();
                    try
                    {
                        Log.Invoke();
                        dtLog = Log.ResultSet;
                        dvLog = dtLog.Tables[0].DefaultView;
                        String DateString = System.DateTime.Now.ToShortDateString();
                        dvLog.RowFilter = "QuizID =" + Convert.ToInt32(TipsParts[1]) + " AND UserID = " + Convert.ToInt32(Session["userid"].ToString()); //+ " AND QuizTime = " + DateString


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
                            if (Playcount >= Convert.ToInt32(dtLimit.Rows[0]["LimitGame"]))
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
                    catch (Exception ex)
                    {

                    }
                    #endregion


                    if (PlayAvailable == false)
                    {
                        hpl.Enabled = false;
                        hpl.Text = "You have reached your playable limit, Please wait for one day.";

                    }
                    else
                    {
                        hpl.Enabled = true;
                        hpl.Text = TipsDESC;
                        Session["TipsLinkage"] = "true";
                    }
                }
              
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {            
            ModalPopupExtender mpe = this.Parent.FindControl("mpeViewProgressDetailsDiv") as ModalPopupExtender;
            mpe.Hide();
            //((ProgressDetails)this.Parent.Page).LoadData();
            //((UpdatePanel)this.Parent.FindControl("upViewProgressDetails")).Update();
            //Response.Redirect("ProgressDetails.aspx",false);
        }

                   
    }
}