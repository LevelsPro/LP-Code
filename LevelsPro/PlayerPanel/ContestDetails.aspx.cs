using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common;
using BusinessLogic.Select;
using LevelsPro.App_Code;
using BusinessLogic.Update;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.PlayerPanel
{
    public partial class ContestDetails : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!Page.IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    try
                    {
                        ViewProfile.LoadData();
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                    lblName.Text = Session["displayname"].ToString() + " - Contest";
                }

                if (Session["ContestID"] != null)
                {
                    Load_ContestDetails(Convert.ToInt32(Session["ContestID"]));
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

        public void Load_ContestDetails(int ContestID)
        {

            DataSet ds = new DataSet();
            Contest _contest = new Contest();
            PlayerContestViewDetailBLL contest = new PlayerContestViewDetailBLL();
            _contest.ContestID = ContestID;
            contest.Contest = _contest;
            contest.Invoke();
            ds = contest.ResultSet;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                imgContestImage.ImageUrl = "~/view-file.aspx?contestid=" + ContestID;
                lblContestName.InnerText = ds.Tables[0].Rows[0]["Contest_Name"].ToString();
                lblContestEndDate.InnerText = Convert.ToDateTime(ds.Tables[0].Rows[0]["Contest_EndDate"]).ToString("MMMM dd, yyyy");
                ltContestDescription.Text = ds.Tables[0].Rows[0]["Contest_Descp"].ToString();
                
            }

            DataSet dsPointsTable = new DataSet();
            Contest _contestid = new Contest();
            ContestPlayersScoreBLL contestplayerscore = new ContestPlayersScoreBLL();
            _contestid.ContestID = ContestID;
            contestplayerscore.Contest = _contestid;
            contestplayerscore.Invoke();
            dsPointsTable = contestplayerscore.ResultSet;
            if (dsPointsTable != null && dsPointsTable.Tables[0].Rows.Count > 0)
            {
                gvPointsTable.DataSource = dsPointsTable;
                gvPointsTable.DataBind();
            }

        }

        protected void gvPointsTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image imgRank = (Image)e.Row.FindControl("imgbtnRank");
                if (imgRank != null)
                {
                    if (e.Row.RowIndex == 0)
                    {
                        imgRank.ImageUrl = "~/PlayerPanel/Images/rank-1.png";
                        imgRank.Width = Unit.Pixel(40);
                        imgRank.Height = Unit.Pixel(30);
                    }
                    else
                        if (e.Row.RowIndex == 1)
                        {
                            imgRank.ImageUrl = "~/PlayerPanel/Images/rank-2.png";
                            imgRank.Width = Unit.Pixel(35);
                            imgRank.Height = Unit.Pixel(25);
                        }
                        else if (e.Row.RowIndex == 2)
                        {
                            imgRank.ImageUrl = "~/PlayerPanel/Images/rank-3.png";
                            imgRank.Width = Unit.Pixel(30);
                            imgRank.Height = Unit.Pixel(20);
                        }
                }

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
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