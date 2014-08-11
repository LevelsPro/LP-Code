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
                                        (Convert.ToInt32(Level.Substring(6)) - 1).ToString() + " at " + System.DateTime.Now.ToString();


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
                                        (Convert.ToInt32(Level.Substring(6)) - 1).ToString() + " at " + System.DateTime.Now.ToString();

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

        protected void imgbtnFacebook_Click(object sender, ImageClickEventArgs e)
        {
            int fbck = 0;
            try
            {
                
               // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script type='text/javascript'>Nothing(); function Nothing(){alert('Nothing');} </script>", false);
                string app_id = ConfigurationManager.AppSettings["FacebookAppID"].ToString();//app id we created
                string app_secret = ConfigurationManager.AppSettings["FacebookAppSecretID"].ToString();// app secret
                string scope = ConfigurationManager.AppSettings["FacebookScope"].ToString();// the permission to grant me for the facebook user

                if (Request["code"] == null) // ask facebook for the code
                {
                    Response.Redirect(string.Format(
                        "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                        app_id, Request.Url.AbsoluteUri + "?from=sharebutton", scope));
                }
                else
                {
                    Session["check1"] = 0;
                    fbck++;
                    Dictionary<string, string> tokens = new Dictionary<string, string>(); //parameters returned from facebook

                    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //  read response at get the access code to post the on behalf of the user
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());

                        string vals = reader.ReadToEnd();

                        foreach (string token in vals.Split('&'))
                        {

                            tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    }

                    string access_token = tokens["access_token"];// acess token never expire but user can deauthrize the app

                    var client = new FacebookClient(access_token); //acess token which we tailored up in the code

                    object objFB = client.Post("/me/feed", new { message = "You have successfully achieved Level: " + (Convert.ToInt32(Level.Substring(6))-1) + " (LevelsPro)" });
                    //object objFB = client.Post("/me/feed", new { message = "You have successfully achieved: " + lblLevel.Text.Trim() + " (LevelsPro)" });
                    if (objFB != null)
                    {
                        Session["check"] = "0";
                        Session["check1"] = "0";
                        PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        isreadonly.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Remove("from");

                        //Request.QueryString.Clear();
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully shared on facebook.')</script>", false);
                        successDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share on facebook, please try later!')</script>", false);
                        FailureDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share same status on facebook, please try again later!')</script>", false);
                FailureDiv.Visible = true;
                if (fbck > 0)
                {
                    Session["check"] = "1";
                    Response.Redirect("PlayerHome.aspx");
                }
                Session["check1"] = "1";
                ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                mpe.Show();
            }
        }

        protected void imgbtnTwiter_Click(object sender, ImageClickEventArgs e)
        {

            Session["windowcheck"] = "1";
            Response.Redirect("PlayerHome.aspx");

            //if (auth.IsAuthorized)
            //{
            //    TweetLevel();
            //}
            //else
            //{
            //    Uri objUri;
            //    if (Request.Url.PathAndQuery.Contains("fromtwitter") == false)
            //    {
            //        objUri = new Uri(Request.Url + "?fromtwitter=1");
            //    }
            //    else
            //    {
            //        objUri = Request.Url;
            //    }

            //    auth.BeginAuthorization(objUri);
            //}
        }

        private void TweetLevel()
        {
            try
            {
                using (var twitterCtx = new TwitterContext(auth))
                {
                    //var twitterCtx = new TwitterContext(auth);

                    var tweet = twitterCtx.UpdateStatus("You have achieved " + lblLevel.Text + " (LevelsPro)");

                    if (tweet != null)
                    {

                        //Request.QueryString.Clear();
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully tweeted.')</script>", false);
                        TweeterSuccessDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet, please try later!')</script>", false);
                        TweeterFailureDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet same status on twitter, please try again later!')</script>", false);
                TweeterFailureDiv.Visible = true;
                ModalPopupExtender mpe = this.Parent.FindControl("mpeCongratsMessageDiv") as ModalPopupExtender;
                mpe.Show();
            }

            PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            // make collection editable
            isreadonly.SetValue(this.Request.QueryString, false, null);
            // remove
            this.Request.QueryString.Remove("fromtwitter");
        }
    }
}