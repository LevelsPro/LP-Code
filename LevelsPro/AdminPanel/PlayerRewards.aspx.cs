using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Update;
using LevelsPro.App_Code;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class PlayerRewards : AuthorizedPage
    {
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    ViewState["userid"] = Request.QueryString["userid"];
                    try
                    {
                        LoadData(Convert.ToInt32(ViewState["userid"]));
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        #region show all rewards
        private void LoadData( int UserID)
        {
            if (UserID > 0)
            {
                UserViewBLL player = new UserViewBLL();
                Common.User _user = new Common.User();

                _user.Where = " WHERE tblUser.UserID = " + UserID.ToString();

                player.User = _user;
                try
                {
                    player.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
                DataView dvPlayer = player.ResultSet.Tables[0].DefaultView;
                if (dvPlayer != null && dvPlayer.ToTable().Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dvPlayer.ToTable();

                    lblUserIDValue.Text = dt.Rows[0]["U_Name"].ToString();////UserID.ToString();
                    lblNameValue.Text = dt.Rows[0]["U_FirstName"].ToString() + " " + dt.Rows[0]["U_LastName"].ToString();
                    txtPoints.Text = dt.Rows[0]["U_Points"].ToString();
                }

                GetRewardUserBLL manual = new GetRewardUserBLL();
                Common.Reward _userreward = new Common.Reward();

                _userreward.UserID = UserID;
                manual.UserRewards = _userreward;
                try
                {
                    manual.Invoke();
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                if (manual.ResultSet != null && manual.ResultSet.Tables.Count > 0 && manual.ResultSet.Tables[0] != null && manual.ResultSet.Tables[0].Rows.Count > 0)
                {
                    dlRewards.DataSource = manual.ResultSet;
                    dlRewards.DataBind();
                }
                else
                {
                    dlRewards.DataSource = null;
                    dlRewards.DataBind();
                }
            }
        }
        #endregion
        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnAwards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerAward.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnProgress_Click(object sender, EventArgs e)
        {
            if (Session["LevelCheck"].ToString() != null && ViewState["userid"] != null)
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString() + "&levelid=" +  Session["LevelCheck"].ToString(), false);
            }
            else if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerManagement.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null)
            {
                UserPointsUpdateBLL points = new UserPointsUpdateBLL();
                Common.User user = new Common.User();

                user.UserID = Convert.ToInt32(ViewState["userid"]);

                user.Score = Convert.ToInt32(txtPoints.Text);

                points.User = user;

                try
                {
                    points.Invoke();
                    lblMessage.Text = Resources.TestSiteResources.PointsUpdate;
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnMainInfo_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("EditPlayer.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }
    }
}