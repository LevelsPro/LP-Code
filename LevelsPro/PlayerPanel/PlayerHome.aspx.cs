using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;
using System.Data;
using System.Configuration;
using System.Net;
using System.IO;
using Facebook;
using System.Reflection;
using BusinessLogic.Reports;
using Common;
using Facebook;
using LinqToTwitter;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using LevelsPro.Util;
using Common.Utils;

namespace LevelsPro.PlayerPanel
{
    public partial class PlayerHome : AuthorizedPage
    {
        private string usr, pwd, role,pageURL;
        // private WebAuthorizer auth; // twitter Authorizer
        protected void Page_Load(object sender, EventArgs e)
        {
      
        
            //string Thumbpath = "";
           
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
                string path = ConfigurationManager.AppSettings["RolePath"].ToString();
                
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dvNoti = messageview.ResultSet.Tables[0].DefaultView;

                dvNoti.RowFilter = "To_UserID=" + Session["userid"] + " AND IsRead=" + 0;

                DataTable dtNoti = dvNoti.ToTable();

                if (dtNoti != null && dtNoti.Rows.Count > 0)
                {
                    lblMessageNotification.Text = dtNoti.Rows.Count.ToString();

                }
                else
                {

                }

                #region Commented Facebook
                //if (Request.QueryString["from"] != null && Request.QueryString["from"].ToString() == "sharebutton") // Needed for facebook share (Hassan)
                //{
                //    ibtnFacebook_Click(null, null);
                //}

                //#region Twitter
                //IOAuthCredentials credentials = new SessionStateCredentials();


                //if (credentials.ConsumerKey == null || credentials.ConsumerSecret == null)
                //{

                //    credentials.ConsumerKey = ConfigurationManager.AppSettings["twitterConsumerKey"];
                //    credentials.ConsumerSecret = ConfigurationManager.AppSettings["twitterConsumerSecret"];
                //    //credentials.OAuthToken = ConfigurationManager.AppSettings["twitterOAuthToken"];
                //    //credentials.AccessToken = ConfigurationManager.AppSettings["twitterAccessToken"];
                //}

                //auth = new WebAuthorizer
                //{
                //    Credentials = credentials,
                //    PerformRedirect = authUrl => Response.Redirect(authUrl)
                //};


                //if (!IsPostBack)
                //{
                //    auth.CompleteAuthorization(Request.Url);
                //    //auth.PerformRedirect(objUri.AbsoluteUri);                
                //}

                //if (Request.QueryString["fromtwitter"] != null && Request.QueryString["fromtwitter"].ToString() == "1") // Needed for Twitter tweet (Hassan)
                //{

                //    if (auth.IsAuthorized)
                //    {
                //        TweetLevel();
                //    }
                //}
                //#endregion



                /////////////////////////////////////////////by atizaz////////////////







                ////if (Request.QueryString["fromtwitter"] != null && Request.QueryString["fromtwitter"].ToString() == "1") // Needed for Twitter tweet (Hassan)
                ////{
                ////    ibtnTwitter_Click(null, null);
                ////}

                #endregion

                //RolesViewBLL roles = new RolesViewBLL();
                //try
                //{
                //    roles.Invoke();
                //}
                //catch (Exception ex)
                //{
                //    //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                //}
                //if (Session["UserRoleID"] != null)
                //{
                //    DataView dv = roles.ResultSet.Tables[0].DefaultView;

                //    dv.RowFilter = "Role_ID=" + Convert.ToInt32(Session["UserRoleID"]);

                //    DataTable dt1 = new DataTable();
                //    dt1 = dv.ToTable();
                //    if (dt1 != null && dt1.Rows.Count > 0 && dt1.Rows[0]["ImageName"] != null && dt1.Rows[0]["ImageName"].ToString() != "")
                //    {
                //        string imagepath = dt1.Rows[0]["ImageName"].ToString();

                //        MapImage.Src = path + imagepath;
                //    }
                //    else
                //    {
                //        MapImage.Src = "images/map.png";
                //    }
                //}

                //Points point = new Points();
                //point.UserID = Convert.ToInt32(Session["userid"]);
                //PlayerPointsViewBLL score = new PlayerPointsViewBLL();
                //try
                //{
                //    score.Points = point;
                //    score.Invoke();
                //}
                //catch (Exception ex)
                //{
                //}
                //DataView dvPoints = score.Sum.Tables[0].DefaultView;
                //DataTable dt = dvPoints.ToTable();

                //if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["U_Points"] != null && dt.Rows[0]["U_Points"].ToString() != "")
                //{
                //    Session["U_Points"] = dt.Rows[0]["U_Points"].ToString();

                //}


                //if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                //{
                //    lblScore.Text = Session["U_Points"].ToString();
                //}
                //else
                //{
                //    lblScore.Text = "0";
                //}
                lblScore.Text = ReuseableItems.PlayerPoints_PlayerPanel.ToString();
                Session["U_Points"] = lblScore.Text;
                #region Commented
                //UserPointsReportBLL _usersum = new UserPointsReportBLL();
                //try
                //{
                //    _usersum.Points = point;
                //    _usersum.Invoke();
                //}
                //catch (Exception ex)
                //{
                //}
                //DataView dv = _usersum.Sum.Tables[0].DefaultView;
                //DataTable dt = dv.ToTable();


                //if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "" )
                //{
                //    if (dt.Rows[1][0].ToString().Trim() != "")
                //    {
                //        lblScore.Text = (Convert.ToInt32(dt.Rows[0][0]) + Convert.ToInt32(dt.Rows[1][0])).ToString();
                //    }
                //    else {
                //        lblScore.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
                //    }
                //}
                //else
                //{
                //    lblScore.Text = "0";
                //}
                #endregion


                UserImageViewBLL UserImage = new UserImageViewBLL();

                Common.UserImage image = new Common.UserImage();

                image.UserID = Convert.ToInt32(Session["userid"]);

                UserImage.UserImages = image;

                try
                {
                    UserImage.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataView dvImage1 = UserImage.ResultSet.Tables[0].DefaultView;
                dvImage1.RowFilter = "U_Current=1";
                DataTable dtcImage = new DataTable();
                dtcImage = dvImage1.ToTable();
                if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                {
                    imgCurrentImage.ImageUrl = Thumbpath + dtcImage.Rows[0]["Player_Thumbnail"].ToString();
                }


                #region Commented
                //UserViewBLL user = new UserViewBLL();
                //try
                //{
                //    user.Invoke();
                //}
                //catch (Exception ex)
                //{
                //}
                //DataView dvName = user.ResultSet.Tables[0].DefaultView;
                //dvName.RowFilter = "UserID=" + Convert.ToInt32(Session["userid"]);
                //DataTable dtName = dvName.ToTable();
                //lblFullName.Visible = true;
                //if (dtName.Rows[0]["Display_Name"].ToString() == "1")
                //{
                //  lblFullName.Text = dtName.Rows[0]["U_FirstName"].ToString() + ' ' + dtName.Rows[0]["U_LastName"].ToString();
                //}
                //else
                //{
                //    lblFullName.Text = dtName.Rows[0]["U_NickName"].ToString();

                //}
                #endregion

                if (!IsPostBack)
                {
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        lblFullName.Text = Session["displayname"].ToString();

                        #region Commented Authentication Code
                        //try
                        //{
                        //    usr = (string)Session["username"];
                        //    pwd = (string)Session["password"];
                        //    role = (string)Session["role"];
                        //    if ((usr == null) || (pwd == null))
                        //    {
                        //        Response.Redirect("~/Login.aspx");
                        //    }
                        //    else
                        //    {

                        //        if (!(Authorization(Roles(role), role)))
                        //        {
                        //            //ClientScript.RegisterStartupScript(typeof(Page), "warning", "<script>alert('Invalid UserName/Password')</script>");                            
                        //        }
                        //        else
                        //        {
                        //            if ((role.Equals("Player")) || (role.Equals("Manager")))
                        //            {

                        //            }
                        //            else
                        //            {
                        //                Response.Redirect("~/Login.aspx");
                        //            }
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
                        //}
                        #endregion

                        if (Session["MyCulture"] != null && Session["MyCulture"].ToString() != "")
                        {
                            if (Session["MyCulture"].ToString() == "fr-FR")
                            {
                                //lbtnAwards.CssClass = "green-btn pag awards-btn frenpag";
                                //btnGame.CssClass = "green-btn pag frenpag2";
                                //btnRedeemPoints.CssClass = "green-btn pag frenpag2";
                                //divPoints.Attributes["class"] = "grey-btn pal frenpag2";
                            }
                            else
                            {
                                //lbtnAwards.CssClass = "green-btn pag awards-btn";
                                //btnGame.CssClass = "green-btn pag";
                                //btnRedeemPoints.CssClass = "green-btn pag";
                                //divPoints.Attributes["class"] = "grey-btn pal";
                            }
                        }

                        // if (Session["siteid"] != null && Session["siteid"].ToString() != "")
                        // {
                        //DataSet ds = new DataSet();
                        //ds = UserData(usr, pwd, Convert.ToInt32(Session["siteid"]));
                        lblUserRole.Text = Session["rolename"].ToString();
                        // }

                        if (Session["userid"] != null && Session["userid"].ToString() != "")
                        {
                            ///////////////////by nasir///////
                            #region  Commented Awards Congratulations
                            //ManualAwardViewBLL manualaward = new ManualAwardViewBLL();
                            //Common.UserAwards _useraward = new Common.UserAwards();
                            //_useraward.User_Id = Convert.ToInt32(Session["userid"]);


                            //manualaward.UserAwards = _useraward;
                            //try
                            //{
                            //    manualaward.Invoke();
                            //}
                            //catch (Exception ex)
                            //{
                            //}

                            //if (manualaward.ResultSet != null && manualaward.ResultSet.Tables.Count > 0 && manualaward.ResultSet.Tables[0] != null && manualaward.ResultSet.Tables[0].Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in manualaward.ResultSet.Tables[0].Rows)
                            //    {
                            //        if (Convert.ToInt32(dr["popup_showed"]) == 0)
                            //        {
                            //            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "manual");
                            //            mpeAwardCongratsMessageDiv.Show();
                            //            //Response.Redirect("PlayerHome.aspx", false);
                            //        }
                            //    }
                            //}

                            //UserAwardAchievedBLL awardachieved = new UserAwardAchievedBLL();
                            //Common.User _user = new Common.User();
                            //_user.UserID = Convert.ToInt32(Session["userid"]);
                            //awardachieved.User = _user;
                            //try
                            //{
                            //    awardachieved.Invoke();
                            //}
                            //catch (Exception ex)
                            //{
                            //}

                            //if (awardachieved.ResultSet != null && awardachieved.ResultSet.Tables.Count > 0 && awardachieved.ResultSet.Tables[0] != null && awardachieved.ResultSet.Tables[0].Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in awardachieved.ResultSet.Tables[0].Rows)
                            //    {
                            //        if (dr["achieved"].ToString() == "" && Convert.ToDecimal(dr["Percentage"]) >= 100)
                            //        {
                            //            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["AwardName"].ToString(), "auto");
                            //            mpeAwardCongratsMessageDiv.Show();
                            //            //Response.Redirect("PlayerHome.aspx", false);
                            //        }
                            //    }
                            //}

                            #endregion
                            //////////////////////

                            /////////by atizaz
                            #region  Awards Congratulations
                            GetAutomaticAwardsBLL award = new GetAutomaticAwardsBLL();
                            Common.User _user = new Common.User();
                            _user.UserID = Convert.ToInt32(Session["userid"]);


                            award.User = _user;
                            try
                            {
                                award.Invoke();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                           ReuseableItems.GetAutomaticAward = award.ResultSet;
                            if (award.ResultSet != null && award.ResultSet.Tables.Count > 0 && award.ResultSet.Tables[1] != null && award.ResultSet.Tables[1].Rows.Count > 0)
                            {
                                DataView dv1 = award.ResultSet.Tables[1].DefaultView;
                                dv1.RowFilter = "Percentage >= 100";
                                DataTable dt1 = dv1.ToTable();

                                foreach (DataRow dr in dt1.Rows)
                                {

                                    int AwardID = Convert.ToInt32(dr["Award_ID"].ToString());
                                    UserAwardAchievedUpdateBLL popup = new UserAwardAchievedUpdateBLL();
                                    Common.User user = new Common.User();

                                    user.UserID = Convert.ToInt32(Session["userid"]);
                                    user.AwardID = AwardID;
                                    //user.CurrentLevel = Convert.ToInt32(LevelID);
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

                            //try
                            //{
                            //    award.Invoke();
                            //}
                            //catch (Exception ex)
                            //{
                            //}
                            if (award.ResultSet != null && award.ResultSet.Tables.Count > 0 && award.ResultSet.Tables[0] != null && award.ResultSet.Tables[0].Rows.Count > 0)
                            {
                                #region Commented
                                //foreach (DataRow dr in award.ResultSet.Tables[0].Rows)
                                //{
                                //    if (dr["popup_showed"].ToString() == "0" && dr["Award_Manual"].ToString() == "1" && dr["AchievedAward"].ToString() == "yes")
                                //    {
                                //        ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "manual");
                                //        mpeAwardCongratsMessageDiv.Show();
                                //        //Response.Redirect("PlayerHome.aspx", false);
                                //    }
                                //    if (dr["Award_Manual"].ToString() == "0" && dr["AchievedAward"].ToString() == "" && Convert.ToDecimal(dr["Percentage"]) >= 100)
                                //    {
                                //        ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "auto");
                                //        mpeAwardCongratsMessageDiv.Show();
                                //        //Response.Redirect("PlayerHome.aspx", false);
                                //    }
                                //}
                                #endregion
                                foreach (DataRow dr in award.ResultSet.Tables[0].Rows)
                                {
                                    if (dr["popup_showed"].ToString() == "False" && dr["Award_Manual"].ToString() == "True")
                                    {
                                        if (Convert.ToInt32(Session["windowcheck"]) == 1)
                                        {
                                            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "manual");
                                            mpeAwardCongratsMessageDiv.Show();

                                            String URL = "https://twitter.com/intent/tweet?source=webclient&text=you+have+sucessfully+achieved+award+"+dr["Award_Name"].ToString()+"+.+via+%40LevelsPro";
                                            Page page = HttpContext.Current.CurrentHandler as Page;
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "windowpop('" + URL + "');", true);
                                            Session["windowcheck"] = "0";
                                        }
                                        else
                                        {
                                            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "manual");
                                            mpeAwardCongratsMessageDiv.Show();
                                            
                                        }
                                       
                                        //Response.Redirect("PlayerHome.aspx", false);
                                    }
                                    if (dr["popup_showed"].ToString() == "False" && dr["Award_Manual"].ToString() == "False" && Convert.ToDecimal(dr["Percentage"]) >= 100)
                                    {
                                        if (Convert.ToInt32(Session["windowcheck"]) == 1)
                                        {
                                            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "auto");
                                            mpeAwardCongratsMessageDiv.Show();
                                            String URL = "https://twitter.com/intent/tweet?source=webclient&text=you+have+sucessfully+achieved+award+"+dr["Award_Name"].ToString()+"+.+via+%40LevelsPro";
                                            Page page = HttpContext.Current.CurrentHandler as Page;
                                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "windowpop('" + URL + "');", true);
                                            Session["windowcheck"] = "0";
                                        }
                                        else
                                        {
                                            ucAwardCongrats.LoadData(Convert.ToInt32(dr["award_id"]), dr["Award_Name"].ToString(), "auto");
                                            mpeAwardCongratsMessageDiv.Show();
                                            //Response.Redirect("PlayerHome.aspx", false);
                                        }
                                    }
                                }
                            }

                            #endregion
                            /////////////////////

                            //UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
                            //Common.User _userPercent = new Common.User();

                            //_userPercent.UserID = Convert.ToInt32(Session["userid"]);

                            //userlevel.User = _userPercent;

                            //try
                            //{
                            //    userlevel.Invoke();
                            //}
                            //catch (Exception ex)
                            //{
                            //}

                         //   if (userlevel.ResultSet != null && userlevel.ResultSet.Tables.Count > 0 && userlevel.ResultSet.Tables[0] != null && userlevel.ResultSet.Tables[0].Rows.Count > 0)
                         //   {
                                #region Commented Code
                                //lblPerformance.Text = Convert.ToDecimal(userlevel.ResultSet.Tables[0].Rows[0]["Percentage"]).ToString("0") + "%";//"80%";

                                //by atizaz  lblLevel.Text = Resources.TestSiteResources.LevelL + ' ' + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();//"Level 1";
                                //lblLevel.Text = Resources.TestSiteResources.LevelL + ' ' + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();//"Level 1";
                                // LevelStar.ImageUrl = "images/star_yellow_1.png";

                                //string p = "images/star_yellow_" + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString() + ".png";

                                #endregion
                            if(ReuseableItems.PlayerCurrentLevelPosition_PlayerPanel > 0)
                            {
                                Session["CurLevel"] = ReuseableItems.PlayerCurrentLevelID_PlayerPanel.ToString();
                                LevelStar.ImageUrl = "images/star_yellow_" + ReuseableItems.PlayerCurrentLevelPosition_PlayerPanel.ToString() + ".png";
                                // imgFxNews.ImageUrl = "~/" + FxNewsFolder + FxNewsImageFilename;


                                TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();

                                //GetProgressDetailBLL progress1 = new GetProgressDetailBLL();
                                Common.User user = new Common.User();

                                user.UserID = Convert.ToInt32(Session["userid"]);
                                user.CurrentLevel = Convert.ToInt32(ReuseableItems.PlayerCurrentLevelID_PlayerPanel);//
                                progress.User = user;
                                //progress1.UserID = user;
                                //user.UserID = Convert.ToInt32(user);

                                try
                                {
                                    progress.Invoke();
                                    //progress1.Invoke();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                if (progress.ResultSet != null && progress.ResultSet.Tables.Count > 0 && progress.ResultSet.Tables[0] != null && progress.ResultSet.Tables[0].Rows.Count > 0)
                                {
                                    if (progress.ResultSet.Tables[0].Rows[0]["CheckNoProgress"].ToString().Equals("0"))
                                    {
                                        decimal percentage = 0;
                                        decimal totalPercentage = 0;

                                        foreach (DataRow dr in progress.ResultSet.Tables[0].Rows)
                                        {
                                            percentage += Convert.ToDecimal(dr["current_percentage"]);
                                        }

                                        totalPercentage = percentage / progress.ResultSet.Tables[0].Rows.Count;

                                        lblPerformance.Text = totalPercentage.ToString("0") + "%";
                                    }
                                    else
                                    {
                                        lblPerformance.Text = "0%";
                                    }

                                        #region Commented Old level up Code
                                        //PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();                                        

                                        //user.UserID = Convert.ToInt32(Session["userid"]);
                                        //user.CurrentLevel = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["current_level"]);//
                                        //targetprogress.User = user;                                        

                                        //try
                                        //{
                                        //    targetprogress.Invoke();                                            
                                        //}
                                        //catch (Exception ex)
                                        //{
                                        //}
                                        //if (targetprogress.ResultSet != null && targetprogress.ResultSet.Tables.Count > 0 && targetprogress.ResultSet.Tables[0] != null && targetprogress.ResultSet.Tables[0].Rows.Count > 0)
                                        //{
                                        //    foreach (DataRow dr in targetprogress.ResultSet.Tables[0].Rows)
                                        //    {
                                        //        if (Convert.ToDecimal(dr["current_percentage"]) >= 100 && dr["achieved"].ToString() == "")
                                        //        {

                                        //            UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                                        //            Common.User user_targetpoints = new Common.User();

                                        //            user_targetpoints.UserID = Convert.ToInt32(Session["userid"]);
                                        //            user.TargetID = Convert.ToInt32(dr["Target_ID"]);

                                        //            popup.User = user;
                                        //            try
                                        //            {
                                        //                popup.Invoke();
                                        //            }
                                        //            catch (Exception ex)
                                        //            {
                                        //            }                                                    

                                        //            if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                                        //            {
                                        //                Session["U_Points"] = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                        //            }
                                        //            else
                                        //            {
                                        //                Session["U_Points"] = dr["Points"].ToString();
                                        //            }

                                        //            Page_Load(null, null);                                                    
                                        //        }
                                        //    }
                                        //}

                                        #endregion

                                        #region Display of multiple popups (by Haseeb)

                                        GetPopupShowed_LevelPerformanceBLL Popup = new GetPopupShowed_LevelPerformanceBLL();
                                        DataSet dSpopUp = new DataSet();

                                        try
                                        {
                                            Popup.Invoke();
                                            dSpopUp = Popup.ResultSet;
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }


                                        DataView dVpopUp = dSpopUp.Tables[0].DefaultView;
                                        dVpopUp.RowFilter = "user_id = " + Convert.ToInt32(Session["userid"]) + "And level_achieved = 1 AND popup_showed = 0";
                                        DataTable dTpopUp = dVpopUp.ToTable();


                                        //for (int i = 0; i < dTpopUp.Rows.Count; i++)
                                        //{
                                        if (dTpopUp.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(dTpopUp.Rows[0]["popup_showed"]) == 0)
                                            {
                                                #region Checking Level Name and bonus
                                                //GetFullLevelTableBLL FullLevel = new GetFullLevelTableBLL();
                                                //DataView dVFullLevel = new DataView();
                                                //try
                                                //{
                                                //    FullLevel.Invoke();
                                                //    dVFullLevel = FullLevel.ResultSet.Tables[0].DefaultView;
                                                //}
                                                //catch (Exception ex)
                                                //{
                                                //}
                                                //dVFullLevel.RowFilter = "Level_ID = " + Convert.ToInt32(dTpopUp.Rows[0]["current_level"]);
                                                DataTable dTFulllevel = ReuseableItems.AllLevelsPlayer;
                                                dTFulllevel.DefaultView.RowFilter = "Level_ID = " + Convert.ToInt32(dTpopUp.Rows[0]["current_level"]);
                                                dTFulllevel = dTFulllevel.DefaultView.ToTable();
                                                String LevelName = "";
                                                String Bonus = "";
                                                if (dTFulllevel.Rows.Count == 1)
                                                {
                                                    LevelName = dTFulllevel.Rows[0]["Level_Position"].ToString();
                                                    Bonus = dTFulllevel.Rows[0]["Points"].ToString();
                                                }
                                                #endregion

                                                ucCongratsMessage.LoadData("Level " + LevelName, dTpopUp.Rows[0]["current_level"].ToString(), Bonus);
                                                if (Convert.ToInt32(Session["windowcheck"]) == 1)
                                                {
                                                    Session["windowcheck"] = "0";
                                                    mpeCongratsMessageDiv.Show();
                                                    String URL = "https://twitter.com/intent/tweet?source=webclient&text=you+have+achieved+Level+" + LevelName + "+.+via+%40LevelsPro";
                                                    Page page = HttpContext.Current.CurrentHandler as Page;
                                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "windowpop('" + URL + "');", true);


                                                }
                                                else
                                                {
                                                    mpeCongratsMessageDiv.Show();
                                                }
                                            }
                                        }
                                        //  }
                                        //}


                                        //if (userlevel.ResultSet.Tables[0].Rows[0]["popup_showed"].ToString().ToLower() == "0")
                                        //{
                                        //    ucCongratsMessage.LoadData("Level " + (Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"]) + 1).ToString(), userlevel.ResultSet.Tables[0].Rows[0]["current_level"].ToString(), userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString());
                                        //    mpeCongratsMessageDiv.Show();
                                        //}

                                        #endregion


                                        #region Commented Old Level up Code
                                        //        else
                                        //        {                                        
                                        //            PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();                                        

                                        //            user.UserID = Convert.ToInt32(Session["userid"]);
                                        //            user.CurrentLevel = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["current_level"]);//
                                        //            targetprogress.User = user;                                        

                                        //            try
                                        //            {
                                        //                targetprogress.Invoke();                                            
                                        //            }
                                        //            catch (Exception ex)
                                        //            {
                                        //            }
                                        //            if (targetprogress.ResultSet != null && targetprogress.ResultSet.Tables.Count > 0 && targetprogress.ResultSet.Tables[0] != null && targetprogress.ResultSet.Tables[0].Rows.Count > 0)
                                        //            {
                                        //                foreach (DataRow dr in targetprogress.ResultSet.Tables[0].Rows)
                                        //                {
                                        //                    if (Convert.ToDecimal(dr["current_percentage"]) >= 100 && dr["achieved"].ToString() == "")
                                        //                    {
                                        //                        UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();
                                        //                        Common.User user_targetpoints = new Common.User();

                                        //                        user_targetpoints.UserID = Convert.ToInt32(Session["userid"]);
                                        //                        user.TargetID = Convert.ToInt32(dr["Target_ID"]);

                                        //                        popup.User = user;
                                        //                        try
                                        //                        {
                                        //                            popup.Invoke();
                                        //                        }
                                        //                        catch (Exception ex)
                                        //                        {
                                        //                        }

                                        //                        if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                                        //                        {
                                        //                            Session["U_Points"] = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(dr["Points"])).ToString();
                                        //                        }
                                        //                        else
                                        //                        {
                                        //                            Session["U_Points"] = dr["Points"].ToString();
                                        //                        }

                                        //                        Page_Load(null, null);                                                    
                                        //                    }
                                        //                }
                                        //            }
                                        //        }

                                        //    }
                                        //    else
                                        //    {
                                        //        lblPerformance.Text = "0%";
                                        //    }
                                        #endregion
                                    }
                                

                            }
                            else
                            {
                                lblPerformance.Text = "0%";
                            }

                        }
                        else
                        {
                            //lblPerformance.Text = "0%";
                            //by atizaz  lblLevel.Text = Resources.TestSiteResources.Level0;
                        }
                        #region Commented
                        //PlayerAwardViewBLL awards = new PlayerAwardViewBLL();
                        //Points points = new Points();

                        //points.UserID = Convert.ToInt32(Session["userid"]);  //Check

                        //awards.Points = points;

                        //try
                        //{
                        //    awards.Invoke();
                        //}
                        //catch (Exception ex)
                        //{
                        //}

                        //PlayerAwardViewBLL award = new PlayerAwardViewBLL();
                        #endregion

                        //Image of map.....by aun

                        //LevelsViewBLL level = new LevelsViewBLL();
                        //Common.Roles role = new Roles();
                        //role.RoleID = Convert.ToInt32(Session["UserRoleID"]);
                        //level.Role = role;
                        //try
                        //{
                        //    level.Invoke();
                        //}
                        //catch (Exception ex)
                        //{
                        //    //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                        //}
                        //if (Session["UserRoleID"] != null)
                        //{
                        //    DataView dv = level.ResultSet.Tables[0].DefaultView;

                        //    dv.RowFilter = "Level_ID=" + Convert.ToInt32(Session["CurLevel"]);

                        //    DataTable dt1 = new DataTable();
                        //    dt1 = dv.ToTable();
                        //    if (dt1 != null && dt1.Rows.Count > 0 && dt1.Rows[0]["ImageName"] != null && dt1.Rows[0]["ImageName"].ToString() != "")
                        //    {
                        if(ReuseableItems.PlayerLevelImage != null || !ReuseableItems.PlayerLevelImage.Equals(""))
                        {
                            
                                string imagepath = ReuseableItems.PlayerLevelImage;
                                ReuseableItems.imgpath = path + imagepath;
                                MapImage.Src = path + imagepath;
                            }
                            else
                            {
                                MapImage.Src = "images/map.png";
                            }
                        

                        //GetAutomaticAwardsBLL auto = new GetAutomaticAwardsBLL();
                        ////Points points = new Points();
                        //Common.User userAw = new Common.User();

                        ////points.UserID = Convert.ToInt32(Session["userid"]);

                        //userAw.UserID = Convert.ToInt32(Session["userid"]);

                        ////award.Points = points;

                        //auto.User = userAw;

                        //try
                        //{
                        //    //award.Invoke();
                        //    auto.Invoke();
                        //}
                        //catch (Exception ex)
                        //{

                        //}
                        DataSet ds = ReuseableItems.GetAutomaticAward;

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            DataView dv = ds.Tables[0].DefaultView;

                            dv.RowFilter = "Percentage >= 100 OR Award_Manual ='True'";// OR AchievedAward = 'yes'

                            DataTable dtAw = dv.ToTable();

                            if (dtAw != null && dtAw.Rows.Count > 0)
                            {
                                //lblTotal.Text = Resources.TestSiteResources.Total + ' ' + award.ResultSet.Tables[0].Rows.Count.ToString();
                                lblTotal.Text = dtAw.Rows.Count.ToString() + ' ' + Resources.TestSiteResources.Total;
                            }
                        }
                        else
                        {
                            lblTotal.Text = Resources.TestSiteResources.Total0;
                        }
                    }
                    else
                    {
                        try
                        {
                            if ((Session["role"] == null))
                            {
                                Response.Redirect("~/Login.aspx");
                            }
                        }
                        catch (Exception)
                        {
                            Response.Redirect("~/Login.aspx");
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerProfile.aspx?userid=1");
        }

        protected void btnRedeemPoints_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(100000);
            Response.Redirect("RedeemPoints.aspx");
        }

        protected void ibtnFacebook_Click(object sender, ImageClickEventArgs e)
        {
            //    try
            //    {
            //        string app_id = ConfigurationManager.AppSettings["FacebookAppID"].ToString();//app id we created
            //        string app_secret = ConfigurationManager.AppSettings["FacebookAppSecretID"].ToString();// app secret
            //        string scope = ConfigurationManager.AppSettings["FacebookScope"].ToString();// the permission to grant me for the facebook user

            //        if (Request["code"] == null) // ask facebook for the code
            //        {
            //            Response.Redirect(string.Format(
            //                "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
            //                app_id, Request.Url.AbsoluteUri + "?from=sharebutton", scope));
            //        }
            //        else
            //        {
            //            Dictionary<string, string> tokens = new Dictionary<string, string>(); //parameters returned from facebook

            //            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
            //                app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

            //            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //            //  read response at get the access code to post the on behalf of the user
            //            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //            {
            //                StreamReader reader = new StreamReader(response.GetResponseStream());

            //                string vals = reader.ReadToEnd();

            //                foreach (string token in vals.Split('&'))
            //                {

            //                    tokens.Add(token.Substring(0, token.IndexOf("=")),
            //                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
            //                }
            //            }

            //            string access_token = tokens["access_token"];// acess token never expire but user can deauthrize the app

            //            var client = new FacebookClient(access_token); //acess token which we tailored up in the code

            //            object objFB = client.Post("/me/feed", new { message = "You have successfully achieved: " + lblLevel.Text.Trim() + " (LevelsPro)" });


            //           // object objFB = client.Post("/me/feed", new { message = "You have successfully achieved: " + lblLevel.Text.Trim() + " (LevelsPro)" });

            //            if (objFB != null)
            //            {
            //                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            //                // make collection editable
            //                isreadonly.SetValue(this.Request.QueryString, false, null);
            //                // remove
            //                this.Request.QueryString.Remove("from");

            //                //Request.QueryString.Clear();
            //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully shared on facebook.')</script>", false);
            //            }
            //            else
            //            {
            //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share on facebook, please try later!')</script>", false);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share same status on facebook, please try again later!')</script>", false);
            //    }
            //}

            //protected void ibtnTwitter_Click(object sender, ImageClickEventArgs e)
            //{
            //    if (auth.IsAuthorized)
            //    {
            //        TweetLevel();
            //    }
            //    else
            //    {
            //        Uri objUri;
            //        if (Request.Url.PathAndQuery.Contains("fromtwitter") == false)
            //        {
            //            objUri = new Uri(Request.Url + "?fromtwitter=1");
            //        }
            //        else
            //        {
            //            objUri = Request.Url;
            //        }

            //        auth.BeginAuthorization(objUri);
            //    }

            //    //var twitterCtx = new TwitterContext(auth);
            //    ////if (!Page.IsPostBack)
            //    ////{
            //    //    auth.CompleteAuthorization(Request.Url);
            //    ////}

            //    ////var accounts =
            //    ////from acct in twitterCtx.Account
            //    ////where acct.Type == AccountType.VerifyCredentials
            //    ////select acct;

            //    //twitterCtx = auth.IsAuthorized ? new TwitterContext(auth) : new TwitterContext(auth);

            //    //auth.BeginAuthorization(Request.Url);


            //    //twitterCtx.UpdateStatus("My tweet seventh from levelspro by Ahmed Hassan");
        }

        protected void btnGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizSelection.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgressDetails.aspx");
        }

        //private void TweetLevel()
        //{
        //    try
        //    {
        //        using (var twitterCtx = new TwitterContext(auth))
        //        {
        //            //var twitterCtx = new TwitterContext(auth);

        //            //by atizaz var tweet = twitterCtx.UpdateStatus("You have achieved " + lblLevel.Text + " (LevelsPro)");

        //            if (tweet != null)
        //            {

        //                //Request.QueryString.Clear();
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully tweeted.')</script>", false);
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet, please try later!')</script>", false);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet same status on twitter, please try again later!')</script>", false);
        //    }

        //    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        //    // make collection editable
        //    isreadonly.SetValue(this.Request.QueryString, false, null);
        //    // remove
        //    this.Request.QueryString.Remove("fromtwitter");
        //}

        //[System.Web.Services.WebMethod]
        //public static void AbandonSession()
        //{
        //    HttpContext.Current.Session.Abandon();
        //}

        protected void lbtnAwards_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayerPanel/ViewAwards.aspx", false);
        }

        protected void btnMessages_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayerPanel/Messages.aspx", false);
        }

        protected void btnViewForums_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayerPanel/PlayerForums.aspx", false);
        }

        protected void btnCong_Click(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }
        protected void lnkbtnLogout_Click1(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
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

        protected void lkbChang_Click(object sender, EventArgs e)
        {
            mpeChangePassDiv.Show();
        }

       

       

       
    }
}