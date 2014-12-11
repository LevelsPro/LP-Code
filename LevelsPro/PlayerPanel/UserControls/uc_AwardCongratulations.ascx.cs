using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Update;
using AjaxControlToolkit;
using LinqToTwitter;
using System.Net;
using System.IO;
using System.Configuration;
using Facebook;
using System.Reflection;
using BusinessLogic.Insert;
using BusinessLogic.Select;
using System.Data;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_AwardCongratulations : System.Web.UI.UserControl
    {
        public static String Name = "";
        public static int AwardID = 0;
        public static String AwardName = "";
        //public static String Role = "";
        public static String Bonus = "";
        private WebAuthorizer auth;
        private TwitterContext twitterCtx;
       static int check = 0;

        public void LoadData(int awardid, String awardname, string type)
        {
            Name = Session["displayname"].ToString();
            //Role = Session["rolename"].ToString();
            AwardID = awardid;
            //LevelID = levelID;
            AwardName = awardname;
            //Bonus = bonus1;
            lblName.Text = Name;
            //lblRole.Text = Role;
            // lblBonus1.Text = Bonus;
            lblAward.Text = AwardName;
            Session["Type"] = type;
            awardtext.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FailureDiv.Visible = false;
            successDiv.Visible = false;
            TweeterFailureDiv.Visible = false;
            TweeterSuccessDiv.Visible = false;

            #region Unused Facebook & Twitter Code
            /*
            //if (check > 0)
            //{
            //    imgbtnFacebook_Click(null, null);
            //}
            if (Session["check12"] != null && Convert.ToInt32(Session["check12"]) > 0)
            {
                Session["check12"] = "0";
                imgbtnFacebook_Click(null, null);
            }
            else if (Session["checkss"] != null && Convert.ToInt32(Session["checkss"]) > 0)
            {
                Session["checkss"] = "0";
                imgbtnFacebook_Click(null, null);
            }
            if (Request.QueryString["from"] != null && Request.QueryString["from"].ToString() == "sharebutton") // Needed for facebook share (Hassan)
            {
                imgbtnFacebook_Click(null, null);
            }

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

            //if (Request.QueryString["fromtwitter"] != null && Request.QueryString["fromtwitter"].ToString() == "1") // Needed for Twitter tweet (Hassan)
            //{
            //    imgbtnTwiter_Click(null, null);
            //}

            */
            #endregion

        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                if (Session["Type"].ToString() == "manual")
                {
                    UserManualAwardPopupUpdateBLL popup = new UserManualAwardPopupUpdateBLL();
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
                    }


                    //for Message sending to Player manager and Admins
                    UserViewBLL _adminusers = new UserViewBLL();
                    Common.User adminuser = new Common.User();

                    adminuser.Where = "where U_SysRole = 'Admin'";
                    _adminusers.User = adminuser;

                    try
                    {
                        _adminusers.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                    MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
                    Common.Messages _message = new Common.Messages();

                    foreach (DataRow dr in _adminusers.ResultSet.Tables[0].Rows)
                    {
                        _message.FromUserID = Convert.ToInt32(Session["UserID"]);
                        _message.ToUserID = Convert.ToInt32(dr["UserID"]);
                        _message.MessageSubject = "Award achieved";

                        String Message = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully won " +
                                        AwardName + "  at " + System.DateTime.Now.ToString();

                        _message.MessageText = Message;
                        try
                        {
                            _messageInsert.messages = _message;
                            _messageInsert.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }

                    }


                    _message.FromUserID = Convert.ToInt32(Session["UserID"]);
                    if (Session["ManagerID"] != null)
                    {
                        _message.ToUserID = Convert.ToInt32(Session["ManagerID"]);
                    }
                    _message.MessageSubject = "Award achieved";

                    String MessageBody = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully won " +
                                        AwardName + "  at " + System.DateTime.Now.ToString();

                    _message.MessageText = MessageBody;
                    try
                    {
                        _messageInsert.messages = _message;
                        _messageInsert.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }




                    ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeAwardCongratsMessageDiv");
                    mpe.Hide();
                    Response.Redirect("PlayerHome.aspx", false);
                }
                else
                {
                    UserAwardAchievedUpdatePopupBLL popup = new UserAwardAchievedUpdatePopupBLL();
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
                    }


                    //for Message sending to Player manager and Admins
                    UserViewBLL _adminusers = new UserViewBLL();
                    Common.User adminuser = new Common.User();

                    adminuser.Where = "where U_SysRole = 'Admin'";
                    _adminusers.User = adminuser;

                    try
                    {
                        _adminusers.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                    MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
                    Common.Messages _message = new Common.Messages();

                    foreach (DataRow dr in _adminusers.ResultSet.Tables[0].Rows)
                    {
                        _message.FromUserID = Convert.ToInt32(Session["UserID"]);
                        _message.ToUserID = Convert.ToInt32(dr["UserID"]);
                        _message.MessageSubject = "Award achieved";
                        String Message = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully won " +
                                        AwardName + "  at " + System.DateTime.Now.ToString();

                        _message.MessageText = Message;
                        try
                        {
                            _messageInsert.messages = _message;
                            _messageInsert.Invoke();
                        }
                        catch (Exception ex)
                        {
                        }

                    }


                    _message.FromUserID = Convert.ToInt32(Session["UserID"]);
                    if (Session["ManagerID"] != null)
                    {
                        _message.ToUserID = Convert.ToInt32(Session["ManagerID"]);
                    }
                    _message.MessageSubject = "Award achieved";

                    String MessageMain = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully won " +
                                        AwardName + "  at " + System.DateTime.Now.ToString();

                    _message.MessageText = MessageMain;
                    try
                    {
                        _messageInsert.messages = _message;
                        _messageInsert.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }





                    ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeAwardCongratsMessageDiv");
                    mpe.Hide();
                    Response.Redirect("PlayerHome.aspx", false);
                }
            }
        }

    }
}