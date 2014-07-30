using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using System.Data;
using Common;

namespace LevelsPro.PlayerPanel.UserControls
{
    public partial class uc_CreatePost : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillPostTypesDDL();
                fillRoleDLL();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("PlayerForums.aspx", true);
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            PostInsertBLL _postInsert = new PostInsertBLL();
            Posts _post = new Posts();
            _post.PostTitle = txtTitle.Text;
            _post.PostMessage = txtPostArea.Text;
            _post.PostTypeId = Convert.ToInt32(ddlType.SelectedValue);
            _post.RoleId = Convert.ToInt32(ddlrole.SelectedValue);
            _post.CreateDate = DateTime.Now;
            _post.CreatedBy = Convert.ToInt32(Session["UserID"]);
            try
            {
                _postInsert.Post = _post;
                _postInsert.Invoke();
                ((PlayerForums)this.Parent.Page).LoadPosts();
            }
            catch (Exception ex)
            {
            }
        }

        public void fillPostTypesDDL()
        { 
            PostTypesViewBLL _postTypes = new PostTypesViewBLL();
            try
            {
                _postTypes.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = _postTypes.ResultSet.Tables[0].DefaultView;

            ddlType.DataSource = dv.ToTable();
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "PostTypeID";
            ddlType.DataBind();
        }
        public void fillRoleDLL()
        {
            RolesViewBLL _role = new RolesViewBLL();
            try
            {
                _role.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = _role.ResultSet.Tables[0].DefaultView;

            ddlrole.DataSource = dv.ToTable();
            ddlrole.DataTextField = "Role_Name";
            ddlrole.DataValueField = "Role_ID";
            ddlrole.DataBind();
        }

        protected void txtTitle_TextChanged(object sender, EventArgs e)
        {
            //lblMessageStatus.Text = txtTitle.Text.Length.ToString() + "/200";
        }
    }
}