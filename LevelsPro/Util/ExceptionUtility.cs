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
        private const string DefaultErrorPage = "~/ErrorPages/DefaultErrorPage.aspx";
        private static bool LoginError;
        private static string LoginErrorMessage;
        private static Dictionary<string, string> playerRedirectionLookup;
        private static Dictionary<string, string> ManagerRedirectionLookup;
        private static Dictionary<string, string> AdminRedirectionLookup;
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
                {"/PlayerPanel/ForumDetails.aspx","/PlayerPanel/PlayerHome.aspx"},
                {"/PlayerPanel/PlayerProfile.aspx","/PlayerPanel/PlayerHome.aspx"}
            };

            ManagerRedirectionLookup = new Dictionary<string, string>()
            {
                {"/ManagerPanel/TeamPerformance.aspx","~/Index.aspx"},
                {"/ManagerPanel/AssignAward.aspx","/ManagerPanel/TeamPerformance.aspx"},
                {"/ManagerPanel/ManagerProfile.aspx","/ManagerPanel/TeamPerformance.aspx"},
                {"/ManagerPanel/Messages.aspx","/ManagerPanel/TeamPerformance.aspx"},
                {"/ManagerPanel/PlayerPerformance.aspx","/ManagerPanel/TeamPerformance.aspx"}
            };

            AdminRedirectionLookup = new Dictionary<string, string>() 
            {
                {"/AdminPanel/AdminHome","~/Index.aspx"},
                {"/AdminPanel/AssignAwards.aspx","/AdminPanel/PlayerManagement.aspx"},
                {"/AdminPanel/AwardEdit.aspx","/AdminPanel/AwardManagement.aspx"},
                {"/AdminPanel/AwardManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/ContestManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/EditPlayer.aspx","/AdminPanel/PlayerManagement.aspx"},
                {"/AdminPanel/PlayerAward.aspx","/AdminPanel/PlayerManagement.aspx"},
                {"/AdminPanel/PlayerProgress.aspx","/AdminPanel/PlayerManagement.aspx"},
                {"/AdminPanel/PlayerRewards.aspx","/AdminPanel/PlayerManagement.aspx"},
                {"/AdminPanel/KPIEdit.aspx","/AdminPanel/KPIManagement.aspx"},
                {"/AdminPanel/KPIManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/LevelEdit.aspx","/AdminPanel/LevelManagements.aspx"},
                {"/AdminPanel/LevelGameEdit.aspx","/AdminPanel/LevelGameManagement.aspx"},
                {"/AdminPanel/LevelGameManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/LevelManagements.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/BannerConfiguration.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/Messages.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/PlayerManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/QuestionEdit.aspx","/AdminPanel/QuizManagement.aspx"},
                {"/AdminPanel/QuestionManagement.aspx","/AdminPanel/QuizManagement.aspx"},
                {"/AdminPanel/QuestionEdit.aspx","/AdminPanel/QuizManagement.aspx"},
                {"/AdminPanel/QuizManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/RewardEdit.aspx","/AdminPanel/RewardManagement.aspx"},
                {"/AdminPanel/RewardManagement.aspx","/AdminPanel/AdminHome.aspx"},
                {"/AdminPanel/RoleEdit.aspx","/AdminPanel/RoleManagement.aspx"},
                {"/AdminPanel/RoleManagement.aspx","/AdminPanel/AdminHome.aspx"},



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
 
                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetLoginErrorMessage(ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                LogoutUser(sourcePage, session, response);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
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
                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetErrorMessage(session, ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage,role.ToLower()),session);
                                response.Redirect(DefaultErrorPage,false);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                            RemoveExceptionEntry(sourcePage);
                            SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage, role.ToLower()), session);
                            response.Redirect(DefaultErrorPage,false);
                        }

                    }
                    #endregion
                }
                #endregion
                else if (role.ToLower().Equals(MANAGER))
                {
                    if (sourcePage.ToLower().Contains("performance"))
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {

                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetLoginErrorMessage(ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                LogoutManager(sourcePage,session, response);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetLoginErrorMessage(ErrorMessageUtility.homeMessage);
                            RemoveExceptionEntry(sourcePage);
                            LogoutManager(sourcePage, session, response);
                        }
                    }
                    #region rest of pages
                    else
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {
                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetErrorMessage(session, ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage, role.ToLower()), session);
                                response.Redirect(DefaultErrorPage, false);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                            RemoveExceptionEntry(sourcePage);
                            SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage, role.ToLower()), session);
                            response.Redirect(DefaultErrorPage, false);
                        }

                    }
                    #endregion
                }
                else if (role.ToLower().Equals(ADMIN))
                {
                    if (sourcePage.ToLower().Contains("home"))
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {

                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetLoginErrorMessage(ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                LogoutAdmin(sourcePage, session, response);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetLoginErrorMessage(ErrorMessageUtility.homeMessage);
                            RemoveExceptionEntry(sourcePage);
                            LogoutAdmin(sourcePage, session, response);
                        }
                    }
                    #region rest of pages
                    else
                    {
                        if (redirectionStrategy == RedirectionStrategy.local)
                        {
                            if (ExceptionCount(sourcePage) > 2)
                            {
                                SetErrorMessage(session, ErrorMessageUtility.constantErrorMessage);
                                RemoveExceptionEntry(sourcePage);
                                SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage, role.ToLower()), session);
                                response.Redirect(DefaultErrorPage, false);
                            }
                            else
                            {
                                SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                                server.Transfer(sourcePage, false);
                            }
                        }
                        else
                        {
                            SetErrorMessage(session, ErrorMessageUtility.genericMessage);
                            RemoveExceptionEntry(sourcePage);
                            SetRemoteRedirectionURL(ProvideRedirectionURL(sourcePage, role.ToLower()), session);
                            response.Redirect(DefaultErrorPage, false);
                        }

                    }
                    #endregion
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

        internal static string GetRedirectionURL(HttpSessionState session)
        {
            string url=string.Empty;
            if(session["Is_Error"]!=null)
            {
                url = session["RED-URL"].ToString();
                session["Is_Error"] = "False";
                session["RED-URL"] = string.Empty;
            }
            return url;
        }
        #endregion

        #region Utility Methods
        private static string ProvideRedirectionURL(string sourcePage,string role)
        {
            string url=null;
            if (role.ToLower().Equals(PLAYER))
            {
                if (playerRedirectionLookup.ContainsKey(sourcePage))
                {
                    url = playerRedirectionLookup[sourcePage];
                }
            }
            else if (role.ToLower().Equals(MANAGER))
            {
                if (ManagerRedirectionLookup.ContainsKey(sourcePage))
                {
                    url = ManagerRedirectionLookup[sourcePage];
                }
            }
            else if (role.ToLower().Equals(ADMIN))
            {
                if (AdminRedirectionLookup.ContainsKey(sourcePage))
                {
                    url = AdminRedirectionLookup[sourcePage];
                }
                // add code for admins
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

        private static void SetRemoteRedirectionURL(string destPage, HttpSessionState session)
        {
            session["Is_Error"] = "True";
            session["RED-URL"] = destPage;
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

            response.Redirect(ProvideRedirectionURL(sourcePage,PLAYER),false);
        }

        private static void LogoutManager(string sourcePage,HttpSessionState session, HttpResponse response)
        {
            session.Abandon();
            response.Redirect(ProvideRedirectionURL(sourcePage,MANAGER),false);
        }

        private static void LogoutAdmin(string sourcePage, HttpSessionState session, HttpResponse response)
        {
            session.Abandon();
            response.Redirect(ProvideRedirectionURL(sourcePage, MANAGER), false);
        }

        private static void LogError(Exception exp)
        {
            // need to add task for this later
        }

        
        private static void SetErrorMessage(HttpSessionState session, string message)
        {
            session["Is_Error"] = "True";
            session["Error_Message"] = message;
        }


        private static void SetLoginErrorMessage( string message)
        {
            LoginError = true;
            LoginErrorMessage = message;
        }
        #endregion
    }
}