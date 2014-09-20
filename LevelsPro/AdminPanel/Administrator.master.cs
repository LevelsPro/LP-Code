using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;
using System.Data;
using BusinessLogic.Select;

namespace LevelsPro.AdminPanel
{
    public partial class Administrator : System.Web.UI.MasterPage
    {
        private string usr, role;
        protected void Page_Load(object sender, EventArgs e)
        {
         

            if (!(IsPostBack))
            {
                #region Authentication Code
                try
                {
                    usr = (string)Session["username"];
                    role = (string)Session["role"];

                    lblRole.Text = role;
                    ltName.Text = usr;

                    if (usr == null)
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                    else
                    {

                        if (!(role.Equals("Admin")))
                        {
                            Response.Redirect("~/Login.aspx");
                        }
                        else
                        {

                        }

                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
                }
                #endregion

                #region Message Check
                MessagesViewBLL messageview = new MessagesViewBLL();

                try
                {
                    messageview.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dvNoti = messageview.ResultSet.Tables[0].DefaultView;

                dvNoti.RowFilter = "To_UserID=" + Session["userid"] + " AND IsRead=" + 0;

                DataTable dtNoti = dvNoti.ToTable();

                if (dtNoti != null && dtNoti.Rows.Count > 0)
                {
                    lblMessageNotification.Text = dtNoti.Rows.Count.ToString();

                }
                else
                {

                }
            }
            else
            {
                try
                {
                    if ((Session["username"].ToString() == null))
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
                #endregion

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void lnkbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        public int SessionLengthMinutes
        {
            get { return Session.Timeout; }
        }
        public string SessionExpireDestinationUrl
        {
            get { return "../Index.aspx"; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.PageHead.Controls.Add(new LiteralControl(
                String.Format("<meta http-equiv='refresh' content='{0};url={1}'>",
                SessionLengthMinutes * 60, SessionExpireDestinationUrl)));
        }

        protected void btnMessages_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel/Messages.aspx", false);
        }

    }
}