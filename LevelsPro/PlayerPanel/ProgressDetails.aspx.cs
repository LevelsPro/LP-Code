using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using LevelsPro.App_Code;
using System.Data;
using System.Configuration;
using BusinessLogic.Update;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class ProgressDetails : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = ConfigurationSettings.AppSettings["RolePath"].ToString();
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!IsPostBack)
            {
                
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                LevelsViewBLL level = new LevelsViewBLL();
                Common.Roles role = new Roles();
                role.RoleID = Convert.ToInt32(Session["UserRoleID"]);
                level.Role = role;
                try
                {
                    level.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                   
                }
                if (Session["UserRoleID"] != null)
                {
                    

                    MapImage.Src = Session["imagePath"].ToString();
                }

                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
            ExceptionUtility.CheckForErrorMessage(Session);
            
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        public void LoadData()
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                lblName.Text = Session["displayname"].ToString() + Resources.TestSiteResources.Progress;


                UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
                Common.User _user = new Common.User();

                _user.UserID = Convert.ToInt32(Session["userid"]);

                userlevel.User = _user;

                try
                {
                    userlevel.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                if (userlevel.ResultSet != null && userlevel.ResultSet.Tables.Count > 0 && userlevel.ResultSet.Tables[0] != null && userlevel.ResultSet.Tables[0].Rows.Count > 0)
                {
                   
                    lblLevel.Text = Resources.TestSiteResources.LevelL + ' ' + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();//"Level 1";
                    LevelStar.ImageUrl = "images/star_yellow_" + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString() + ".png";

                    TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();

                    
                    User user = new User();

                    user.UserID = Convert.ToInt32(Session["userid"]);
                    user.CurrentLevel = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["current_level"]);//
                    progress.User = user;
                    
                    try
                    {
                        progress.Invoke();
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    TargetViewBLL target = new TargetViewBLL();

                    try
                    {
                        target.Invoke();
                    }
                    catch (Exception ex) 
                    {
                        throw ex;
                    }
                    if (progress.ResultSet != null && progress.ResultSet.Tables.Count > 0 && progress.ResultSet.Tables[0] != null && progress.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        //DataColumn newCol= new DataColumn(
                        progress.ResultSet.Tables[0].Columns.Add("targetOrder",typeof(int));
                        foreach (DataRow row in progress.ResultSet.Tables[0].Rows)
                        {
                            foreach (DataRow rowInner in target.ResultSet.Tables[0].Rows) 
                            {
                                if (row["Target_ID"].Equals(rowInner["Target_ID"])) 
                                {
                                    row["targetOrder"] = rowInner["TOrder"];
                                }
                            }
                            
                        }
                       // progress.ResultSet.Tables[0].DefaultView.Sort = "KPI_name";
                        progress.ResultSet.Tables[0].DefaultView.Sort = "targetOrder";
                        if (progress.ResultSet.Tables[0].Rows[0]["CheckNoProgress"].ToString().Equals("0"))
                        {

                            dlProgressDetail.DataSource = progress.ResultSet.Tables[0];
                            dlProgressDetail.DataBind();
                            if (progress.ResultSet.Tables[0].Rows[0]["CurrentlyIn"].ToString().Equals(""))
                            {
                                lblLevelName.Text = Resources.TestSiteResources.InitialStage;
                            }
                            else
                            {
                                lblLevelName.Text = progress.ResultSet.Tables[0].Rows[0]["CurrentlyIn"].ToString();
                            }
                            if (!progress.ResultSet.Tables[0].Rows[0]["Reach"].ToString().Equals(""))
                            {
                                lblNextLevelName.Text = progress.ResultSet.Tables[0].Rows[0]["Reach"].ToString();
                            }

                            if (!progress.ResultSet.Tables[0].Rows[0]["Bonus"].ToString().Equals(""))
                            {
                                lblbonus.Text = progress.ResultSet.Tables[0].Rows[0]["Bonus"].ToString();
                            }

                            if (!progress.ResultSet.Tables[0].Rows[0]["TargetDate"].ToString().Equals(""))
                            {
                                lblTargetDate.Text = Convert.ToDateTime(progress.ResultSet.Tables[0].Rows[0]["TargetDate"]).ToString("MMMM dd,yyyy");
                            }
                            decimal percentage = 0;
                            decimal totalPercentage = 0;

                            foreach (DataRow dr in progress.ResultSet.Tables[0].Rows)
                            {
                                percentage += Convert.ToDecimal(dr["current_percentage"]);
                            }

                            totalPercentage = percentage / progress.ResultSet.Tables[0].Rows.Count;

                            lblPerformance.Text = totalPercentage.ToString("0") + "%";
                        }

                        else
                        {
                            if (progress.ResultSet.Tables[0].Rows[0]["CurrentlyIn"].ToString().Equals(""))
                            {
                                lblLevelName.Text = Resources.TestSiteResources.InitialStage;
                            }
                            else
                            {
                                lblLevelName.Text = progress.ResultSet.Tables[0].Rows[0]["CurrentlyIn"].ToString();
                            }
                            if (!progress.ResultSet.Tables[0].Rows[0]["Reach"].ToString().Equals(""))
                            {
                                lblNextLevelName.Text = progress.ResultSet.Tables[0].Rows[0]["Reach"].ToString();
                            }

                            if (!progress.ResultSet.Tables[0].Rows[0]["Bonus"].ToString().Equals(""))
                            {
                                lblbonus.Text = progress.ResultSet.Tables[0].Rows[0]["Bonus"].ToString();
                            }

                            lblPerformance.Text = "0%";
                        }

                    }
                    else
                    {
                        lblPerformance.Text = "0%";
                        lblLevel.Text = Resources.TestSiteResources.Level0;
                    }

                }
            }
        }


        protected void dlProgressDetail_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lblcpercentage = (Label)e.Item.FindControl("cpercentage");

            Label lblkpiname = (Label)e.Item.FindControl("lblKPIName");

            Label lbltargetvalue = (Label)e.Item.FindControl("lblTargetValue");

           

            if (Convert.ToInt32(lblcpercentage.Text) > 100)
            {
                lblcpercentage.Text = "100";
            }

           
            lblcpercentage.Text = lblcpercentage.Text + "%";

            lblkpiname.Text = lblkpiname.Text.Replace("X", lbltargetvalue.Text);
        }

        protected void dlProgressDetail_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPopup")
            {
                int target = Convert.ToInt32(e.CommandArgument);
                mpeViewProgressDetailsDiv.Show();
                ucViewProgressDetails.LoadTargetDescription(target);
            }
        }

       

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            User user = new User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}