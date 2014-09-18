using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace LevelsPro
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            Session["username"] = null;
            Session.Clear();
            Session.RemoveAll(); 

        }

        //void Application_Error(object sender, EventArgs e)
        //{
            
        //    Exception exp = Server.GetLastError();
        //    if (exp is HttpUnhandledException)
        //    {
        //        HttpUnhandledException exc = exp as HttpUnhandledException;
        //        if (exc.Message.Contains("404"))
        //        {
        //            Server.Transfer("~/ErrorPages/ErrorPage404.aspx", true);
        //        }
        //        else
        //        {
        //            Server.Transfer("~/ErrorPages/DefaultErrorPage.aspx", true);
        //        }
        //    }
        //    else if (exp.Message.Contains("File"))
        //    { }
        //    Server.ClearError();
        //}

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
            
            Session["username"] = null;
            Session.Clear();
            Session.RemoveAll();
            

        }

    }
}
