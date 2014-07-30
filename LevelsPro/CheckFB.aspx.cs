using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;
using Facebook;

namespace LevelsPro
{
    public partial class CheckFB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckAndLoadAccessToken();
        }

        public void CheckAndLoadAccessToken()
        {
            #region MY CODE
            //string code = "";

            //if (Request.QueryString["code"] == null ||
            //    Request.QueryString["code"].Length == 0)
            //{
            //    //CSRF protection
            //    Session["state"] = Guid.NewGuid().ToString();
            //    string dialog_url = "https://www.facebook.com/dialog/oauth?client_id=" + "384460171664774" + "&response_type=code&scope=" + "email" + "&redirect_uri=" + HttpUtility.UrlEncode("http://localhost:2936/Index.aspx") + "&state=" + HttpUtility.UrlEncode(Session["state"].ToString());

            //    Response.Redirect(dialog_url);
            //}
            //else
            //{
            //    code = Request.QueryString["code"];
            //}

            //if (Session["state"] != null &&
            //    Request.QueryString["state"] != null &&
            //    Session["state"].ToString() == Request.QueryString["state"].ToString())
            //{
            //    string token_url = "https://graph.facebook.com/oauth/access_token?" +
            //        "client_id=" + "384460171664774" +
            //        "&redirect_uri=" + HttpUtility.UrlEncode("http://localhost:2936/Index.aspx") +
            //        "&client_secret=" + "3599051a3efef1f9a17209ed43b1e625" + "&code=" + code;

            //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(token_url);
            //    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            //    StreamReader rdr = new StreamReader(res.GetResponseStream());

            //    string access_token_value = rdr.ReadToEnd();

            //    //Sample Token
            //    //access_token=AAAD5lZAaiLXQBAC5CuLh1ZBmUXiZBDr7basvPznXYuIPVTh7aGT92Q0HLTyMsOs0MBOWfU9EeBtKy7aKHV4mfqHard2afR9Qyga5znUtgZDZD&expires=5120611

            //    string[] access_token_pieces = access_token_value.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (access_token_pieces.Length > 1)
            //    {
            //        string access_token = access_token_pieces[1];
            //        //FacebookApplication oo = new FacebookApplication();
            //        //FacebookUserManager us = new FacebookUserManager();                    
            //        var client = new FacebookClient(access_token);

            //        dynamic result = client.Get("me", new { fields = "id,name,email" });

            //        string FacebookID = result.id;
            //        string FacebookName = result.name;
            //        string FacebookEmail = result.email;

            //        string strPostUrl = "https://www.facebook.com/dialog/feed?app_id=" + "384460171664774" + "&redirect_uri=" + "http://localhost:2936/Index.aspx" + "&message=Hello Hassan. I like this new API.";
            //        //string strPostUrl = "https://www.facebook.com/" + "FacebookID"/feed?app_id=" + "384460171664774" + "&redirect_uri=" + "http://localhost:2936/Index.aspx" + "&message=Hello Hassan. I like this new API.";

            //        Response.Redirect(strPostUrl);
            //        //client.Post("/me/feed", new { message = "Testing from Code" });
            //    }
            #endregion

            string app_id = ConfigurationManager.AppSettings["FacebookAppID"].ToString();//app id we created
            string app_secret = ConfigurationManager.AppSettings["FacebookAppSecretID"].ToString();// app secret
            string scope = ConfigurationManager.AppSettings["FacebookScope"].ToString();// the permission to grant me for the facebook user

            if (Request["code"] == null) // ask facebook for the code
            {
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
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

                client.Post("/me/feed", new { message = "Levelspro21" });
            }
        }
    }
}