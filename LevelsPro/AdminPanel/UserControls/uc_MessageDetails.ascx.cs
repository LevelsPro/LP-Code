using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Delete;
using BusinessLogic.Insert;
using System.Configuration;
using BusinessLogic.Select;
using System.Data;

namespace LevelsPro.AdminPanel.UserControls
{
    public partial class uc_MessageDetails : System.Web.UI.UserControl
    {
        //string touserid = "";
        //string messageid = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void loadData(int id)
        {

            MessagesViewBLL messageview = new MessagesViewBLL();

            try
            {
                messageview.Invoke();
            }
            catch (Exception ex)
            {
            }

            DataView dv = messageview.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "ID=" + id;

            DataTable dt = dv.ToTable();

            if (dt != null && dt.Rows.Count > 0)
            {
                imgUser.ImageUrl = "../" + ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + dt.Rows[0]["Player_Thumbnail"].ToString();
                lblFrom.Text = dt.Rows[0]["FullName"].ToString();
                lblSubject.Text = dt.Rows[0]["Message_Subject"].ToString();
                lblDate.Text = Convert.ToDateTime(dt.Rows[0]["Sent_Date"]).ToString("MMMM dd,yyyy");
                pdesc.InnerText = dt.Rows[0]["Message_Text"].ToString();
                //hfToUser_ID.Value = dt.Rows[0]["To_UserID"].ToString();
                //hfMessageID.Value = dt.Rows[0]["ID"].ToString();
                //touserid = hfToUser_ID.Value.ToString();
                //messageid = hfMessageID.Value.ToString();
                Session["touserid"] = dt.Rows[0]["From_UserID"].ToString();
                Session["messageid"] = dt.Rows[0]["ID"].ToString();
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
            if (hfShow.Value == "0")
            {
                ((Messages)this.Parent.Page).LoadUnReadData();
            }
            else
            {
                ((Messages)this.Parent.Page).LoadData();
            }


        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
            if (hfShow.Value == "0")
            {
                ((Messages)this.Parent.Page).LoadUnReadData();
            }
            else
            {
                ((Messages)this.Parent.Page).LoadData();
            }
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            MessageReplyInsertBLL _messageInsert = new MessageReplyInsertBLL();
            Common.Messages _message = new Common.Messages();
            _message.FromUserID = Convert.ToInt32(Session["UserID"]);
            _message.ToUserID = Convert.ToInt32(Session["touserid"]);
            _message.MessageSubject = "Re: " + lblSubject.Text.Trim();
            _message.MessageText = txtReply.Text.Trim();
            _message.MessageID = Convert.ToInt32(Session["messageid"]);

            try
            {
                _messageInsert.messages = _message;
                _messageInsert.Invoke();
                ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
                mpe.Hide();
                HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
                if (hfShow.Value == "0")
                {
                    ((Messages)this.Parent.Page).LoadUnReadData();
                }
                else
                {
                    ((Messages)this.Parent.Page).LoadData();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Session["messageid"] != null && Session["messageid"].ToString() != "")
            {
                int MessageID = Convert.ToInt32(Session["messageid"]);
                MessageDeleteBLL msgBLL = new MessageDeleteBLL();
                Common.Messages msg = new Common.Messages();

                msg.MessageID = MessageID;

                msgBLL.Message = msg;

                try
                {
                    msgBLL.Invoke();
                    ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
                    mpe.Hide();
                    HiddenField hfShow = (HiddenField)this.Parent.FindControl("hfShowAll");
                    if (hfShow.Value == "0")
                    {
                        ((Messages)this.Parent.Page).LoadUnReadData();
                    }
                    else
                    {
                        ((Messages)this.Parent.Page).LoadData();
                    }
                }
                catch
                {

                }
            }
        }
    }
}