using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using System.Configuration;
using LevelsPro.App_Code;

namespace LevelsPro.PlayerPanel
{
    public partial class PlayerForums : AuthorizedPage
    {
        private string currentPage;
        private string pageSize = ConfigurationManager.AppSettings["pagesize"];
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    lblName.Text = Session["displayname"].ToString() + " - Forums";
                }
                ViewState["currentPage"] = 1;
                currentPage = ViewState["currentPage"].ToString();
                string sql = BuildSqlWhere() + " and rownum between (("+ currentPage +" - 1) * " + pageSize +" + 1) AND ("+ currentPage +" * "+ pageSize +")";
                ViewProfile.LoadData();
                LoadPosts(sql);
                LoadTypes();
                LoadRoles();
                LoadPlayers();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void btnCreatePost_Click(object sender, EventArgs e)
        {
            mpeCreatePost.Show();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        public void LoadPosts(string strWhere = "")
        {

            PostsViewBLL posts = new PostsViewBLL();

            Common.Posts _post = new Common.Posts();
            _post.Where = strWhere;

            posts.Post = _post;
            try
            {
                posts.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataSet dsPosts = posts.ResultSet;
            if (dsPosts != null && dsPosts.Tables.Count > 0 && dsPosts.Tables[0] != null && dsPosts.Tables[0].Rows.Count > 0)
            {
                DataTable dtPosts = dsPosts.Tables[0];
                gvPosts.DataSource = dsPosts.Tables[0];
                gvPosts.DataBind();
                ViewState["totalPages"] = Math.Ceiling(Convert.ToDecimal(dsPosts.Tables[1].Rows[0]["TotalRecords"])/Convert.ToDecimal(pageSize)).ToString();
                lblCurrPage.Text = ViewState["currentPage"] + "/" + ViewState["totalPages"];
            }
            else
            {
                gvPosts.DataSource = null;
                gvPosts.DataBind();
            }

            upForum.Update();
        }

        protected void gvPosts_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvPosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    if (i != 5)
                    {
                        e.Row.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='pointer'");
                        e.Row.Cells[i].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gvPosts, "Select$" + e.Row.RowIndex.ToString()));
                    }

                    Label lblMinues = (Label)e.Row.Controls[0].FindControl("lblLatestDate");
                  //  e.Row.Cells[4].Text += " " + GetTimeDiff(Convert.ToInt32(lblMinues.Text));

                }
            }
        }

        protected void gvPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridView)sender).SelectedRow as GridViewRow;

            row.Style.Add("background", "#88A3CC");
            row.Style.Add("color", "white");
            hdnRowNum.Value = row.RowIndex.ToString();
            Label lblPostID = (Label)gvPosts.SelectedRow.Controls[0].Controls[1];
            string id;
            if (lblPostID != null)
            {
                id = lblPostID.Text;
                Response.Redirect("ForumDetails.aspx?PostID=" + id);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            mpeSearchForum.Show();
        }

        protected string GetTimeDiff(int minutes, string name)
        {
            if (minutes < 60 && minutes > 0)
                return name + "<br/>" + minutes.ToString() + " minutes ago";
            else if (minutes >= 60 && minutes < 1440)
                return name + "<br/>" + (minutes / 60).ToString() + " hours ago";
            else if (minutes >= 1440 && minutes < 10080)
                return name + "<br/>" + (minutes / 60 / 24).ToString() + " days ago ";
            else if (minutes >= 10080 && minutes < 40320)
                return name + "<br/>" + (minutes / 60 / 24 / 4).ToString() + " weeks ago ";
            else if (minutes >= 40320 && minutes < 161280)
                return name + "<br/>" + (minutes / 60 / 24 / 4 / 12).ToString() + " months ago ";
            else if (minutes > 161280)
                return name + "<br/>" + (minutes / 161280).ToString() + " years ago ";
            else if (minutes < 1 && name != "")
                return name + "<br/>" + "a moment ago";
            else
                return name + "<br/>" + "";
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["currentPage"]) != Convert.ToInt32(ViewState["totalPages"]))
            {
                ViewState["currentPage"] = Convert.ToInt32(ViewState["currentPage"]) + 1;
                currentPage = ViewState["currentPage"].ToString();
                string sql = BuildSqlWhere() + " and rownum between ((" + currentPage + " - 1) * " + pageSize + " + 1) AND (" + currentPage + " * " + pageSize + ")";
                LoadPosts(sql);
            }
        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["currentPage"]) > 1)
            {
                ViewState["currentPage"] = Convert.ToInt32(ViewState["currentPage"]) - 1;
                currentPage = ViewState["currentPage"].ToString();
                string sql = BuildSqlWhere() + " and rownum between ((" + currentPage + " - 1) * " + pageSize + " + 1) AND (" + currentPage + " * " + pageSize + ")";
                LoadPosts(sql);
            }
        }

        protected void btnFirstPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["currentPage"]) > 1)
            {
                ViewState["currentPage"] = 1;
                currentPage = ViewState["currentPage"].ToString();
                string sql = BuildSqlWhere() + " and rownum between ((" + currentPage + " - 1) * " + pageSize + " + 1) AND (" + currentPage + " * " + pageSize + ")";
                LoadPosts(sql);
            }
        }

        protected void btnLastPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ViewState["currentPage"]) != Convert.ToInt32(ViewState["totalPages"]))
            {
                ViewState["currentPage"] = Convert.ToInt32(ViewState["totalPages"]);
                currentPage = ViewState["currentPage"].ToString();
                string sql = BuildSqlWhere() + " and rownum between ((" + currentPage + " - 1) * " + pageSize + " + 1) AND (" + currentPage + " * " + pageSize + ")";
                LoadPosts(sql);
            }
        }

        public void LoadTypes()
        {
            PostTypesViewBLL _postTypes = new PostTypesViewBLL();
            try
            {
                _postTypes.Invoke();
            }
            catch (Exception ex)
            {
            }
            //DataView dv = _postTypes.ResultSet.Tables[0].DefaultView;

            ddlType.DataSource = _postTypes.ResultSet;
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "PostTypeID";
            ddlType.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlType.Items.Insert(0, li);
        }

        public void LoadRoles()
        {
            RolesViewBLL _role = new RolesViewBLL();
            try
            {
                _role.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlRole.DataSource = _role.ResultSet;
            ddlRole.DataTextField = "Role_Name";
            ddlRole.DataValueField = "Role_ID";
            ddlRole.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlRole.Items.Insert(0, li);
        }

        public void LoadPlayers()
        {
            UserViewBLL player = new UserViewBLL();

            Common.User _user = new Common.User();

            _user.Where = "";

            player.User = _user;
            DataSet dsPlayer = new DataSet();
            try
            {
                player.Invoke();
            }
            catch (Exception ex)
            {
            }
            dsPlayer = player.ResultSet;

            ddlPlayer.DataTextField = "FullName";
            ddlPlayer.DataValueField = "UserID";

            DataView dv = dsPlayer.Tables[0].DefaultView;

            ddlPlayer.DataSource = dv.ToTable();
            ddlPlayer.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlPlayer.Items.Insert(0, li);
        }

        public string BuildSqlWhere()
        {
            string strWhere = " WHERE 1 = 1 ";


            if (ddlType.SelectedIndex > 0)
            {
                strWhere += " AND S.ID = " + ddlType.SelectedValue;
            }

            if (ddlRole.SelectedIndex > 0)
            {
                strWhere += " AND S.RoleID = " + ddlRole.SelectedValue;
            }

            if (txtDate.Text.Trim() != "")
            {
                strWhere += " AND DATE(S.CreateDate) = DATE('" + txtDate.Text.Trim() + "') ";
            }

            if (ddlPlayer.SelectedIndex > 0)
            {
                strWhere += " AND S.CreatedBy = " + ddlPlayer.SelectedValue;
            }

            if (txtKeyword.Text.Trim() != "")
            {
                strWhere += " AND (S.Topic LIKE '%" + txtKeyword.Text.Trim() + "%' OR S.PostMessage LIKE '%" + txtKeyword.Text.Trim() + "%') ";
            }
            return strWhere;
        }

        protected void btnSearchBy_Click(object sender, EventArgs e)
        {
            string StrWhere = BuildSqlWhere();
            LoadPosts(StrWhere);
        }
    }
}