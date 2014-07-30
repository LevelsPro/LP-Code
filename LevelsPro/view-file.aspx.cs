using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DataAccess;
using System.Configuration;
using BusinessLogic.Select;

namespace LevelsPro
{
    public partial class view_file : System.Web.UI.Page
    {
        private String FileName = "abc";
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            string rewardid = "";
            string contestid = "";
            string fromType = "";
            string userid = "";
            if (Request.QueryString["id"] != null)
                id = Request.QueryString["id"];
            else if (Request.QueryString["rewardid"] != null)
                rewardid = Request.QueryString["rewardid"];
            else if (Request.QueryString["contestid"] != null)
                contestid = Request.QueryString["contestid"];
            else if (Request.QueryString["userid"] != null)
                userid = Request.QueryString["userid"];
            else
                throw new ArgumentException("No parameter specified");

            if (Request.QueryString["type"] != null)
                fromType = Request.QueryString["type"].ToString();




            string type = "image";
            string ext = ".jpg";
            byte[] buffer = new byte[10000000];
            if (fromType == "" && rewardid == "" && contestid == "" && userid == "")
            {
                AwardViewBLL award = new AwardViewBLL();
                try
                {
                    award.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = award.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Award_ID=" + id.ToString();

                DataTable dt = dv.ToTable();

                if (dt.Rows.Count > 0 && dt.Rows[0]["Award_Graphics_Ext"].ToString() != "")
                {
                    ext = dt.Rows[0]["Award_Graphics_Ext"].ToString();

                    switch (ext)
                    {
                        case ".jpg":
                            ext = ".jpeg";
                            break;
                        default:
                            break;
                    }

                    buffer = (byte[])dt.Rows[0]["Award_Graphics"];
                }
            }
            else if (rewardid == Request.QueryString["rewardid"])
            {
                RewardViewBLL reward = new RewardViewBLL();
                try
                {
                    reward.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = reward.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Reward_ID=" + rewardid.ToString();

                DataTable dt = dv.ToTable();

                if (dt.Rows.Count > 0 && dt.Rows[0]["Reward_Graphics_Ext"].ToString() != "")
                {
                    ext = dt.Rows[0]["Reward_Graphics_Ext"].ToString();

                    switch (ext)
                    {
                        case ".jpg":
                            ext = ".jpeg";
                            break;
                        default:
                            break;
                    }

                    buffer = (byte[])dt.Rows[0]["Reward_Graphics"];
                }
            }
            else if (contestid == Request.QueryString["contestid"])
            {
                PlayerContestViewBLL contest = new PlayerContestViewBLL();
                try
                {
                    contest.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dv = contest.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Contest_ID=" + contestid.ToString();

                DataTable dt = dv.ToTable();

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["Contest_Graphics_Ext"].ToString() != "")
                {
                    ext = dt.Rows[0]["Contest_Graphics_Ext"].ToString();

                    switch (ext)
                    {
                        case ".jpg":
                            ext = ".jpeg";
                            break;
                        default:
                            break;
                    }

                    buffer = (byte[])dt.Rows[0]["Contest_Graphics"];
                }
            }
            else if (fromType == "user")
            {
                UserImageViewBLL userimage = new UserImageViewBLL();
                try
                {
                    userimage.Invoke();
                }
                catch (Exception ex)
                {
                }
                DataView dv = userimage.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Active=1 AND U_UserIDImage=" + Convert.ToInt32(id);

                DataTable dt = dv.ToTable();

                if (dt.Rows.Count > 0 && dt.Rows[0]["U_UserImageExt"].ToString() != "")
                {
                    ext = dt.Rows[0]["U_UserImageExt"].ToString();

                    switch (ext)
                    {
                        case ".jpg":
                            ext = ".jpeg";
                            break;
                        default:
                            break;
                    }

                    buffer = (byte[])dt.Rows[0]["U_UserImage"];
                }
            }
            else if (fromType == "userid")
            {
                UserImageViewBLL userimage = new UserImageViewBLL();
                try
                {
                    userimage.Invoke();
                }
                catch (Exception ex)
                {
                }
                DataView dv = userimage.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Active=1 AND UserID=" + Convert.ToInt32(userid) + " AND U_Current=1";

                DataTable dt = dv.ToTable();
                if (dt.Rows.Count > 0 && dt.Rows[0]["U_UserImageExt"].ToString() != "")
                {

                    ext = dt.Rows[0]["U_UserImageExt"].ToString();

                    switch (ext)
                    {
                        case ".jpg":
                            ext = ".jpeg";
                            break;
                        default:
                            break;
                    }

                    buffer = (byte[])dt.Rows[0]["U_UserImage"];
                }
            }
            Response.Clear();
            Response.AddHeader("Content-type", ext.Substring(1));

            if ((ext == ".doc") || (ext == ".docx"))
                ext = ".vnd.word";
            Response.ContentType = String.Format("{0}/{1}", type, ext.Substring(1));
            Response.AddHeader("Content-Description", FileName);
            Response.OutputStream.Write(buffer, 0, buffer.Length);//

            Response.End();
        }
    }
}