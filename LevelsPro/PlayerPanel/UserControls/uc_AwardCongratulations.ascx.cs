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
            if (check > 0)
            {
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


        protected void imgbtnFacebook_Click(object sender, ImageClickEventArgs e)
        {
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
                            app_id, Request.Url.AbsoluteUri, scope));
                   
                //    Response.Redirect(string.Format(
                //       
                //        app_id, Request.Url.AbsoluteUri + "?from=sharebutton", scope));
                }
                else
                {
                    check = 0;
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

                    object objFB = client.Post("/me/feed", new { message = "You have successfully achieved Award : " + lblAward.Text + " (LevelsPro)" });
                    //object objFB = client.Post("/me/feed", new { message = "You have successfully achieved: " + lblLevel.Text.Trim() + " (LevelsPro)" });
                    if (objFB != null)
                    {
                        PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                        // make collection editable
                        isreadonly.SetValue(this.Request.QueryString, false, null);
                        // remove
                        this.Request.QueryString.Remove("from");

                        //Request.QueryString.Clear();
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully shared on facebook.')</script>", false);
                        successDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share on facebook, please try later!')</script>", false);
                        FailureDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot share same status on facebook, please try again later!')</script>", false);
                FailureDiv.Visible = true;
                check++;
                ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
                mpe.Show();
            }
           
        }

        protected void imgbtnTwiter_Click(object sender, ImageClickEventArgs e)
        {
            //PlayerHome player = new PlayerHome();
           // player.twittershow();
           // String URL = "https://twitter.com/intent/tweet?source=webclient&text=you+have+sucessfully+achieved+award+.+via+%40LevelsPro";
           // imgbtnTwiter.Attributes.Add("OnClientClick", "javaScript: return windowpop('" + URL + "');");

            Session["windowcheck"] = "1";
            Response.Redirect("PlayerHome.aspx");
            
            //// imgbtnTwiter.OnClientClick = "javascript: windowpop('" + URL + "')";
            //Page page = HttpContext.Current.CurrentHandler as Page;
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "windowpop('" + URL + "');", true);
           
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
        }

        private void TweetLevel()
        {
            try
            {
                using (var twitterCtx = new TwitterContext(auth))
                {
                    //var twitterCtx = new TwitterContext(auth);

                    var tweet = twitterCtx.UpdateStatus("You have achieved " + lblAward.Text + " (LevelsPro)");

                    if (tweet != null)
                    {

                        //Request.QueryString.Clear();
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Success", "<script>alert('You have successfully tweeted.')</script>", false);
                        TweeterSuccessDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }
                    else
                    {
                        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet, please try later!')</script>", false);
                        TweeterFailureDiv.Visible = true;
                        ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
                        mpe.Show();
                    }

                }
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Failure", "<script>alert('Cannot tweet same status on twitter, please try again later!')</script>", false);
                TweeterFailureDiv.Visible = true;
                ModalPopupExtender mpe = this.Parent.FindControl("mpeAwardCongratsMessageDiv") as ModalPopupExtender;
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