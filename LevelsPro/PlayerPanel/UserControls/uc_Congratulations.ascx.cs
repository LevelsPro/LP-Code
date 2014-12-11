using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Update;
using System.Configuration;
using System.Net;
using System.IO;
using Facebook;
using System.Reflection;
using LinqToTwitter;
using BusinessLogic.Insert;
using BusinessLogic.Select;
using System.Data;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_Congratulations : System.Web.UI.UserControl
    {
        public static String Name = "";
        public static String Level = "";
        public static String LevelID = "";
        public static String Role = "";
        public static String Bonus = "";
        private WebAuthorizer auth;

        public void LoadData(String level, String levelID, String bonus1)
        {
            Name = Session["displayname"].ToString();
            Role = Session["rolename"].ToString();
            Level = level;
            LevelID = levelID;
            Bonus = bonus1;
            lblName.Text = Name;
            lblRole.Text = Role;
            lblBonus1.Text = Bonus;
            lblLevel.Text = Level;
            LevelStar.ImageUrl = "../images/star_yellow_" + level.Substring(6) + ".png";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            FailureDiv.Visible = false;
            successDiv.Visible = false;
            TweeterFailureDiv.Visible = false;
            TweeterSuccessDiv.Visible = false;

            #region Unused Facebook & Twitter Code
            /*
            if (Session["check1"]!=null && Convert.ToInt32(Session["check1"]) > 0)
            {
                Session["check1"] = "0";
                imgbtnFacebook_Click(null, null);
            }
            else if (Session["check"] != null && Convert.ToInt32(Session["check"]) > 0)
            {
                Session["check"] = "0";
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
            //    //auth.CompleteAuthorization(Request.Url);
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



            ///////////////////////////////////////////////by atizaz////////////////

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
                #region Old Updating Level Logic
                /*
                PopupShowedUpdateBLL popup = new PopupShowedUpdateBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["userid"]);
                user.CurrentLevel = Convert.ToInt32(LevelID);
                popup.User = user;
                try
                {
                    popup.Invoke();
                }
                catch (Exception ex)
                {
                }
                //Literal lblScore = (Literal)this.Parent.FindControl("lblScore");
                if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                {
                    Session["U_Points"] = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(lblBonus1.Text.Trim())).ToString();
                }
                else
                {
                    Session["U_Points"] = lblBonus1.Text.Trim();
                }
                */
                #endregion

                #region New PopUpShowed=1 Update Logic (by Haseeb)
                UpdatePopup_LevelPerformanceBLL popUp = new UpdatePopup_LevelPerformanceBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(Session["userid"]);
                user.CurrentLevel = Convert.ToInt32(LevelID);

                popUp.User = user;
                try
                {
                    popUp.Invoke();
                }
                catch (Exception ex)
                {
                }

                ////Button lblScore = (Button)this.Parent.FindControl("lblScore");
                //if (Session["U_Points"] != null && Session["U_Points"].ToString() != "")
                //{
                //    Session["U_Points"] = (Convert.ToInt32(Session["U_Points"]) + Convert.ToInt32(lblBonus1.Text.Trim())).ToString();
                //}
                //else
                //{
                //    Session["U_Points"] = lblBonus1.Text.Trim();
                //}
                #endregion

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
                    _message.MessageSubject = "Level achieved";

                    String MessageBody = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully achieved Level " +
                                        (Convert.ToInt32(Level.Substring(6))).ToString() + " at " + System.DateTime.Now.ToString();


                    _message.MessageText = MessageBody;
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
                _message.MessageSubject = "Level achieved";
                String Message = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                        + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has successfully achieved Level " +
                                        (Convert.ToInt32(Level.Substring(6))).ToString() + " at " + System.DateTime.Now.ToString();

                _message.MessageText = Message;
                try
                {
                    _messageInsert.messages = _message;
                    _messageInsert.Invoke();
                }
                catch (Exception ex)
                {
                }




                //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeCongratsMessageDiv");
                //mpe.Hide();
                //PlayerHome callp = new PlayerHome();
                //callp.Page_Load(null, null);
                Response.Redirect("PlayerHome.aspx", false);
            }
        }

    }
}