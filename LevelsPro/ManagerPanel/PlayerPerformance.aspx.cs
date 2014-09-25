using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using LevelsPro.App_Code;
using System.Data;
using System.Configuration;
using System.Web.UI.HtmlControls;
using LevelsPro.PlayerPanel;
using LevelsPro.Util;

namespace LevelsPro.ManagerPanel
{
    public partial class PlayerPerformance : AuthorizedPage
    {
        private static string pageURL;
        int level = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                Session["CheckForloadprogressfrompopup"] = 0;
              //  ReuseableItems.CheckForloadprogressfrompopup = 0;
                if (Request.QueryString["Base"] != null && Request.QueryString["Base"].ToString() != "" && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "" && Request.QueryString["likelihood"] != null && Request.QueryString["likelihood"].ToString() != "" && Request.QueryString["remaining"] != null && Request.QueryString["remaining"].ToString() != "")
                {
                    Session["playerid"] = Convert.ToInt32(Request.QueryString["id"]);
                    Session["likelihood"] = Request.QueryString["likelihood"];
                    Session["Base"] = Convert.ToInt32(Request.QueryString["Base"]);
                    Session["remaining"] = Convert.ToInt32(Request.QueryString["remaining"]);
                    ViewState["likelihood"] = Request.QueryString["likelihood"];
                    ViewState["remaining"] = Convert.ToInt32(Request.QueryString["remaining"]);
                    ViewState["Base"] = Convert.ToInt32(Request.QueryString["Base"]);
                    decimal percentage = 0;
                    percentage = Convert.ToDecimal(Request.QueryString["likelihood"].ToString());
                    lblLike.Text = percentage.ToString("0") + "%";
                    lblHours.Text = Convert.ToInt32(ViewState["remaining"]).ToString();
                    int Percent = Convert.ToInt32(ViewState["remaining"]) * 100 / Convert.ToInt32(ViewState["Base"]);
                    //if (percentage < 80)
                    //{
                    //System.Web.UI.HtmlControls.HtmlGenericControl div1 = (System.Web.UI.HtmlControls.HtmlGenericControl)this.FindControl("MainColor");
                    //div1.Attributes["class"] = "level-cont-red";
                    //}
                    //else if (percentage > 80 && percentage < 90)
                    //{
                    //    System.Web.UI.HtmlControls.HtmlGenericControl div1 = (System.Web.UI.HtmlControls.HtmlGenericControl)this.FindControl("MainColor");
                    //    div1.Attributes["class"] = "level-cont-yellow";
                    //}
                    //else
                    //{
                    //    System.Web.UI.HtmlControls.HtmlGenericControl div1 = (System.Web.UI.HtmlControls.HtmlGenericControl)this.FindControl("MainColor");
                    //    div1.Attributes["class"] = "level-cont-green";
                    //}



                    Session["ManagerAsscociateID"] = Request.QueryString["id"];
                    try
                    {
                        LoadData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
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
                }
                else
                {
                    try
                    {
                        LoadData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
        
        public void LoadData(int userid)
        {
           
            UserImageViewBLL UserImage = new UserImageViewBLL();
         
            Common.UserImage image = new Common.UserImage();
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
               
                lblFullName.Text = Session["displayname"].ToString();
                lblUserRole.Text = Session["rolename"].ToString();
                lblName.Text = Session["displayname"].ToString() + " - " + Resources.TestSiteResources.Team;

              

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
            }
           

            image.UserID = Convert.ToInt32(Request.QueryString["id"]);

            UserImage.UserImages= image;

            try
            {
                UserImage.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dvImage = UserImage.ResultSet.Tables[0].DefaultView;
            dvImage.RowFilter = "U_Current=1";
            DataTable dtcImage1 = new DataTable();
            dtcImage1 = dvImage.ToTable();
            if (dtcImage1 != null && dtcImage1.Rows.Count > 0 && dtcImage1.Rows[0]["Player_Thumbnail"].ToString() != "")
            {
                Image1.ImageUrl = Thumbpath + dtcImage1.Rows[0]["Player_Thumbnail"].ToString();
            }


            TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();
            Common.User user = new Common.User();

            user.UserID = userid;
           user.CurrentLevel=Convert.ToInt32(Session["LevelIDMangerUser"]);
           // user.CurrentLevel = level;
            progress.User = user;
            //user.UserID = Convert.ToInt32(user);

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
                    dlProgressDetail.DataSource = progress.ResultSet.Tables[0];
                    dlProgressDetail.DataBind();
                    // lblPlayerName.Text = progress.ResultSet.Tables[0].Rows[0]["PlayerName"].ToString();
                    //lblLevel.Text = Resources.TestSiteResources.Challengesfor + ' ' progress.ResultSet.Tables[0].Rows[0]["Level_ID"].ToString(); 
                    //lblLevel.Text = Resources.TestSiteResources.Challengesfor +' '+ progress.ResultSet.Tables[0].Rows[0]["Level_ID"].ToString(); //PlayerName
                    //lblPlayerName.Text = Resources.TestSiteResources.PlayerName +' '+ progress.ResultSet.Tables[0].Rows[0]["PlayerName"].ToString(); //PlayerName
               

            TeamPerformanceBLL team = new TeamPerformanceBLL();
           // Common.User user = new Common.User();

            user.ManagerID = Convert.ToInt32(Session["userid"]);

            team.User = user;

            try
            {
                team.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            DataView dv=team.ResultSet.Tables[0].DefaultView;
            dv.RowFilter="UserID =" +Convert.ToInt32(Request.QueryString["id"]);
            DataTable ds = dv.ToTable();
           
            if (ds != null && ds.Rows.Count > 0)
            {
                if (Convert.ToInt32(Session["CheckForloadprogressfrompopup"]) == 1)
                {
                    Session["CheckForloadprogressfrompopup"] = 0;
                    lblLike.Text = "0 %";
                }
                 
                else
                {
                    decimal percentage = 0;
                    percentage = Convert.ToDecimal(ds.Rows[0]["Likelihood"].ToString());
                    lblLike.Text = percentage.ToString("0") + "%";
                }
                lblHours.Text = ds.Rows[0]["remainingHours"].ToString();
            //    DataView dv1 = team.ResultSet.Tables[0].DefaultView;
            //    dv.RowFilter = "PlayerStatus = 'red'";
                lblPlayerName1.Text=ds.Rows[0]["PlayerName"].ToString();
                Session["userfullpointsdmanager"] = Convert.ToInt32(ds.Rows[0]["U_Points"].ToString());
               // ReuseableItems.userfullpointsdmanager =Convert.ToInt32(ds.Rows[0]["U_Points"].ToString());
                Session["playernamemanager"] = lblPlayerName1.Text;
                lblLevel1.Text = ds.Rows[0]["Role_Name"].ToString() + "- Level " + ds.Rows[0]["Level_Position"].ToString();
                level=Convert.ToInt32(ds.Rows[0]["Level_ID"]);
                Session["levelidmanager"] = level;
                MainColor.Attributes["class"] = "level-cont-" + ds.Rows[0]["PlayerStatus"].ToString().ToLower();
            }

                }
                else
                {
                   // progress.ResultSet.Tables[0].Rows[0]["CheckNoProgress"].ToString();


                    lblHours.Text = progress.ResultSet.Tables[0].Rows[0]["BaseHours"].ToString();
                    lblLike.Text = "100 %";
                    //    DataView dv1 = team.ResultSet.Tables[0].DefaultView;
                    //    dv.RowFilter = "PlayerStatus = 'red'";
                    lblPlayerName1.Text = progress.ResultSet.Tables[0].Rows[0]["PlayerName"].ToString();
                    Session["userfullpointsdmanager"] = Convert.ToInt32(progress.ResultSet.Tables[0].Rows[0]["Points"]);
                //    ReuseableItems.userfullpointsdmanager = Convert.ToInt32(progress.ResultSet.Tables[0].Rows[0]["Points"]);
                    Session["playernamemanager"] = lblPlayerName1.Text;
                    lblLevel1.Text = progress.ResultSet.Tables[0].Rows[0]["Role_Name"].ToString() + "- Level " + progress.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();
                    //level = Convert.ToInt32(ds.Rows[0]["Level_ID"]);
                    Session["levelidmanager"] = Session["LevelIDMangerUser"].ToString();
                    MainColor.Attributes["class"] = "level-cont-" + "Green".ToLower(); ;
                    dlProgressDetail.DataSource = null;
                    dlProgressDetail.DataBind();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeamPerformance.aspx",false);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlProgressDetail_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            try
            {
                Label lblCurrent = e.Item.FindControl("lblCurrent") as Label;
                Label lblStatus = e.Item.FindControl("lblStatus") as Label;
                Label lblTargetValue = e.Item.FindControl("lblTargetValue") as Label;
                Label lblname = e.Item.FindControl("lblname") as Label;

                lblname.Text = lblname.Text.Replace("X", lblTargetValue.Text);

                HtmlGenericControl span = (HtmlGenericControl)e.Item.FindControl("lblclass");
                span.Attributes["class"] = "navy-bar";
                span.Attributes["style"] = "width:" + lblCurrent.Text.Trim() + "%";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerProfile.aspx");
        }

        protected void btnMessages_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagerPanel/Messages.aspx", false);
        }

        protected void btnMes_Click(object sender, EventArgs e)
        {
            mpeComposeMessageDiv.Show();

        }

        protected void btnawrd_Click(object sender, EventArgs e)
        {
           Response.Redirect("AssignAward.aspx");
        }

        protected void dlProgressDetail_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                #region Checking Item Command
                if (e.CommandName == "ViewPopup")
                {
                    Session["chkmangerkpi"] = 1;
                    string[] arg = new string[2];
                    arg = e.CommandArgument.ToString().Split(';');
                    Session["UserKpiTargetIDManagrePanel"] = Convert.ToInt32(arg[0]);
                  //  ReuseableItems.userkpistargetidmanager = Convert.ToInt32(arg[0]);

                    string[] arg1 = new string[2];
                    arg1 = arg[1].ToString().Split('&');
                    Session["userkpiscoremanager"] = Convert.ToInt32(arg1[0]);
                   // ReuseableItems.userkpiscoremanager = Convert.ToInt32(arg1[0]);


                    string[] arg2 = new string[2];
                    arg2 = arg1[1].ToString().Split('(');
                    Session["userkpitargetmanager"] = Convert.ToInt32(arg2[0]);
                  //  ReuseableItems.userkpitargetmanager = Convert.ToInt32(arg2[0]);

                    string[] arg3 = new string[2];
                    arg3 = arg2[1].ToString().Split(')');
                    Session["userkpitextmanager"] = arg3[0];
                    //ReuseableItems.userkpitextmanager = arg3[0];

                    string[] arg4 = new string[2];
                    arg4 = arg3[1].ToString().Split('^');
                    Session["userkpiidmanager"] = Convert.ToInt32(arg4[0]);
                  //  ReuseableItems.userkpiidmanager = Convert.ToInt32(arg4[0]);

                    Session["usertargetpointsdmanager"] = Convert.ToInt32(arg4[1]);
                   // ReuseableItems.usertargetpointsdmanager = Convert.ToInt32(arg4[1]);
                    try
                    {
                        mpeViewProgressDetailsDiv.Show();
                        ucViewProgressDetails.LoadData();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}