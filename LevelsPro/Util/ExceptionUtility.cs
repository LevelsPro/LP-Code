using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Common.Utils;
using BusinessLogic.Update;

namespace LevelsPro.Util
{
    internal class ExceptionUtility
    {
        #region Fields

        private const string PLAYER = "player";
        private const string ADMIN = "admin";
        private const string MANAGER = "manager";

        #endregion

        #region Messages

        #region Player
        private const string homeMessage = "Due to error !! You are being logged out. \n P.S. we blame Eddie!!!";
        private const string genericMessage = "We are experiencing some issues, kindly try again in a while";
        #endregion

        #region Manager
        #endregion

        #region Admin
        #endregion

        #endregion


        #region Methods
        /// <summary>
        /// Performs appropriate behavior depending upon the role.
        /// </summary>
        /// <param name="sourcePage"></param>
        /// <param name="parentPage"></param>
        /// <param name="session"></param>
        /// <param name="server"></param>
        internal static void GenerateExpResponse(string sourcePage, string parentPage, HttpSessionState session, HttpServerUtility server,Exception exp)
        {
            string role = (string)session["role"];
            if (role.ToLower().Equals(PLAYER))
            {
                if (sourcePage.ToLower().Contains("home"))
                {
                    WebMessageBoxUtil.Show(homeMessage);
                    LogoutUser(session, server);
                }
                else
                {
                    WebMessageBoxUtil.Show(genericMessage);
                    server.Transfer(parentPage, true);
                }
            }
            else if (role.ToLower().Equals(MANAGER))
            {
                // add code for managers
            }
            else if (role.ToLower().Equals(ADMIN))
            {
                // add code for admins
            }
           
        }

        private static void LogoutUser(HttpSessionState session, HttpServerUtility server)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
            }
            session.Abandon();
            server.Transfer("~/Index.aspx");
        }

        private static void LogError(Exception exp)
        {
            // need to add task for this later
        }
        #endregion
    }
}