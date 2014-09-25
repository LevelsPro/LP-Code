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

namespace LevelsPro.PlayerPanel
{
    public partial class ProgressDetails : AuthorizedPage
    {
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = ConfigurationSettings.AppSettings["RolePath"].ToString();
            if (!IsPostBack)
            {
                //Session["check"]=0;
                //RolesViewBLL roles = new RolesViewBLL();
                //try
                //{
                //    roles.Invoke();
                //}
                //catch (Exception ex)
                //{
                //    //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                //}

                //DataView dv = roles.ResultSet.Tables[0].DefaultView;

                //dv.RowFilter = "Role_ID=" + Convert.ToInt32(Session["UserRoleID"]);

                //DataTable dt1 = new DataTable();
                //dt1 = dv.ToTable();
                //if (dt1.Rows[0]["ImageName"].ToString() != null && dt1.Rows.Count > 0 && dt1.Rows[0]["ImageName"].ToString() != "")
                //{
                //    string imagepath = dt1.Rows[0]["ImageName"].ToString();

                //    MapImage.Src = path + imagepath;
                //}
                //else 
                //{
                //    MapImage.Src = "images/map.png";
                //}
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
                    //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                }
                if (Session["UserRoleID"] != null)
                {
                    //DataView dv = level.ResultSet.Tables[0].DefaultView;

                    //dv.RowFilter = "Level_ID=" + Convert.ToInt32(Session["CurLevel"]);

                    //DataTable dt1 = new DataTable();
                    //dt1 = dv.ToTable();
                    //if (dt1 != null && dt1.Rows.Count > 0 && dt1.Rows[0]["ImageName"] != null && dt1.Rows[0]["ImageName"].ToString() != "")
                    //{
                    //    string imagepath = dt1.Rows[0]["ImageName"].ToString();

                    //    MapImage.Src = path + imagepath;
                    //}
                    //else
                    //{
                    //    MapImage.Src = "images/map.png";
                    //}

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
            //if(Convert.ToInt32(Session["check"])==1)
            //{
            //    Session["check"] = 0;
            //    ucViewProgressDetails.LoadTargetDescription(Convert.ToInt32(Session["targetid"]));
            //    mpeViewProgressDetailsDiv.Show();
            //    string URL = Session["lbturl"].ToString();
            //   ClientScript.RegisterStartupScript(this.Page.GetType(), "", "window.open('"+URL+"');", true);
             
            //}
        }

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
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
                    //lblPerformance.Text = Convert.ToDecimal(userlevel.ResultSet.Tables[0].Rows[0]["Percentage"]).ToString("0") + "%";//"80%";
                    lblLevel.Text = Resources.TestSiteResources.LevelL + ' ' + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString();//"Level 1";
                    LevelStar.ImageUrl = "images/star_yellow_" + userlevel.ResultSet.Tables[0].Rows[0]["Level_Position"].ToString() + ".png";

                    TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();

                    //GetProgressDetailBLL progress1 = new GetProgressDetailBLL();
                    User user = new User();

                    user.UserID = Convert.ToInt32(Session["userid"]);
                    user.CurrentLevel = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["current_level"]);//
                    progress.User = user;
                    //progress1.UserID = user;
                    //user.UserID = Convert.ToInt32(user);

                    try
                    {
                        progress.Invoke();
                        //progress1.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    if (progress.ResultSet != null && progress.ResultSet.Tables.Count > 0 && progress.ResultSet.Tables[0] != null && progress.ResultSet.Tables[0].Rows.Count > 0)
                    {
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

            //lblcpercentage.Text = "100";

            if (Convert.ToInt32(lblcpercentage.Text) > 100)
            {
                lblcpercentage.Text = "100";
            }

            //if (Convert.ToInt32(lblcpercentage.Text) == 100)
            //{
            //    e.Item.CssClass = "qgame-cont flset-change pdone";//"";
            //}

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

        //[System.Web.Services.WebMethod]
        //public static void AbandonSession()
        //{
        //    HttpContext.Current.Session.Abandon();
        //}

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