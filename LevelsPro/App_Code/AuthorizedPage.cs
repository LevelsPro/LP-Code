using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.IO;
using System.Data.SqlTypes;
using System.Collections.Generic;
using BusinessLogic.Select;
using System.Threading;
using System.Globalization;
namespace LevelsPro.App_Code
{
    public class AuthorizedPage : System.Web.UI.Page
    {
        public AuthorizedPage()
        {
        }
        //public ArrayList Roles(string rol)
        //{
        //    ArrayList rolelist = new ArrayList();            
        //    XmlDocument doc = new XmlDocument();
        //    XmlReader xtr = new XmlTextReader(File.OpenRead(Server.MapPath("~\\" + rol.Trim() +"Panel"+ "\\web.config")));
        //    doc.Load(xtr);
        //    xtr.Close();
        //    XmlElement root = doc.DocumentElement;
        //    XmlNodeList nodes = root.GetElementsByTagName("authorization");
        //    if (nodes.Count > 0)
        //    {
        //        for (int i = 0; i < nodes.Count; i++)
        //        {
        //            XmlNodeList allowNodes = ((XmlElement)(nodes.Item(i))).GetElementsByTagName("allow");
        //            for (int j = 0; j < allowNodes.Count; j++)
        //            {
        //                XmlAttributeCollection roleColl = allowNodes.Item(j).Attributes;
        //                XmlAttribute role = (XmlAttribute)roleColl.GetNamedItem("roles");
        //                string[] temp = role.Value.Split(',');
        //                for (int k = 0; k < temp.Length; k++)
        //                    rolelist.Add(temp[k]);
        //            }
        //        }
        //    }
        //    return rolelist;
        //}    

        //public bool Authorization(ArrayList roles,string userRole)
        //{
        //    foreach (string role in roles)
        //    {
        //        if (role.Trim().Equals(userRole.Trim()))
        //        return true;
        //    }            
        //    return false;
        //}


        public DataSet UserData(string username)//, string password)
        {
            UserInfoBLL userinfo = new UserInfoBLL();
            Common.User user = new Common.User();
            user.UserName = username;
            //user.UserPassword = password;
            //user.SiteID = siteid;
            userinfo.User = user;
            try
            {
                userinfo.Invoke();
            }
            catch (Exception ex)
            {
            }
            return userinfo.ResultSet;
        }



        public const string LanguageDropDownName = "ddlLanguage";

        /// <summary>
        /// The name of the PostBack event target field in a posted form.  You can use this to see which
        /// control triggered a PostBack:  Request.Form[PostBackEventTarget] .
        /// </summary>
        public const string PostBackEventTarget = "__EVENTTARGET";

        /// <SUMMARY>
        /// Overriding the InitializeCulture method to set the user selected
        /// option in the current thread. Note that this method is called much
        /// earlier in the Page lifecycle and we don't have access to any controls
        /// in this stage, so have to use Form collection.
        /// </SUMMARY>
        protected override void InitializeCulture()
        {
            ///<remarks><REMARKS>
            ///Check if PostBack occured. Cannot use IsPostBack in this method
            ///as this property is not set yet.
            ///</remarks>
            if (Request[PostBackEventTarget] != null)
            {
                string controlID = Request[PostBackEventTarget];

                if (controlID.Equals(LanguageDropDownName))
                {
                    string selectedValue =
                           Request.Form[Request[PostBackEventTarget]].ToString();

                    switch (selectedValue)
                    {
                        
                        case "0": SetCulture("en-US", "en-US");
                            break;                        
                        case "1": SetCulture("fr-FR", "fr-FR");
                            break;
                        case "2": SetCulture("es-ES", "es-ES");
                            break;
                        default: break;
                    }
                }
            }
            ///<remarks>
            ///Get the culture from the session if the control is tranferred to a
            ///new page in the same application.
            ///</remarks>
            if (Session["MyUICulture"] != null && Session["MyCulture"] != null)
            {
                Thread.CurrentThread.CurrentUICulture = (CultureInfo)Session["MyUICulture"];
                Thread.CurrentThread.CurrentCulture = (CultureInfo)Session["MyCulture"];
            }
            base.InitializeCulture();
        }


        /// <Summary>
        /// Sets the current UICulture and CurrentCulture based on
        /// the arguments
        /// </Summary>
        /// <PARAM name="name"></PARAM>
        /// <PARAM name="locale"></PARAM>
        protected void SetCulture(string name, string locale)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale);
            ///<remarks>
            ///Saving the current thread's culture set by the User in the Session
            ///so that it can be used across the pages in the current application.
            ///</remarks>
            Session["MyUICulture"] = Thread.CurrentThread.CurrentUICulture;
            Session["MyCulture"] = Thread.CurrentThread.CurrentCulture;
        }

    }

}