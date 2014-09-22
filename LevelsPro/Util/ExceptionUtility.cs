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
        private static bool LoginError;
        private static string LoginErrorMessage;
        private static Dictionary<string, string> playerRedirectionLookup;
        
        //this dictionary will be used to keep track of a bad link,
        //in case of continous failures, different redirection strategy will be used.
        private static Dictionary<string, int> linkExceptionCount;
        #endregion

        #region Constructor

        static ExceptionUtility()
        {
            //to be used incase error messaged needs to be displayed on login page
            LoginError = false;
            LoginErrorMessage = string.Empty;

            playerRedirectionLookup = new Dictionary<string, string>() 
            {
                {"/PlayerPanel/PlayerHome.aspx","~/Index.aspx"},
                {"/PlayerPanel/QuizSelection.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/MatchPlay.aspx","/PlayerPanel/QuizSelection.aspx"},
                {"/PlayerPanel/QuizPlay.aspx","/PlayerPanel/QuizSelection.aspx"},
                {"/PlayerPanel/QuizResult.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewAwards.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewContestAwards.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewContests.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewLevelAwards.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewManagerAwards.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewMilestones.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ViewPerformanceAwards.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/RedeemPoints.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ProgressDetails.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ContestDetails.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/ForumDetails.aspx","/PlayerPanel/PlayerHome.aspx"}
            };

            linkExceptionCount = new Dictionary<string, int>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs appropriate behavior depending upon the role.
        /// in-case of 3 exceptions with local as strategy from a page, 
        /// the page would be redirected to page as directed by the lookup
        /// </summary>
        /// <param name="sourcePage"></param>
        /// <param name="parentPage"></param>
        /// <param name="session"></param>
        /// <param name="server"></param>
        internal static void GenerateExpResponse(string sourcePage, RedirectionStrategy redirectionStrategy, HttpSessionState session, HttpServerUtility server, HttpResponse response, Exception exp)
        {
            string role = (string)session["role"];
            ManageExceptionEntry(sourcePage);
            if (role != null)
            {
                #region Player
                if (role.ToLower().Equals(PLAYER))
                {
                    #region playerhome
                    //If the request is from playerhome.aspx
                    if (sourcePage.ToLower().Contains("home"))
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {
 
                            if (ExceptionCount(sourcePage) > 3)
                            {
                                SetLoginErrorMessage(ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                LogoutUser(sourcePage, session, response);
                            }
                            else
                            {
                                WebMessageBoxUtil.Show(ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage,false);
                            }
                        }
                        else
                        {
                            SetLoginErrorMessage(ErrorMessageUtility.homeMessage);
                            RemoveExceptionEntry(sourcePage);
                            LogoutUser(sourcePage, session, response);
                        }
                    }
                    #endregion

                    #region rest of pages
                    else
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {
                            if (ExceptionCount(sourcePage) > 3)
                            {
                                SetErrorMessage(session, ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                response.Redirect(ProvideRedirectionURL(sourcePage),false);
                            }
                            else
                            {
                                WebMessageBoxUtil.Show(ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                            RemoveExceptionEntry(sourcePage);
                            response.Redirect(ProvideRedirectionURL(sourcePage),false);
                        }

                    }
                    #endregion
                }
                #endregion
                else if (role.ToLower().Equals(MANAGER))
                {
                    // add code for managers
                }
                else if (role.ToLower().Equals(ADMIN))
                {
                    // add code for admins
                }
            }
            else
            {
                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
            }
           
        }

        internal static void CheckForErrorMessage(HttpSessionState session)
        {
            if (session["Is_Error"] != null)
            {
                if (session["Is_Error"].Equals("True"))
                {

                    WebMessageBoxUtil.Show(session["Error_Message"].ToString());
                    session["Is_Error"] = "False";
                    session["Error_Message"] = string.Empty;
                }
            }
        }

        internal static void CheckForLoginErrorMessage()
        {
            if (LoginError == true)
            {
                WebMessageBoxUtil.Show(LoginErrorMessage);
            }
            LoginError = false;
            LoginErrorMessage = string.Empty;
        }
               
        #endregion

        #region Utility Methods
        private static string ProvideRedirectionURL(string sourcePage)
        {
            string url=null;
            if (playerRedirectionLookup.ContainsKey(sourcePage))
            {
                url = playerRedirectionLookup[sourcePage];
            }
            return url;
        }

        /// <summary>
        /// Called to add entry in the log incase of local redirection.
        /// </summary>
        /// <param name="sourcePage"></param>
        private static void ManageExceptionEntry(string sourcePage)
        {
            if (linkExceptionCount.ContainsKey(sourcePage))
            {
                int value = linkExceptionCount[sourcePage];
                value++;
                linkExceptionCount[sourcePage] = value;
            }
            else
            {
                // first instance of exception.
                linkExceptionCount[sourcePage] = 1;
            }
        }

        /// <summary>
        /// Called in case of remote re-direction as a result of 3 local 
        /// redirections to remove the entry.
        /// </summary>
        /// <param name="sourcePage"></param>
        /// <returns></returns>
        private static void RemoveExceptionEntry(string sourcePage)
        {
            if (linkExceptionCount.ContainsKey(sourcePage))
            {
                linkExceptionCount.Remove(sourcePage);
                
            }
        }
       
        private static int ExceptionCount(string sourcePage)
        {
            int count = 0;
            if (linkExceptionCount.ContainsKey(sourcePage))
            {
                count = linkExceptionCount[sourcePage];
            }
            return count;
        }

        private static void LogoutUser(string sourcePage, HttpSessionState session, HttpResponse response)
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

            response.Redirect(ProvideRedirectionURL(sourcePage),false);
        }

        private static void LogError(Exception exp)
        {
            // need to add task for this later
        }

        private static void SetErrorMessage(HttpSessionState session, string message)
        {
            session["Error"] = "True";
            session["Message"] = message;
        }

        private static void SetLoginErrorMessage( string message)
        {
            LoginError = true;
            LoginErrorMessage = message;
        }
        #endregion
    }
}