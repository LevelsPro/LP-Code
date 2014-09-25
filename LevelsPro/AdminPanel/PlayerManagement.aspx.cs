using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using System.Drawing;
using System.Globalization;
using LevelsPro.App_Code;
using System.Configuration;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class PlayerManagement : AuthorizedPage
    {
        private static string pageURL;
        public static DataSet dsPlayer = new DataSet();

        public string sortOrder
        {
            get
            {
                if (hdnSortCheck.Value == "0")
                {
                    if (ViewState["sortOrder"].ToString() != "asc")
                    {
                        ViewState["sortOrder"] = "asc";
                    }
                    else
                    {
                        ViewState["sortOrder"] = "desc";
                    }                    
                }
                return ViewState["sortOrder"].ToString();
            }
            set
            {
                ViewState["sortOrder"] = value;
            }
        }        
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            lblmessage.Visible = false;

            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                sortOrder = "asc";
              
                ViewState["sortExp"] = "FullName";
                try
                {
                    LoadData();
                }
                catch(Exception exp)
                {
                    throw exp;
                }
                if (Request.QueryString["saved"] != null && Request.QueryString["saved"].ToString() != "")
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.Player + ' ' + Resources.TestSiteResources.SavedMessage;
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

        private void LoadTotalPlayerScore(int userid)
        {
           
        }

        protected void LoadData(string sort = "", string sortDirection = "asc", string where = "")
        {
            UserViewBLL player = new UserViewBLL();
            Common.User _user = new User();

            _user.Where = where;

            player.User = _user;
            try
            {
                player.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dsPlayer = player.ResultSet;
            DataView dvPlayer = player.ResultSet.Tables[0].DefaultView;
          

            if (sort != "")
            {
                dvPlayer.Sort = sort + " " + sortDirection;
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

        protected void gvPlayerScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnScore_Click(object sender, EventArgs e)
        {


        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            mpeManualScore.Hide();

        }

        protected void chkmass_oncheckedchanged(object sender, EventArgs e)
        {
           
        }

        protected void gvPlayerInfo_Sorting(object sender, GridViewSortEventArgs e)
        {

            hdnSortCheck.Value = "0";
            ViewState["sortExp"] = e.SortExpression;
            btnSearch_Click(null,null);
            

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = " WHERE 1 = 1 ";

            if (txtFilterUserID.Text.Trim() != "")
            {
                strWhere += " AND tblUser.U_Name LIKE '%" + txtFilterUserID.Text.Trim() + "%' ";
            }

            if (txtFilterFirstName.Text.Trim() != "")
            {
                strWhere += " AND tblUser.U_FirstName LIKE '%" + txtFilterFirstName.Text.Trim() + "%' ";
            }

            if (txtFilterLastName.Text.Trim() != "")
            {
                strWhere += " AND tblUser.U_LastName LIKE '%" + txtFilterLastName.Text.Trim() + "%' ";
            }

            if (txtFilterNickName.Text.Trim() != "")
            {
                strWhere += " AND tblUser.U_NickName LIKE '%" + txtFilterNickName.Text.Trim() + "%' ";
            }

            if (txtFilterEmail.Text.Trim() != "")
            {
                strWhere += " AND tblUser.U_Email LIKE '%" + txtFilterEmail.Text.Trim() + "%' ";
            }

            if (ddlFilterSite.SelectedIndex > 0)
            {
                strWhere += " AND tblUser.U_SiteID = " + ddlFilterSite.SelectedValue;
            }

            if (ddlFilterAppRole.SelectedIndex > 0)
            {
                strWhere += " AND tblUser.U_SysRole = '" + ddlFilterAppRole.SelectedItem.Text + "' ";
            }

            if (ddlFilterRole.SelectedIndex > 0)
            {
                strWhere += " AND tblUser.U_RolesID = " + ddlFilterRole.SelectedValue;
            }

            if (ddlFilterManager.SelectedIndex > 0)
            {
                strWhere += " AND tblUser.ManagerID = " + ddlFilterManager.SelectedValue;
            }


            if (ddlFilterActive.SelectedIndex > 0)
            {
                strWhere += " AND tblUser.Active = " + ddlFilterActive.SelectedValue;
            }

            try
            {
                LoadData(ViewState["sortExp"].ToString(), "", strWhere);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFilterUserID.Text = "";
            txtFilterFirstName.Text = "";
            txtFilterLastName.Text = "";
            txtFilterNickName.Text = "";
            txtFilterEmail.Text = "";
            ddlFilterSite.SelectedIndex = 0;
            ddlFilterAppRole.SelectedIndex = 0;
            ddlFilterRole.SelectedIndex = 0;
            ddlFilterManager.SelectedIndex = 0;
            ddlFilterActive.SelectedIndex = 0;
            try
            {
                LoadData();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void dlPlayers_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditPlayer")
            {
                Response.Redirect("EditPlayer.aspx?userid=" + e.CommandArgument.ToString());
            }
        }

        protected void btnCreatePlayer_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPlayer.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }        

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void ddlFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilterBy.SelectedIndex > 0)
                {
                    if (ddlFilterBy.SelectedValue == "1")
                    {
                        LoadRoles();
                    }
                    else if (ddlFilterBy.SelectedValue == "2")
                    {
                        LoadManagers();
                    }
                    else if (ddlFilterBy.SelectedValue == "4")
                    {
                        LoadData("", "asc", " WHERE 1=1 AND tblUser.Active = 1");
                    }
                    else
                    {
                        LoadSites();
                    }
                }
                else if (ddlFilterBy.SelectedIndex == 0)
                {
                    if (ViewState["sortExp"] != null && ViewState["sortExp"].ToString() != "")
                    {
                        LoadData(ViewState["sortExp"].ToString(), "", "");
                    }
                    else
                    {
                        LoadData();
                    }
                    ddlFilterExp.Items.Clear();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void LoadRoles()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlFilterExp.DataTextField = "Role_Name";
            ddlFilterExp.DataValueField = "Role_ID";

            DataView dv = role.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlFilterExp.DataSource = dv.ToTable();
            ddlFilterExp.DataBind();

            ListItem liFilter = new ListItem("Select Role", "0");
            ddlFilterExp.Items.Insert(0, liFilter);
        }

        private void LoadManagers()
        {
            ManagerDropDownBLL selectddlSite = new ManagerDropDownBLL();
            try
            {
                selectddlSite.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlFilterExp.DataTextField = "U_Name";
            ddlFilterExp.DataValueField = "UserID";

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlFilterExp.DataSource = dv.ToTable();
            ddlFilterExp.DataBind();

            ListItem liFilter = new ListItem("Select Manager", "0");
            ddlFilterExp.Items.Insert(0, liFilter);
        }

        private void LoadSites()
        {
            Site_DropDownBLL selectddlSite = new Site_DropDownBLL();
            try
            {
                selectddlSite.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlFilterExp.DataTextField = "site_name";
            ddlFilterExp.DataValueField = "site_id";

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlFilterExp.DataSource = dv.ToTable();
            ddlFilterExp.DataBind();

            ListItem liFilter = new ListItem("Select Location", "0");
            ddlFilterExp.Items.Insert(0, liFilter);
        }
        #region sort and filter
        protected void ddlFilterExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlFilterExp.SelectedIndex > 0)
                {
                    string where = " WHERE 1=1 ";
                    if (ddlFilterBy.SelectedValue == "1")
                    {
                        where += " AND tblUser.U_RolesID = " + ddlFilterExp.SelectedValue;
                    }
                    else if (ddlFilterBy.SelectedValue == "2")
                    {
                        where += " AND tblUser.ManagerID = " + ddlFilterExp.SelectedValue;
                    }
                    else
                    {
                        where += " AND tblUser.U_SiteID = " + ddlFilterExp.SelectedValue;
                    }

                    if (ViewState["sortExp"] != null && ViewState["sortExp"].ToString() != "")
                    {
                        LoadData(ViewState["sortExp"].ToString(), "", where);
                    }
                    else
                    {
                        LoadData("", "", where);
                    }
                }
                else if (ddlFilterExp.SelectedIndex == 0)
                {
                    if (ViewState["sortExp"] != null && ViewState["sortExp"].ToString() != "")
                    {
                        LoadData(ViewState["sortExp"].ToString(), "", "");
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void ddlSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSortBy.SelectedIndex > 0)
                {
                    hdnSortCheck.Value = "0";
                    if (ddlSortBy.SelectedValue == "1")
                    {
                        ViewState["sortExp"] = "U_FirstName";
                    }
                    else
                    {
                        ViewState["sortExp"] = "U_LastName";
                    }

                    if (ddlFilterBy.SelectedIndex > 0 && ddlFilterExp.SelectedIndex > 0)
                    {
                        ddlFilterExp_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        LoadData(ViewState["sortExp"].ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion
        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}