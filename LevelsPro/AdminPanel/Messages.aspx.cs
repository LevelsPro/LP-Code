using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Delete;
using BusinessLogic.Update;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class Messages : AuthorizedPage
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
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                  
                    lblName.Text = Session["displayname"].ToString() + " - Messages";
                }

                
                btnShowAll_Click(null, null);
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
                

                btnShowUnRead.CssClass = "green";
                btnShowAll.CssClass = "orange";
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dv = messageview.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "To_UserID=" + Session["userid"];

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dlMessages.DataSource = dt;
                    dlMessages.DataBind();
                }
                else
                {
                    dlMessages.DataSource = null;
                    dlMessages.DataBind();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnComposeMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfShowAll.Value == "0")
                {
                    LoadUnReadData();
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            mpeComposeMessageDiv.Show();
        }

        protected void btnShowUnRead_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUnReadData();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #region show unread message
        public void LoadUnReadData()
        {
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                btnShowUnRead.CssClass = "green";
                btnShowAll.CssClass = "orange";
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dv = messageview.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "To_UserID=" + Session["userid"] + " AND IsRead= 0";

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0)
                {
                    dlMessages.DataSource = dt;
                    dlMessages.DataBind();
                }
                else
                {
                    dlMessages.DataSource = null;
                    dlMessages.DataBind();
                }
                hfShowAll.Value = "0";
            }
        }
        #endregion
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                hfShowAll.Value = "1";
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #region view and delete message
        protected void dlMessages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewPopup")
            {
                int MessageID = Convert.ToInt32(e.CommandArgument);


                MessageStatusUpdateBLL statusupdate = new MessageStatusUpdateBLL();
                Common.Messages message = new Common.Messages();
                message.MessageID = MessageID;
                statusupdate.Messages = message;
                try
                {
                    statusupdate.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (hfShowAll.Value == "0")
                {
                    btnShowUnRead_Click(null, null);
                }
                else
                {
                    btnShowAll_Click(null, null);
                }

                mpeViewMessageDetailsDiv.Show();
                ucViewMessageDetails.loadData(MessageID);
                
            }
            else if (e.CommandName == "DeleteMsg")
            {
                int MessageID = Convert.ToInt32(e.CommandArgument);
                MessageDeleteBLL msgBLL = new MessageDeleteBLL();
                Common.Messages msg = new Common.Messages();

                msg.MessageID = MessageID;

                msgBLL.Message = msg;

                try
                {
                    msgBLL.Invoke();
                    btnShowAll_Click(null, null);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion
        protected void dlMessages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblIsRead = e.Item.FindControl("lblIsRead") as Label;
                ImageButton ibtnDelete = e.Item.FindControl("ibtnDelete") as ImageButton;
                Image imgUnread = e.Item.FindControl("imgUnread") as Image;

                if (lblIsRead != null && lblIsRead.Text.Trim() != "" && lblIsRead.Text.Trim().ToLower() == "true")
                {
                    ibtnDelete.Visible = true;
                    imgUnread.Visible = false;
                }
                else
                {
                    imgUnread.Visible = true;
                    ibtnDelete.Visible = false;
                }
            }
          
        }
    }
}