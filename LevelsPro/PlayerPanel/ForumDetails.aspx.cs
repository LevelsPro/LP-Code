using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using Common;
using BusinessLogic.Insert;
using System.Data;
using BusinessLogic.Update;

namespace LevelsPro.PlayerPanel
{
    public partial class ForumDetails : System.Web.UI.Page
    {
        PostDetaislBLL _pDetail = new PostDetaislBLL();
        PostReplyInsertBLL _pReply = new PostReplyInsertBLL();
        RepliedLikeStatusBLL _pLikeStatus = new RepliedLikeStatusBLL();
        PostRepliedLikeInsertBLL _pRepliedLikeInsert = new PostRepliedLikeInsertBLL();
        GetPostByIDBLL _getPost = new GetPostByIDBLL();
        Posts _posts = new Posts();
        PostRepliedLike _repliedLike = new PostRepliedLike();
        PostRepliedLike _repliedLike2 = new PostRepliedLike();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["userid"] != null && Session["userid"].ToString() != "")
                    {
                        lblName.Text = Session["displayname"].ToString() + " - Forums";
                    }
                    DataSet dsPost = new DataSet();
                    _getPost.PostID = Convert.ToInt32(Request.QueryString["PostID"]);
                    _getPost.Invoke();
                    dsPost = _getPost.ResultSet;
                    if (dsPost != null && dsPost.Tables[0].Rows.Count > 0)
                    {
                        lblQuestion.Text = dsPost.Tables[0].Rows[0]["PostMessage"].ToString();
                    }
                    ViewProfile.LoadData();
                    LoadPostReplies();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReply.Text != "")
                {
                    PostReplies _postReply = new PostReplies();
                    _postReply.ReplyMessage = txtReply.Text;
                    _postReply.RepliedBy = Convert.ToInt32(Session["userid"]);
                    _postReply.ReplyDate = DateTime.Now;
                    _postReply.PostID = Convert.ToInt32(Request.QueryString["PostID"]);


                    _pReply.PostReplies = _postReply;
                    _pReply.Invoke();
                    LoadPostReplies();
                    txtReply.Text = "";
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void LoadPostReplies()
        {
            _posts.PostID = Convert.ToInt32(Request.QueryString["PostID"]);
            _pDetail.Post = _posts;
            _pDetail.Invoke();
            DataSet dSet = new DataSet();
            dSet = _pDetail.ResultSet;

            dlPostDetails.DataSource = dSet.Tables[0];
            dlPostDetails.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected bool GetLikeStatus(int ReplyID)
        {
            try
            {
                _repliedLike.LikedBy = Convert.ToInt32(Session["userid"]);
                _repliedLike.LikeID = ReplyID;
                _repliedLike.PostID = Convert.ToInt32(Request.QueryString["PostID"]);

                _pLikeStatus.Post = _repliedLike;
                _pLikeStatus.Invoke();
                DataSet dSet = new DataSet();
                dSet = _pLikeStatus.ResultSet;

                if (dSet != null && dSet.Tables.Count > 0)
                {
                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dSet.Tables[0].Rows[0]["TotalLikes"]) > 0)
                            return false;
                        else
                            return true;
                    }
                }
            }
            catch(Exception e)
            {
            }
            return true;
        }

        protected void dlPostDetails_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Button btnKLike = (Button)e.Item.FindControl("btnLike");
          // btnKLike.Enabled = GetLikeStatus(e.Item.
        }

        protected void dlPostDetails_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Like")
                {
                    _repliedLike2.LikedBy = Convert.ToInt32(Session["userid"]);
                    _repliedLike2.LikeID = Convert.ToInt32(e.CommandArgument);
                    _repliedLike2.PostID = Convert.ToInt32(Request.QueryString["PostID"]);

                    _pRepliedLikeInsert.PostRepliedLike = _repliedLike2;
                    _pRepliedLikeInsert.Invoke();

                    LoadPostReplies();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}