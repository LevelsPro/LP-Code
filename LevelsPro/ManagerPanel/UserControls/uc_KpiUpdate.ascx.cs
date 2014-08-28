using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.PlayerPanel;
using BusinessLogic.Update;
using BusinessLogic.Select;
using System.Data;
using AjaxControlToolkit;

namespace LevelsPro.ManagerPanel.UserControls
{
    public partial class uc_KpiUpdate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {

            if (Convert.ToInt32(Session["chkmangerkpi"]) == 1)
            {
                Session["chkmangerkpi"] = 0;
                lblKPIText.Text = ReuseableItems.userkpitextmanager;
                lblKPIText.Text = lblKPIText.Text.Replace("X", ReuseableItems.userkpitargetmanager.ToString());
                txtKPI.Text = ReuseableItems.userkpiscoremanager.ToString();
            }
          
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int nextlevel = 0;
            String UserPoints = "0";
            ScoreManualUpdateBLL score = new ScoreManualUpdateBLL();
            Common.User user = new Common.User();
            user.UserID = Convert.ToInt32(Session["ManagerAsscociateID"]);
            user.CurrentLevel = Convert.ToInt32(Session["levelidmanager"]);
            if (Convert.ToInt32(txtKPI.Text) < ReuseableItems.userkpitargetmanager)
            {
                user.KPIID = Convert.ToInt32(ReuseableItems.userkpiidmanager);
                user.Score = Convert.ToInt32(txtKPI.Text);
                score.User = user;

                try
                {
                    score.Invoke();
                }
                catch (Exception ex)
                {

                }
             
                Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["ManagerAsscociateID"]));
                ModalPopupExtender mpe = this.Parent.FindControl("mpeViewProgressDetailsDiv") as ModalPopupExtender;
                mpe.Hide();
            }
            else if (Convert.ToInt32(txtKPI.Text) == ReuseableItems.userkpitargetmanager || Convert.ToInt32(txtKPI.Text) > ReuseableItems.userkpitargetmanager)
            {
                user.KPIID = user.KPIID = Convert.ToInt32(ReuseableItems.userkpiidmanager);
                user.Score = Convert.ToInt32(ReuseableItems.userkpitargetmanager);


                #region KPI Score Acheived


                UserTargetAchievedUpdateBLL popup = new UserTargetAchievedUpdateBLL();

                user.TargetID = Convert.ToInt32(ReuseableItems.userkpistargetidmanager);

                popup.User = user;
                try
                {
                    popup.Invoke();
                }
                catch (Exception ex)
                {
                }

                if (UserPoints != null && UserPoints != "")
                {
                    UserPoints = (Convert.ToInt32(ReuseableItems.userfullpointsdmanager) + ReuseableItems.usertargetpointsdmanager).ToString();
                    ReuseableItems.userfullpointsdmanager = Convert.ToInt32(UserPoints);
                }
                else
                {
                    UserPoints = ReuseableItems.usertargetpointsdmanager.ToString();
                }




                #endregion


                score.User = user;

                try
                {
                    score.Invoke();
                }
                catch (Exception ex)
                {

                }



                #region Level Changing Logic

            
                UserLevelPercentBLL userlevel = new UserLevelPercentBLL();
                userlevel.User = user;
                try
                {
                    userlevel.Invoke();
                }
                catch (Exception ex)
                {
                }

                if (userlevel.ResultSet != null && userlevel.ResultSet.Tables.Count > 0 && userlevel.ResultSet.Tables[0] != null && userlevel.ResultSet.Tables[0].Rows.Count > 0)
                {
                    nextlevel = Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["next_level"]);

                    TotalPlayerScoreViewBLL progress = new TotalPlayerScoreViewBLL();
                    progress.User = user;
                    try
                    {
                        progress.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                    if (progress.ResultSet != null && progress.ResultSet.Tables.Count > 0 && progress.ResultSet.Tables[0] != null && progress.ResultSet.Tables[0].Rows.Count > 0)
                    {
                        decimal percentage = 0;
                        decimal totalPercentage = 0;
                        foreach (DataRow dr in progress.ResultSet.Tables[0].Rows)
                        {
                            percentage += Convert.ToDecimal(dr["current_percentage"]);
                        }

                        totalPercentage = percentage / progress.ResultSet.Tables[0].Rows.Count;

                        if (totalPercentage >= 100)
                        {
                            PlayerTargetScoreViewBLL targetprogress = new PlayerTargetScoreViewBLL();
                            targetprogress.User = user;

                            try
                            {
                                targetprogress.Invoke();
                            }
                            catch (Exception ex)
                            {
                            }
                          



                            if (userlevel.ResultSet.Tables[0].Rows[0]["popup_showed"].ToString().ToLower() == "0")
                            {
                                //done logic

                                PopupShowedUpdateBLL popups = new PopupShowedUpdateBLL();
                                popups.User = user;
                                try
                                {
                                    popups.Invoke();
                                }
                                catch (Exception ex)
                                {
                                }

                                if (UserPoints != null && UserPoints != "")
                                {
                                    UserPoints = (Convert.ToInt32(ReuseableItems.userfullpointsdmanager) + Convert.ToInt32(userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString())).ToString();
                                    ReuseableItems.userfullpointsdmanager = Convert.ToInt32(UserPoints);
                                }
                                else
                                {
                                    UserPoints = userlevel.ResultSet.Tables[0].Rows[0]["Bonus"].ToString();
                                }

                                //
                            }


                            #region Page Reloading
                           
                            Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["ManagerAsscociateID"]));
                            ModalPopupExtender mpe = this.Parent.FindControl("mpeViewProgressDetailsDiv") as ModalPopupExtender;
                            mpe.Hide();



                            #endregion
                        }
                        else
                        {
                            Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["ManagerAsscociateID"]));
                          
                        }
                    }
                }
                #endregion
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["ManagerAsscociateID"]));
            ModalPopupExtender mpe = this.Parent.FindControl("mpeViewProgressDetailsDiv") as ModalPopupExtender;
            mpe.Hide();
        }
    }
}