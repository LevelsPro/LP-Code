using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using BusinessLogic.Delete;
using Common;
using BusinessLogic.Insert;
using System.Data;
using BusinessLogic.Select;

namespace LevelsPro.ManagerPanel
{
    public partial class AssignAward : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadAwards();
                if (Session["playerid"] != null && Session["playerid"].ToString() != "")
                {
                    ViewState["playerid"] = Session["playerid"];
                    LoadData(Convert.ToInt32(ViewState["playerid"]));
                    Label2.Text = Resources.TestSiteResources.AssignAward1 + " to " + Session["playernamemanager"].ToString();
                }
                //if (Session["playerid"] != null && Session["playerid"].ToString() != "")
                //{
                //    ViewState["playerid"] = Session["playerid"];
                //    LoadData(Convert.ToInt32(ViewState["playerid"]));
                //}

            }
                
        }
        protected void LoadData(int UserID)
        {

            if (UserID > 0)
            {
                Label2.Text = Resources.TestSiteResources.AssignAward1 + " to " + Session["playernamemanager"].ToString();

                ManualAwardViewBLL manual = new ManualAwardViewBLL();
                UserAwards userawards = new UserAwards();
                userawards.User_Id = UserID;
                manual.UserAwards = userawards;
                try
                {
                    manual.Invoke();
                }
                catch
                {

                }

                if (manual.ResultSet != null && manual.ResultSet.Tables.Count > 0 && manual.ResultSet.Tables[0] != null && manual.ResultSet.Tables[0].Rows.Count > 0)
                {
                    dlAwards.DataSource = manual.ResultSet;
                    dlAwards.DataBind();
                }
                else
                {
                    dlAwards.DataSource = null;
                    dlAwards.DataBind();
                }
            }
        }
        public void LoadAwards()
        {
            AwardViewBLL award = new AwardViewBLL();
            DataSet dsAwards = new DataSet();
            try
            {
                award.Invoke();
            }
            catch (Exception ex)
            {
            }
            dsAwards = award.ResultSet;

            ddlAward.DataTextField = "Award_Name";
            ddlAward.DataValueField = "Award_ID";

            DataView dv = dsAwards.Tables[0].DefaultView;

            dv.RowFilter = "Award_Manual = 1";
            DataTable dt = dv.ToTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlAward.DataSource = dt;
                ddlAward.DataBind();
            }

            ListItem li = new ListItem("Select", "0");
            ddlAward.Items.Insert(0, li);
        }
        protected void btnAssignAward_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["playerid"] != null && ViewState["playerid"].ToString() != "")
                {
                    UserAwards Awards = new UserAwards();
                    Awards.User_Id = Convert.ToInt32(ViewState["playerid"]);
                    Awards.Award_Id = Convert.ToInt32(ddlAward.SelectedValue);
                    Awards.AwardDate = DateTime.Now;
                    Awards.Manual = 1;
                    Awards.AwardedBy = Convert.ToInt32(Session["Userid"]);

                    UserAwardInsertBLL insert = new UserAwardInsertBLL();
                    insert.Award = Awards;
                    insert.Invoke();

                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.AssignedAward;

                    //ddlAward.SelectedValue = "0";


                    LoadData(Convert.ToInt32(ViewState["playerid"]));
                }
            }
            catch (Exception ex)
            {
                lblmessage.Visible = true;
                if (ex.Message.Contains("Duplicate"))
                {
                    lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.AlreadyAssigned;
                }
                else
                {
                    lblmessage.Text = Resources.TestSiteResources.NotAssigned;
                }
            }

            //ModalPopupExtender mpe1 = (ModalPopupExtender)this.Parent.FindControl("mpeViewMessageDetailsDiv");
            //mpe1.Show();

            //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeComposeMessageDiv");
            //mpe.Hide();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ddlAward.SelectedValue = "0";
            lblmessage.Text = "";
            //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeViewMessageDetailsDiv");
            //mpe.Hide();

        }



        protected void dlAwards_ItemCommand1(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DeleteAward")
            {
                AssignAwardDeleteBLL awarddelete = new AssignAwardDeleteBLL();
                Award _award = new Award();
                _award.AwardID = Convert.ToInt32(e.CommandArgument);
                _award.UserID = Convert.ToInt32(ViewState["playerid"]);
                awarddelete.Award = _award;
                try
                {
                    awarddelete.Invoke();
                }
                catch (Exception ex)
                {
                }

                LoadData(Convert.ToInt32(ViewState["playerid"]));
            }
        }

        protected void exit_Click(object sender, ImageClickEventArgs e)
        {
            ddlAward.SelectedValue = "0";
            lblmessage.Text = "";
            Response.Redirect("PlayerPerformance.aspx?id=" + Convert.ToInt32(Session["playerid"]) + "&likelihood=" + Session["likelihood"] + "&remaining=" + Convert.ToInt32(Session["remaining"]) + "&Base=" + Convert.ToInt32(Session["Base"]), false);
            //Response.Redirect("PlayerPerformance.aspx");
            //ModalPopupExtender mpe = (ModalPopupExtender)this.Parent.FindControl("mpeViewMessageDetailsDiv");
            //mpe.Hide();
        }

      
    }
}