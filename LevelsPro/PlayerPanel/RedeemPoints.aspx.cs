using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using Common;
using BusinessLogic.Reports;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using LevelsPro.App_Code;
using BusinessLogic.Update;

namespace LevelsPro.PlayerPanel
{
    public partial class RedeemPoints : AuthorizedPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Points point = new Points();
            point.UserID = Convert.ToInt32(Session["userid"]);
            //UserPointsReportBLL _usersum = new UserPointsReportBLL();
            //try
            //{
            //    _usersum.Points = point;
            //    _usersum.Invoke();
            //}
            //catch (Exception ex)
            //{
            //}
            //DataView dv = _usersum.Sum.Tables[0].DefaultView;
            //DataTable dt = dv.ToTable();
            //if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            //{
            //    if (dt.Rows[1][0].ToString().Trim() != "")
            //    {
            //        //lblScore.Text = (Convert.ToInt32(dt.Rows[0][0]) + Convert.ToInt32(dt.Rows[1][0])).ToString();
            //    }
            //    else
            //    {
            //        //lblScore.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
            //    }
            //}
            //else
            //{
            //    //lblScore.Text = "0";
            //}
            if (!IsPostBack)
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    lblName.Text = Session["displayname"].ToString() + " - " + Resources.TestSiteResources.RedeemPoints;
                    ViewProfile.LoadData();
                }

                LoadData();
            }
        }

        protected void LoadData()
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
            dv.RowFilter = "Active=1";

            //dv.RowFilter = "User_ID=2";

            dlRewards.DataSource = dv.ToTable();
            dlRewards.DataBind();



        }
        public int SendMail(string strTo, string strSubject, string strBody)
        {
            int value = 0;
            try
            {
                //System.Web.Mail.MailMessage objMailMsg = new System.Web.Mail.MailMessage();
                //objMailMsg.To = strTo;
                //objMailMsg.From = System.Configuration.ConfigurationManager.AppSettings["SMTPFROM"];
                //objMailMsg.Subject = strSubject;
                //objMailMsg.Body = strBody;

                //System.Web.Mail.SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPSERVER"];                
                //objMailMsg.BodyFormat = MailFormat.Html; 

                //System.Web.Mail.SmtpMail.Send(objMailMsg);
                //value = 1;



                MailAddress sendFrom = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["SMTPFROM"].ToString());
                MailAddress sendTo = new MailAddress(strTo);

                MailMessage obEmail = new MailMessage(sendFrom, sendTo);
                obEmail.Priority = MailPriority.High;
                //objEmail.Body = pswd;           

                obEmail.Body = strBody;
                obEmail.Subject = strSubject;
                obEmail.IsBodyHtml = true;
                SmtpClient mysmtpClient = new SmtpClient();
                mysmtpClient.Host = System.Configuration.ConfigurationManager.AppSettings["SMTPSERVER"];
                //mysmtpClient.Port = int.Parse("25");
                mysmtpClient.Send(obEmail);

                value = 1;

            }
            catch (Exception ex)
            {
                value = 0;
            }
            return value;
        }
        protected void dlRewards_ItemCommand(object source, DataListCommandEventArgs e)
        {


            Label lblReward = e.Item.FindControl("lblRewardName") as Label;
            LinkButton lbtnRedeem = e.Item.FindControl("lbtnRedeem") as LinkButton;
            //lbtnRedeem.OnClientClick = "return confirm('Are you sure to delete Level.');";

            Points point = new Points();
            if (e.CommandName == "redeem")
            {
                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    point.UserID = Convert.ToInt32(Session["userid"]);
                }
                point.RedeemPoints = Convert.ToInt32(e.CommandArgument.ToString());
                point.RedeemPoints = point.RedeemPoints * -1;
                point.RewardID = int.Parse(dlRewards.DataKeys[e.Item.ItemIndex].ToString());


            }
            PointsInsertBLL points = new PointsInsertBLL();
            try
            {
                points.Points = point;
                points.Invoke();
            }
            catch (Exception ex)
            {
            }
            PointsViewBLL check = new PointsViewBLL();
            try
            {
                check.Invoke();
            }
            catch (Exception ex)
            {
            }
            RewardViewBLL reward = new RewardViewBLL();

           
            try
            {
                reward.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dvreward = reward.ResultSet.Tables[0].DefaultView;
            DataTable dtreward = new DataTable();

            dtreward = dvreward.ToTable();

            DataView dvpoints = check.ResultSet.Tables[0].DefaultView;
            int userid = Convert.ToInt32(Session["userid"]);
            dvpoints.RowFilter = "User_ID=" + userid;
            DataTable dtpoints = new DataTable();
            dtpoints = dvpoints.ToTable();
            //int count = 0;

            point.UserID = Convert.ToInt32(Session["userid"]);

            //UserPointsReportBLL _usersum = new UserPointsReportBLL();
            //try
            //{
            //    _usersum.Points = point;
            //    _usersum.Invoke();
            //}
            //catch (Exception ex)
            //{
            //}
            //DataView dvpsum = _usersum.Sum.Tables[0].DefaultView;
            //DataTable dtpsum = dvpsum.ToTable();
            //int sum = 0;
            //if (dtpsum != null && dtpsum.Rows.Count >= 1)
            //{
            //    if (dtpsum.Rows[1][0].ToString().Trim() != "")
            //    {
            //        sum = Convert.ToInt32(dtpsum.Rows[0][0]) + Convert.ToInt32(dtpsum.Rows[1][0]);
            //    }
            //    else
            //    {
            //        sum = Convert.ToInt32(dtpsum.Rows[0][0]);
            //    }
            //    //lblScore.Text = sum.ToString();
            //}
            //else
            //{
            //    //lblScore.Text = "0";
            //}
            int sum = Convert.ToInt32(Session["U_Points"]) - Convert.ToInt32(e.CommandArgument.ToString());
            Session["U_Points"] = sum;
            point.RedeemPoints = sum;
            UserPointsReportBLL _usersum = new UserPointsReportBLL();
            try
            {
                _usersum.Points = point;
                _usersum.Invoke();
            }
            catch (Exception ex)
            {
            }



            DataView dvsumfilter = reward.ResultSet.Tables[0].DefaultView;
            dvsumfilter.RowFilter = "Reward_Cost>=" + sum;
            DataTable dtsumfilter = new DataTable();

            dtsumfilter = dvsumfilter.ToTable();
            if (dtsumfilter.Rows.Count >= 1 && dtsumfilter != null)
            {
                for (int k = 0; k < dtsumfilter.Rows.Count; k++)
                {
                    if (dtsumfilter.Rows[k]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                    {

                        LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                        //button to linkbutton
                        //LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                        // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                        HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                        lbtnRedeem.OnClientClick = "return false;" ;
                        Div.Attributes["class"] = "locked-btn rdmption-btn";
                        chkbtn.Enabled = false;
                    }



                }
            }
            else
            {
                for (int k = 0; k < dtreward.Rows.Count; k++)
                {
                    if (dtreward.Rows[k]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                    {
                        LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                        //button to linkbutton
                        // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                        // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                        HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                        Div.Attributes["class"] = "rdmption-btn";

                        chkbtn.Enabled = true;
                    }
                }


            }



            for (int i = 0; i < dtpoints.Rows.Count; i++)
            {


                if (dtpoints.Rows[i]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                {
                    dvreward = reward.ResultSet.Tables[0].DefaultView;

                    dvreward.RowFilter = "Reward_ID=" + Convert.ToInt32(dtpoints.Rows[i]["Reward_ID"]);
                    dtreward = dvreward.ToTable();
                    int limit = Convert.ToInt32(dtreward.Rows[0]["Reward_Type"]);
                    if (limit == 0)
                    {
                        LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                    //button to linkbutton
                    // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                    // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                    HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                    Div.Attributes["class"] = "locked-btn rdmption-btn";
                    chkbtn.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["U_Points"]) >= Convert.ToInt32(dtreward.Rows[0]["Reward_Cost"]))
                        {
                            LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                            //button to linkbutton
                            // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                            // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                            HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                            Div.Attributes["class"] = "rdmption-btn";
                            chkbtn.Enabled = true;
                        }
                        else
                        {
                            LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                            //button to linkbutton
                            // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                            // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                            HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                            Div.Attributes["class"] = "locked-btn rdmption-btn";
                            chkbtn.Enabled = false;
                        }
                    //    for (int j = 0; j < dtpoints.Rows.Count; j++)
                    //    {

                    //        if (dtpoints.Rows[i]["Type_ID"].Equals(dtpoints.Rows[j]["Type_ID"]))
                    //        {
                    //            count++;

                    //        }

                    //    }
                    //    if (count == limit)
                    //    {

                    //        Button chkbtn = e.Item.FindControl("btnRedeem") as Button;
                    //        // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                    //        chkbtn.Enabled = false;

                    //    }
                    //    count = 0;

                    }
                }


            }

            if (Session["ManagerEmail"] != null && Session["ManagerEmail"].ToString() != "")
            {

                string strTo = Session["ManagerEmail"].ToString();

                string strSubject = "Redeem Points";

                String MessageBody = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                       + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has redeemed " +
                                       lblReward.Text.ToString() + " for points " + e.CommandArgument.ToString() + " at " + System.DateTime.Now.ToString();

                string strBody = MessageBody;

                int result = SendMail(strTo, strSubject, strBody);
                if (result > 0)
                {
                    //btnLogin.Visible = true;
                    // lblMeassage.Visible = true;
                    string sr = "Email sent.";
                }
            }



            //for Message sending to Player manager and Admins
            UserViewBLL _adminusers = new UserViewBLL();
            Common.User adminuser = new Common.User();

            adminuser.Where = "where U_SysRole = 'Admin'";
            _adminusers.User = adminuser;

            try
            {
                _adminusers.Invoke();
            }
            catch (Exception ex)
            {
            }

            MessagesInsertBLL _messageInsert = new MessagesInsertBLL();
            Common.Messages _message = new Common.Messages();

            foreach (DataRow dr in _adminusers.ResultSet.Tables[0].Rows)
            {
                _message.FromUserID = Convert.ToInt32(Session["UserID"]);
                _message.ToUserID = Convert.ToInt32(dr["UserID"]);
                _message.MessageSubject = "Points redeemed for reward";

                String MessageBody = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                       + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has redeemed " +
                                       lblReward.Text.ToString() + " for points " + e.CommandArgument.ToString() + " at " + System.DateTime.Now.ToString();

                _message.MessageText = MessageBody;
                try
                {
                    _messageInsert.messages = _message;
                    _messageInsert.Invoke();
                }
                catch (Exception ex)
                {
                }

            }


            _message.FromUserID = Convert.ToInt32(Session["UserID"]);
            if (Session["ManagerID"] != null)
            {
                _message.ToUserID = Convert.ToInt32(Session["ManagerID"]);
            }
            _message.MessageSubject = "Points redeemed for reward";

            String MessageMainBody = Session["displayname"].ToString() + " ( " + Session["username"].ToString() + " ) in "
                                       + Session["userrole"].ToString() + " at " + Session["sitename"].ToString() + " has redeemed " +
                                       lblReward.Text.ToString() + " for points " + e.CommandArgument.ToString() + " at " + System.DateTime.Now.ToString();

            _message.MessageText = MessageMainBody;
            try
            {
                _messageInsert.messages = _message;
                _messageInsert.Invoke();
            }
            catch (Exception ex)
            {
            }



            LoadData();
            Response.Redirect("RedeemPoints.aspx");
            // Response.Redirect("RedeemPoints.aspx");




        }

        protected void dlRewards_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            PointsViewBLL check = new PointsViewBLL();
            try
            {
                check.Invoke();
            }
            catch (Exception ex)
            {
            }
            RewardViewBLL reward = new RewardViewBLL();

            try
            {
                reward.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dvreward = reward.ResultSet.Tables[0].DefaultView;
            DataTable dtreward = new DataTable();

            dtreward = dvreward.ToTable();

            DataView dvpoints = check.ResultSet.Tables[0].DefaultView;
            int userid = Convert.ToInt32(Session["userid"]);
            dvpoints.RowFilter = "User_ID=" + userid;
            DataTable dtpoints = new DataTable();
            dtpoints = dvpoints.ToTable();
            //int count = 0;

            Points point = new Points();
            point.UserID = Convert.ToInt32(Session["userid"]);
            //UserPointsReportBLL _usersum = new UserPointsReportBLL();
            //try
            //{
            //    _usersum.Points = point;
            //    _usersum.Invoke();
            //}
            //catch (Exception ex)
            //{
            //}
            //DataView dvpsum = _usersum.Sum.Tables[0].DefaultView;
            //DataTable dtpsum = dvpsum.ToTable();
            //int sum = 0;
            //if (dtpsum != null && dtpsum.Rows.Count > 0 && dtpsum.Rows[0][0].ToString() != "")
            //{
            //    if (dtpsum.Rows[1][0].ToString().Trim() != "")
            //    {
            //        sum = Convert.ToInt32(dtpsum.Rows[0][0]) + Convert.ToInt32(dtpsum.Rows[1][0]);
            //    }
            //    else
            //    {
            //        sum = Convert.ToInt32(dtpsum.Rows[0][0]);
            //    }
            //    //lblScore.Text = sum.ToString();
            //}

            int sum = Convert.ToInt32(Session["U_Points"]);

            DataView dvsumfilter = reward.ResultSet.Tables[0].DefaultView;
            dvsumfilter.RowFilter = "Reward_Cost>" + sum;
            DataTable dtsumfilter = new DataTable();

            dtsumfilter = dvsumfilter.ToTable();

            if (dtsumfilter.Rows.Count >= 1)
            {
                for (int k = 0; k < dtsumfilter.Rows.Count; k++)
                {

                    if (dtsumfilter.Rows[k]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                    {

                        LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                        //button to linkbutton
                        // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                        // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]); 
                        HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                        Div.Attributes["class"] = "locked-btn rdmption-btn";
                        chkbtn.OnClientClick = "return false;";
                        chkbtn.Enabled = false;
                        // HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                        //Div.Style.Add("class", "locked-btn rdmption-btn");
                    }



                }
            }
            else
            {
                if (dtreward != null && dtreward.Rows.Count > 0)
                {
                    for (int k = 0; k < dtreward.Rows.Count; k++)
                    {
                        if (dtreward.Rows[k]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                        {
                            LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                            //button to linkbutton
                            // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                            // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                            HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                            Div.Attributes["class"] = "rdmption-btn";
                            chkbtn.Enabled = true;
                        }
                    }
                }


            }

            for (int i = 0; i < dtpoints.Rows.Count; i++)
            {


                if (dtpoints.Rows[i]["Reward_ID"].Equals(Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex])))
                {
                     dvreward = reward.ResultSet.Tables[0].DefaultView;

                    dvreward.RowFilter = "Reward_ID=" + Convert.ToInt32(dtpoints.Rows[i]["Reward_ID"]);
                    dtreward = dvreward.ToTable();
                     int limit = Convert.ToInt32(dtreward.Rows[0]["Reward_Type"]);
                    if (limit == 0)
                    {
                        LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                    //button to linkbutton
                    //LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;

                    // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                    chkbtn.Enabled = false;
                    //divscore.Attributes["class"] = "classOfYourChoice";
                    HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                    Div.Attributes["class"] = "locked-btn rdmption-btn";
                    chkbtn.OnClientClick = "return false;";
                    //Div.Style.Add("class", "locked-btn rdmption-btn");
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["U_Points"]) >= Convert.ToInt32(dtreward.Rows[0]["Reward_Cost"]))
                        {
                            LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                            //button to linkbutton
                            // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                            // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                            HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                            Div.Attributes["class"] = "rdmption-btn";
                            chkbtn.Enabled = true;
                        }
                        else
                        {
                            LinkButton chkbtn = e.Item.FindControl("lbtnRedeem") as LinkButton;
                            //button to linkbutton
                            // LinkButton chkbtn = e.Item.FindControl("btnRedeem") as LinkButton;
                            // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                            HtmlGenericControl Div = (HtmlGenericControl)e.Item.FindControl("divscore");
                            Div.Attributes["class"] = "locked-btn rdmption-btn";
                            chkbtn.OnClientClick = "return false;";
                            chkbtn.Enabled = false;
                        }
                        //for (int j = 0; j < dtpoints.Rows.Count; j++)
                        //{

                        //    if (dtpoints.Rows[i]["Reward_ID"].Equals(dtpoints.Rows[j]["Reward_ID"]))
                        //{
                        //    count++;

                        //}

                        //}
                        //if (count == limit)
                        //{

                        //    Button chkbtn = e.Item.FindControl("btnRedeem") as Button;
                        //    // int id = Convert.ToInt32(dlRewards.DataKeys[e.Item.ItemIndex]);
                        //    chkbtn.Enabled = false;

                        //}
                        //count = 0;

                    }
                }


            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            User user = new User();
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
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
    }
}