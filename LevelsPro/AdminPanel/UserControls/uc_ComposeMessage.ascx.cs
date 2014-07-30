using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using Common;

namespace LevelsPro.AdminPanel.UserControls
{
    public partial class uc_ComposeMessage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRoleDLL();
            }
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

            ListItem li = new ListItem(" Select role ", "0");
            ddlrole.Items.Insert(0, li);
        }

        protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsersByRole(Convert.ToInt32(ddlrole.SelectedValue));
            //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
            //mpe.Show();

        }

        private void LoadUsersByRole(int RoleID)
        {
            UsersByRoleViewBLL _user = new UsersByRoleViewBLL();

            Roles role = new Roles();
            role.RoleID = RoleID;
            _user.Role = role;
            try
            {
                _user.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = _user.ResultSet.Tables[0].DefaultView;

            ddluser.DataSource = dv.ToTable();
            ddluser.DataTextField = "FullName";
            ddluser.DataValueField = "UserID";

            ddluser.DataBind();

            ListItem li = new ListItem(" Select user ", "0");
            ddluser.Items.Insert(0, li);
            //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
            //mpe.Show();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
            Common.Messages _message = new Common.Messages();
            _message.FromUserID = Convert.ToInt32(Session["UserID"]);
            _message.ToUserID = Convert.ToInt32(ddluser.SelectedValue);
            _message.MessageSubject = txtareaSubject.Text.Trim();
            _message.MessageText = txtareaMessage.Text.Trim();
            try
            {
                _messageInsert.messages = _message;
                _messageInsert.Invoke();
                //((Messages)this.Page).LoadUnReadData();
                HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
                if (hfShow.Value == "0")
                {
                    ((Messages)this.Parent.Page).LoadUnReadData();
                }
                else
                {
                    ((Messages)this.Parent.Page).LoadData();
                }
                ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
                mpe.Hide();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
            mpe.Hide();
            //((Messages)this.Page).LoadUnReadData();


            HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
            if (hfShow.Value == "0")
            {
                ((Messages)this.Parent.Page).LoadUnReadData();
            }
            else
            {
                ((Messages)this.Parent.Page).LoadData();
            }
            txtareaMessage.Text = "";
            txtareaSubject.Text = "";
            ddlrole.SelectedIndex = 0;
            ddluser.SelectedIndex = 0;

        }
    }
}