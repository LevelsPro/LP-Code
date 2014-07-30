using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using AjaxControlToolkit;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_FourmSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTypes();
                LoadRoles();
                LoadPlayers();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strWhere = " WHERE 1 = 1 ";


            if (ddlType.SelectedIndex > 0)
            {
                strWhere += " AND tblPosts.PostTypeID = " + ddlType.SelectedValue;
            }

            if (ddlRole.SelectedIndex > 0)
            {
                strWhere += " AND tblPosts.RoleID = " + ddlRole.SelectedValue;
            }

            if (txtDate.Text.Trim() != "")
            {
                strWhere += " AND DATE(tblPosts.CreateDate) = DATE('" + txtDate.Text.Trim() + "') ";
            }

            if (ddlPlayer.SelectedIndex > 0)
            {
                strWhere += " AND tblPosts.CreatedBy = " + ddlPlayer.SelectedValue;
            }

            if (txtKeyword.Text.Trim() != "")
            {
                strWhere += " AND (tblPosts.PostTitle LIKE '%" + txtKeyword.Text.Trim() + "%' OR tblPosts.PostMessage LIKE '%" + txtKeyword.Text.Trim() + "%') ";
            }

            ((PlayerForums)this.Parent.Page).LoadPosts(strWhere);
            //PlayerForums objForum = new PlayerForums();

            //ModalPopupExtender mpe = objForum.FindControl("mpeSearchForum") as ModalPopupExtender;
            //mpe.Hide();
            //((ModalPopupExtender)(((PlayerForums)this.Parent.Page).FindControl("mpeSearchForum"))).Hide();
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
    }
}