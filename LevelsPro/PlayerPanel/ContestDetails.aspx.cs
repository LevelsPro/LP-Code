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
using System.Web.UI.HtmlControls;

namespace LevelsPro.PlayerPanel
{
    public partial class ContestDetails : AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        public static DataSet dsPlayer = new DataSet();           

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
                
                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    ViewState["userid"] = Request.QueryString["userid"];

                    ViewProfile.LoadData(ViewState["userid"].ToString());                    

                    if (Session["ContestID"] != null)
                    {
                        Load_ContestDetails(Convert.ToInt32(Session["ContestID"]), ViewState["userid"].ToString());
                    }
                }
                else 
                {
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        try
                        {
                            ViewProfile.LoadData(Session["userid"].ToString());
                        }
                        catch (Exception exp)
                        {
                            throw exp;
                        }                        

                        if (Session["ContestID"] != null)
                        {
                            Load_ContestDetails(Convert.ToInt32(Session["ContestID"]), Session["userid"].ToString());
                        }
                    }
                }
            }
            else 
            {
                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    ViewState["userid"] = Request.QueryString["userid"];

                    ViewProfile.LoadData(ViewState["userid"].ToString());
                }
                else
                {
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        try
                        {
                            ViewProfile.LoadData(Session["userid"].ToString());
                        }
                        catch (Exception exp)
                        {
                            throw exp;
                        }
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        public void Load_ContestDetails(int ContestID, string userid = "", string where = "")
        {

            ContestPlayerLeaderBoardViewBLL leaderboard = new ContestPlayerLeaderBoardViewBLL();
            Common.Contest _contest = new Contest();

            _contest.ContestID = ContestID;
            _contest.UserID = Convert.ToInt32(userid);

            //_contest.Where = " WHERE y.ContestID = " + Session["ContestID"].ToString();            

            leaderboard.ContestLeaderBoard = _contest;
            try
            {
                leaderboard.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dsPlayer = leaderboard.ResultSet;
            DataView dvPlayer = leaderboard.ResultSet.Tables[0].DefaultView;

            if ((ViewState["SortItem"] != null) && (ViewState["SortItem"].ToString() != ""))
            {
                dvPlayer.Sort = ViewState["SortItem"].ToString();
            }
            else 
            {
                dvPlayer.Sort = "PositionClear";
            }            

            if (dvPlayer != null && dvPlayer.ToTable().Rows.Count > 0)
            {
                dlPlayers.DataSource = dvPlayer;
                dlPlayers.DataBind();
            }
            else
            {
                dlPlayers.DataSource = null;
                dlPlayers.DataBind();
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

        protected void ddlSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sortOrder = "ASC";
            if (ddlSortBy.SelectedValue == "Score") 
            {
                sortOrder = "DESC";
            }

            ViewState["SortItem"] = ddlSortBy.SelectedValue + " " + sortOrder;

            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                if (Session["ContestID"] != null)
                {
                    Load_ContestDetails(Convert.ToInt32(Session["ContestID"]), ViewState["userid"].ToString());
                }
            }
            else 
            {
                if (Session["ContestID"] != null)
                {
                    Load_ContestDetails(Convert.ToInt32(Session["ContestID"]));
                }
            }            
        }

        protected void dlPlayers_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
        }

        protected void dlPlayers_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblUName");
            if (lbl.Text == Session["CurrectName"].ToString())
            {

                HtmlGenericControl container1 = (HtmlGenericControl)e.Item.FindControl("itemContainer");
                
                container1.Attributes.Remove("class");
                container1.Attributes.Add("class", "level-cont-grey level-cont-green-selected");
            }
        }

        protected void dlPlayers_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "LoadPlayer")
            {
                Response.Redirect("ContestDetails.aspx?userid=" + e.CommandArgument.ToString());
            }
        }
    }
}