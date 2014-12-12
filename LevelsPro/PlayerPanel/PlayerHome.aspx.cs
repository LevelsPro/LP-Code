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
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class PlayerHome : AuthorizedPage
    {
        private string usr, pwd, role,pageURL;
        public DataSet dsaward;
        private ILog log;
        // private WebAuthorizer auth; // twitter Authorizer
        protected void Page_Load(object sender, EventArgs e)
        {

            System.Uri url = Request.Url;
            pageURL = url.AbsolutePath.ToString();
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                       
            {
                if (Convert.ToInt32(Session["FirstTimeLogin"]) == 1)
                {
                    UserInfoBLL userinfo = new UserInfoBLL();
                    Common.User users = new Common.User();
                    users.UserName = Session["username"].ToString();

                    userinfo.User = users;
                    try
                    {
                        userinfo.Invoke();
                        DataSet ds = userinfo.ResultSet;

                        Session["UserCurrentLevel"] = Convert.ToInt32(ds.Tables[0].Rows[0]["current_level"].ToString());
                        Session["LevelPosition"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Level_Position"].ToString());
                        Session["PlayerLevelImage"] = ds.Tables[0].Rows[0]["ImageName"].ToString();
                        Session["AllLevelsPlayer"] = ds.Tables[1];

                        
                        Session["userrole"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                        Session["rolename"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                        Session["TipsLinkage"] = "false";
                       
                        Session["UserRoleID"] = ds.Tables[0].Rows[0]["U_RolesID"];
                        Session["role"] = "Player";
                        Session["checkforlogout"] = 0;
                        if (ds.Tables[0].Rows[0]["Display_Name"].ToString() == "1")
                        {
                            Session["displayname"] = ds.Tables[0].Rows[0]["U_FirstName"].ToString() + ' ' + ds.Tables[0].Rows[0]["U_LastName"].ToString();
                        }
                        else
                        {
                            Session["displayname"] = ds.Tables[0].Rows[0]["U_NickName"].ToString();
                        }

                        Session["siteid"] = ds.Tables[0].Rows[0]["U_SiteID"];
                        Session["sitename"] = ds.Tables[0].Rows[0]["SiteName"].ToString();


                        Session["U_Points"] = ds.Tables[0].Rows[0]["U_Points"];
                     

                        if (ds.Tables[0].Rows[0]["ManagerEmail"] != null)
                        {
                            Session["ManagerEmail"] = ds.Tables[0].Rows[0]["ManagerEmail"];
                        }
                        if (ds.Tables[0].Rows[0]["ManagerID"] != null)
                        {
                            Session["ManagerID"] = ds.Tables[0].Rows[0]["ManagerID"];
                        }
                    }
                    catch (Exception ex)
                    {

                        
                        throw ex;
                    }
                }

                Session["FirstTimeLogin"] = 1;

                
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
                    ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                    myContent.FindControl("noti").Visible = true;

                }
                else
                {
                    ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                    myContent.FindControl("noti").Visible = false;
                 
                }


                lblScore.Text = Session["U_Points"].ToString();
                Session["U_Points"] = lblScore.Text;
                


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


              

                if (!IsPostBack)
                {
                   
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        lblFullName.Text = Session["displayname"].ToString();                        

                        if (Session["MyCulture"] != null && Session["MyCulture"].ToString() != "")
                        {
                            if (Session["MyCulture"].ToString() == "fr-FR")
                            {
                                
                            }
                            else
                            {
                                
                            }
                        }

                        
                        lblUserRole.Text = Session["rolename"].ToString();
                        
                        if (Session["userid"] != null && Session["userid"].ToString() != "")
                        {
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

                            dsaward = award.ResultSet;
                          
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

                            
                            if (award.ResultSet != null && award.ResultSet.Tables.Count > 0 && award.ResultSet.Tables[0] != null && award.ResultSet.Tables[0].Rows.Count > 0)
                            {
                              
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
                                            
                                        }
                                    }
                                }
                            }

                            #endregion
                            /////////////////////

                            
                               
                            if(Convert.ToInt32( Session["LevelPosition"]) > 0)
                            {
                                Session["CurLevel"] = Session["UserCurrentLevel"].ToString();
                                LevelStar.ImageUrl = "images/star_yellow_" + Session["LevelPosition"].ToString() + ".png";
                                


                                TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();

                                
                                Common.User user = new Common.User();

                                user.UserID = Convert.ToInt32(Session["userid"]);
                                user.CurrentLevel = Convert.ToInt32(Session["UserCurrentLevel"]);//
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


                                        
                                        if (dTpopUp.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(dTpopUp.Rows[0]["popup_showed"]) == 0)
                                            {
                                                #region Checking Level Name and bonus
                                                
                                                DataTable dTFulllevel =(DataTable)Session["AllLevelsPlayer"];
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
                            
                        }

                        if (Session["PlayerLevelImage"] != null || !Session["PlayerLevelImage"].ToString().Equals(""))
                        {

                            string imagepath = Session["PlayerLevelImage"].ToString();
                               Session["imagePath"] = path + imagepath;
                                MapImage.Src = path + imagepath;
                            }
                            else
                            {
                                MapImage.Src = "images/map.png";
                            }
                        

                        DataSet ds = dsaward;

                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                        {
                            DataView dv = ds.Tables[0].DefaultView;

                            dv.RowFilter = "Percentage >= 100 OR Award_Manual ='True'";// OR AchievedAward = 'yes'

                            DataTable dtAw = dv.ToTable();

                            if (dtAw != null && dtAw.Rows.Count > 0)
                            {
                                
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
                        catch (Exception ex)
                        {
                            ExceptionUtility.ExceptionLogString(ex,Session);
                            Session["ExpLogString"]+= " Aditional Info: The page has been redirected to login";
                            log.Error(Session["ExpLogString"]);
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, log,exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
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

        }

        protected void btnGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuizSelection.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProgressDetails.aspx");
        }

        
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
            //if (Session.)
            //{
               
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
            //}
        }

        protected void lkbChang_Click(object sender, EventArgs e)
        {
            mpeChangePassDiv.Show();
        }

       

       

       
    }
}