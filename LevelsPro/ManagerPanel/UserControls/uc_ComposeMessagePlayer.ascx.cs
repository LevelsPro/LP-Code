using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Insert;
using AjaxControlToolkit;

namespace LevelsPro.ManagerPanel.UserControls
{
    public partial class uc_ComposeMessagePlayer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSend_Click(object sender, EventArgs e)
        {

            MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
            Common.Messages _message = new Common.Messages();
            _message.FromUserID = Convert.ToInt32(Session["UserID"]);
            _message.ToUserID = Convert.ToInt32(Session["playerid"]);
            _message.MessageSubject = txtareaSubject.Text.Trim();
            _message.MessageText = txtareaMessage.Text.Trim();
            try
            {
                _messageInsert.messages = _message;
                _messageInsert.Invoke();
                //((Messages)this.Page).LoadUnReadData();
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

            txtareaMessage.Text = "";
            txtareaSubject.Text = "";
           

        }
    }
}