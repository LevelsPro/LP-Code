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
using LevelsPro.Util;
using log4net;
using Common.Utils;

namespace LevelsPro.PlayerPanel
{
    public partial class RedeemPoints : AuthorizedPage
    {
        private static string pageURL;
        private  ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                

                Points point = new Points();
                point.UserID = Convert.ToInt32(Session["userid"]);

                if (Session["userid"] != null && Session["userid"].ToString() != "")
                {
                    lblName.Text = Session["displayname"].ToString() + " - " + Resources.TestSiteResources.RedeemPoints;
                    ViewProfile.LoadData();
                }


                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                   throw exp;
                }
                if (Session["Redeemed"] != null && Session["Redeemed"].Equals(1))
                {
                    Session["Redeemed"] = 0;
                    Response.Write("<script>alert('Congratulations, you have redeem a reward " + Session["RedeemedRewardName"].ToString() + " ');</script>");

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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
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
               
                throw ex;
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
            try
            {

                Label lblReward = e.Item.FindControl("lblRewardName") as Label;
                LinkButton lbtnRedeem = e.Item.FindControl("lbtnRedeem") as LinkButton;
                //lbtnRedeem.OnClientClick = "return confirm('Are you sure to delete Level.');";
                //+Moiz Logging Test
                Session["DebLogString"] = " [User : " + Session["userid"] + "]- Message : " + "Selected [Item =" + lblReward.Text + " ] to be redeemed";
                log.Debug(Session["DebLogString"]);
                //-Moiz
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
                
                points.Points = point;
                points.Invoke();
                
                PointsViewBLL check = new PointsViewBLL();
                
                check.Invoke();
                
                RewardViewBLL reward = new RewardViewBLL();

                reward.Invoke();
               
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

                
                int sum = Convert.ToInt32(Session["U_Points"]) - Convert.ToInt32(e.CommandArgument.ToString());
                // Session["U_Points"] = sum;
                Session["U_Points"] = sum;
                point.RedeemPoints = sum;
                UserPointsReportBLL _usersum = new UserPointsReportBLL();
                
                _usersum.Points = point;
                _usersum.Invoke();
               
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
                            lbtnRedeem.OnClientClick = "return false;";
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
                            
                        }
                    }


                }

                Session["RedeemedRewardName"] = lblReward.Text;
                Session["Redeemed"] = 1;

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
                        string sr = "Email sent.";
                    }
                }



                //for Message sending to Player manager and Admins
                UserViewBLL _adminusers = new UserViewBLL();
                Common.User adminuser = new Common.User();

                adminuser.Where = "where U_SysRole = 'Admin'";
                _adminusers.User = adminuser;
                              
                _adminusers.Invoke();
                

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
                   
                    _messageInsert.messages = _message;
                    _messageInsert.Invoke();
                   
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
                
                _messageInsert.messages = _message;
                _messageInsert.Invoke();
                
                LoadData();
                Session["DebLogString"] = " [User : " + Session["userid"] + "]- Message : " + "[Item= " + lblReward.Text + "]" + "SuccessFully Redeemed";
                log.Debug(Session["DebLogString"]);
                Response.Redirect("RedeemPoints.aspx",false);
                // Response.Redirect("RedeemPoints.aspx");
            }
            catch (Exception ex)
            {
                ExceptionUtility.ExceptionLogString(ex, Session);
                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                log.Debug(Session["ExpLogString"]);

                if (ex.Message.ToLower().Contains("duplicate"))
                { }
                else
                    throw ex;
            }



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
                
                throw ex;
            }
            RewardViewBLL reward = new RewardViewBLL();

            try
            {
                reward.Invoke();
            }
            catch (Exception ex)
            {
                
                throw ex;
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
                throw ex;
            }

            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
      
    }
}