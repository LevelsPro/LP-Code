using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using BusinessLogic.Update;
using LevelsPro.App_Code;
using System.Data;
using Common;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class PlayerProgress : AuthorizedPage
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
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    ViewState["userid"] = Request.QueryString["userid"];
                   
                }

                if (Request.QueryString["levelid"] != null && Request.QueryString["levelid"].ToString() != "")
                {
                    ViewState["levelid"] = Request.QueryString["levelid"];
                }

                if (ViewState["userid"] != null && ViewState["levelid"] != null)
                {
                    try
                    {
                        LoadData(Convert.ToInt32(ViewState["userid"]), Convert.ToInt32(ViewState["levelid"]));
                    }
                    catch (Exception exp)
                    {
                        throw exp;
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

        #region show player progress
        private void LoadData(int UserID, int LevelID)
        {
            if (ViewState["userid"] != null && ViewState["levelid"] != null)
            {
                PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                Common.User user = new Common.User();
                user.UserID = UserID;
                user.CurrentLevel = LevelID;
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
                    lblNameValue.Text = targetprogress.ResultSet.Tables[0].Rows[0]["FullName"].ToString();
                    lblUserIDValue.Text = targetprogress.ResultSet.Tables[0].Rows[0]["U_Name"].ToString();
                    lblRoleLevel.Text = targetprogress.ResultSet.Tables[0].Rows[0]["Role_Name"].ToString() + " - Level " + targetprogress.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();
                    lblLevelName.Text = targetprogress.ResultSet.Tables[0].Rows[0]["Level_Name"].ToString();
                    dlProgress.DataSource = targetprogress.ResultSet;
                    dlProgress.DataBind();
                }
                else
                {
                    lblNameValue.Text = "";
                    lblUserIDValue.Text = "";
                    lblRoleLevel.Text = "";
                    lblLevelName.Text = "";

                    dlProgress.DataSource = null;
                    dlProgress.DataBind();
                }
            }
        }
        #endregion
        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnAwards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerAward.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnProgress_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerManagement.aspx");
        }
        #region manual update progress
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet dsTarget = new DataSet();
            String UserPoints = "0";
            if (ViewState["userid"] != null && ViewState["levelid"] != null)
            {
                int UserID =  Convert.ToInt32(ViewState["userid"]);
                int LevelID = Convert.ToInt32(ViewState["levelid"]);

                TargetViewBLL Target = new TargetViewBLL();
                try
                {
                    Target.Invoke();
                    dsTarget = Target.ResultSet;
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                    { }
                    else
                        throw ex;
                }

                DataView dvTarget = dsTarget.Tables[0].DefaultView;
                dvTarget.RowFilter = "Level_ID = " + LevelID;

                DataTable dtTarget = dvTarget.ToTable();

                ScoreManualUpdateBLL score = new ScoreManualUpdateBLL();
                Common.User user = new Common.User();

                user.UserID = UserID;
                user.CurrentLevel = LevelID;

                foreach (DataListItem item in dlProgress.Items)
                {
                    Label lblKPIID = (Label)item.FindControl("lblKPIID");
                    TextBox txtScore = (TextBox)item.FindControl("txtScore");

                    String KPIText = lblKPIID.Text.ToString();
                    int KPIScore = Convert.ToInt32(txtScore.Text.ToString());
                    KPIText = KPIText.Trim();

                    for (int i = 0; i < dtTarget.Rows.Count; i++)
                    {
                        String TargetText = dtTarget.Rows[i]["KPI_ID"].ToString();
                        TargetText = TargetText.Trim();

                        if(KPIText.Equals(TargetText))
                        {
                            int TargetValue = Convert.ToInt32(dtTarget.Rows[i]["Target_Value"].ToString());

                            if (KPIScore < TargetValue)
                            {
                                user.KPIID = Convert.ToInt32(lblKPIID.Text.Trim());
                                user.Score = Convert.ToInt32(txtScore.Text.Trim());
                                break;
                            }
                            else if (KPIScore == TargetValue)
                            {
                                user.KPIID = Convert.ToInt32(lblKPIID.Text.Trim());
                                user.Score = Convert.ToInt32(txtScore.Text.Trim());


                                #region KPI Score Acheived
                                PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                                targetprogress.User = user;

                                try
                                {
                                    targetprogress.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.ToLower().Contains("duplicate"))
                                    { }
                                    else
                                        throw ex;
                                }
                                DataView dv = targetprogress.ResultSet.Tables[0].DefaultView;
                                dv.RowFilter = "KPI_ID = " + Convert.ToInt32(lblKPIID.Text.Trim());
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
                            else if (KPIScore > TargetValue)
                            {
                                user.KPIID = Convert.ToInt32(lblKPIID.Text.Trim());
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
                                    if (ex.Message.ToLower().Contains("duplicate"))
                                    { }
                                    else
                                        throw ex;
                                }
                                DataView dv = targetprogress.ResultSet.Tables[0].DefaultView;
                                dv.RowFilter = "KPI_ID = " + Convert.ToInt32(lblKPIID.Text.Trim());
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

                   

                    score.User = user;

                    try
                    {
                        score.Invoke();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ToLower().Contains("duplicate"))
                        { }
                        else
                            throw ex;
                    }
                }

        #endregion

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
                    if (ex.Message.ToLower().Contains("duplicate"))
                    { }
                    else
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
                    if (ex.Message.ToLower().Contains("duplicate"))
                    { }
                    else
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
                        if (ex.Message.ToLower().Contains("duplicate"))
                        { }
                        else
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
                                if (ex.Message.ToLower().Contains("duplicate"))
                                { }
                                else
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
                                            if (ex.Message.ToLower().Contains("duplicate"))
                                            { }
                                            else
                                                throw ex;
                                        }

                                        if (UserPoints != null && !UserPoints.Equals(""))
                                        {
                                            UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                        }
                                        else
                                        {
                                            UserPoints = dr["Points"].ToString();
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
                                    if (ex.Message.ToLower().Contains("duplicate"))
                                    { }
                                    else
                                        throw ex;
                                }

                                if (UserPoints != null && !UserPoints.Equals(""))
                                {
                                    UserPoints = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString())).ToString();
                                }
                                else
                                {
                                    UserPoints = userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString();
                                }

                                //
                            }


                            #region Page Reloading
                            UserLevelPercentBLL userPercent = new UserLevelPercentBLL();
                            Common.User us = new Common.User();
                            us.UserID = UserID;
                            userPercent.User = us;
                            try
                            {
                                userPercent.Invoke();
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToLower().Contains("duplicate"))
                                { }
                                else
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
                                if (ex.Message.ToLower().Contains("duplicate"))
                                { }
                                else
                                    throw ex;
                            }

                            dVNext.RowFilter = "user_id = " + UserID + "AND current_level = " + Level;
                            DataTable dTNext = dVNext.ToTable();
                            int NextLevel = 0;
                            if (dTNext.Rows.Count == 1) { NextLevel = Convert.ToInt32(dTNext.Rows[0]["next_level"]); }
                            try
                            {
                                LoadData(UserID, NextLevel);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToLower().Contains("duplicate"))
                                { }
                                else
                                    throw ex;
                            }
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('The player has completed all the targets and has been successfully Leveled Up')</script>", false);

                            //Response.Write("<script LANGUAGE='JavaScript' >alert('The player has completed all the targets and has been successfully Leveled Up')</script>");

                            Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString() + "&levelid=" + NextLevel, false);

                            #endregion
                        }
                        else
                        {
                            try
                            {
                                LoadData(UserID, LevelID);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.ToLower().Contains("duplicate"))
                                { }
                                else
                                    throw ex;
                            }
                        }
                    }
                }
                #endregion

                
            }
        }

        protected void btnRewards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerRewards.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnMainInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPlayer.aspx?userid=" + ViewState["userid"].ToString(), false);
        }
    }
}