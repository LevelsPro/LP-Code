﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using LevelsPro.App_Code;
using System.Configuration;
using LevelsPro.PlayerPanel;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.ManagerPanel
{
    public partial class TeamPerformance : AuthorizedPage
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
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dvNoti = messageview.ResultSet.Tables[0].DefaultView;

                dvNoti.RowFilter = "To_UserID=" + Session["userid"] + " AND IsRead=" + 0;

                DataTable dtNoti = dvNoti.ToTable();

                if (dtNoti != null && dtNoti.Rows.Count > 0)
                {
                    lblMessageNotification.Text = dtNoti.Rows.Count.ToString();
                    ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                    myContent.FindControl("noti").Visible = true;

                }
                else
                {
                    ContentPlaceHolder myContent = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                    myContent.FindControl("noti").Visible = false;
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

        private void LoadData()
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
                lblFullName.Text = Session["displayname"].ToString();
                lblUserRole.Text = Session["rolename"].ToString();
                lblName.Text = Session["displayname"].ToString() + " - " + Resources.TestSiteResources.Team;

                UserImageViewBLL UserImage = new UserImageViewBLL();

                Common.UserImage image = new Common.UserImage();

                image.UserID = Convert.ToInt32(Session["userid"]);

                UserImage.UserImages = image;

                try
                {
                    UserImage.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataView dvImage1 = UserImage.ResultSet.Tables[0].DefaultView;
                dvImage1.RowFilter = "U_Current=1";
                DataTable dtcImage = new DataTable();
                dtcImage = dvImage1.ToTable();
                if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                {
                    imgCurrentImage.ImageUrl = Thumbpath + dtcImage.Rows[0]["Player_Thumbnail"].ToString();
                }

                TeamPerformanceBLL team = new TeamPerformanceBLL();
                Common.User user = new Common.User();

                user.ManagerID = Convert.ToInt32(Session["userid"]);

                team.User = user;

                try
                {
                    team.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataSet ds = team.ResultSet;

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataView dv = team.ResultSet.Tables[0].DefaultView;
                    dv.RowFilter = "PlayerStatus = 'red'";

                    ltAttentionCount.Text = dv.ToTable().Rows.Count.ToString();
                    if (Convert.ToInt32(ltAttentionCount.Text) == 1)
                    {
                        Label1.Text = "associate requires attention.";
                    }
                    dlTeam.DataSource = ds;
                    dlTeam.DataBind();
                }
                else
                {
                    dlTeam.DataSource = null;
                    dlTeam.DataBind();
                }
            }
        }      

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void dlTeam_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPlayer")
            {
                int userid = Convert.ToInt32(e.CommandArgument);
                Label lbllike = e.Item.FindControl("lbllike") as Label;
                Label lblRemain = e.Item.FindControl("lblRemain") as Label;
                Label lblBase = e.Item.FindControl("lblBase") as Label;
                Label lbllevelid = e.Item.FindControl("lbllevelid") as Label;
                Session["LevelIDMangerUser"] = Convert.ToInt32(lbllevelid.Text.ToString());
                
                int remain=0;
                int BaseHours=0;

                if (lblRemain.Text.Trim() != null && lblRemain.Text.Trim() != "")
                {
                    remain = Convert.ToInt32(lblRemain.Text.Trim());
                }
                if (lblBase.Text.Trim() != null && lblBase.Text.Trim() != "")
                {
                    BaseHours = Convert.ToInt32(lblBase.Text.Trim());
                }
                Response.Redirect("PlayerPerformance.aspx?id=" + userid + "&likelihood=" + lbllike.Text.Trim() + "&remaining=" + remain + "&Base=" + BaseHours, false);
            }            
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManagerProfile.aspx");
        }

        protected void btnMessages_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ManagerPanel/Messages.aspx", false);
        }

        protected void lkbChang_Click(object sender, EventArgs e)
        {
            mpeChangePassDiv.Show();
        }        
    }
}