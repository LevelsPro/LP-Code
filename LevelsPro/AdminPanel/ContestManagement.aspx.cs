using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using System.Drawing;
using LevelsPro.App_Code;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class ContestManagement : AuthorizedPage
    {
        private static string pageURL;
        protected void Page_Load(object sender, EventArgs e)
        {

            lblmessage.Visible = false;
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
                    Page.DataBind();

                    LoadRoles();
                    LoadData();
                    LoadSites();
                    LoadKPI();
                }
                catch (Exception exp)
                {
                    throw exp;
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void LoadKPI()
        {
            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlKPI.DataTextField = "KPI_name";
            ddlKPI.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlKPI.DataSource = dv.ToTable();
            ddlKPI.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlKPI.Items.Insert(0, li);
        }

        private void LoadSites()
        {
            Site_DropDownBLL selectddlSite = new Site_DropDownBLL();
            try
            {
                selectddlSite.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlSite.DataTextField = "site_name";
            ddlSite.DataValueField = "site_id";

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlSite.DataSource = dv.ToTable();
            ddlSite.DataBind();

            //ddlSite.SelectedValue = Session["siteid"].ToString();


            ListItem li = new ListItem("Select", "0");
            ddlSite.Items.Insert(0, li);
            ddlSite.SelectedIndex = 0;
        }

        protected void LoadData()
        {
            ContestViewBLL contest = new ContestViewBLL();
            try
            {
                contest.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //gvContest.DataSource = contest.ResultSet;
            //gvContest.DataBind();
            dlContest.DataSource = contest.ResultSet;
            dlContest.DataBind();
        }

        protected void LoadRoles()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlRole.DataTextField = "Role_Name";
            ddlRole.DataValueField = "Role_ID";

            DataView dv = role.ResultSet.Tables[0].DefaultView;

            //dv.RowFilter = "Active=1 AND site_id=" + Session["siteid"];
            dv.RowFilter = "Active=1";

            ddlRole.DataSource = dv.ToTable();
            ddlRole.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlRole.Items.Insert(0, li);
        }

        protected void gvContest_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (gvContest.SelectedIndex != -1)
            {
                lblmessage.Visible = false;
                Label lblRoleID = (Label)gvContest.SelectedRow.FindControl("lblRoleID");
                Label lblSiteID = (Label)gvContest.SelectedRow.FindControl("lblSiteID");
                Label lblKPIID = (Label)gvContest.SelectedRow.FindControl("lblKPIID");
                Label lblActive = (Label)gvContest.SelectedRow.FindControl("lblActive");
                Label lblContestGraphicExt = (Label)gvContest.SelectedRow.FindControl("lblContestGraphicExt");
                System.Web.UI.WebControls.Image imgContestImage = (System.Web.UI.WebControls.Image)gvContest.SelectedRow.FindControl("imgContestImage");
                ViewState["ContestGraphicExt"] = lblContestGraphicExt.Text.Trim();
                hplView.NavigateUrl = "~/view-file.aspx?contestid=" + gvContest.SelectedDataKey[0].ToString();
                txtContestName.Text = gvContest.SelectedRow.Cells[5].Text.Trim();
                // txtContestDur.Text = gvContest.SelectedRow.Cells[6].Text.Trim();
                txtStartDate.Text = gvContest.SelectedRow.Cells[7].Text.Trim();
                txtEndDate.Text = gvContest.SelectedRow.Cells[8].Text.Trim();
                ddlSite.SelectedValue = lblSiteID.Text.Trim();
                ddlKPI.SelectedValue = lblKPIID.Text.Trim();

                if (lblRoleID.Text == "" || lblRoleID.Text == null)
                {
                    ddlRole.SelectedIndex = 0;
                }
                else
                {
                    ddlRole.SelectedValue = lblRoleID.Text.Trim();
                }


                if (lblActive.Text.Trim().ToLower() == "true")
                {
                    cbActive.Checked = true;
                }
                else
                {
                    cbActive.Checked = false;
                }
                hplView.Visible = true;
                trActive.Visible = true;
                btnAddContest.Text = Resources.TestSiteResources.Update;

                #region Not Used Commented Code
                /////CompareValidator1.ValidationGroup = "update";
                /////CompareValidator1.Visible = false;
                //  CompareValidator2.ValidationGroup = "update";
                #endregion

                rfvGraphic.ValidationGroup = "update";
            }

        }
        protected void btnAddContest_Click(object sender, EventArgs e)
        {
            if (txtContestName.Text.Equals(""))
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Provide country to add')</script>", false);
                return;
            }
            else
            {
                
                Contest contest = new Contest();
                contest.ContestName = txtContestName.Text.Trim();
                // contest.ContestDur = Convert.ToInt32(txtContestDur.Text.Trim());
                if (ddlRole.SelectedIndex > 0)
                {
                    contest.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                }
                else
                {
                    contest.RoleID = null;
                }
                //CompareValidator1.ValueToCompare = DateTime.Now.ToShortDateString();

                contest.ContestStartDate = txtStartDate.Text.Trim();

                contest.ContestEndDate = txtEndDate.Text.Trim();
                contest.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
                contest.KPIID = Convert.ToInt32(ddlKPI.SelectedValue);



                if (fileContestImage.HasFile)
                {
                    string ext = string.Empty;
                    contest.ContestGraphics = fileContestImage.FileBytes;

                    int index = fileContestImage.FileName.LastIndexOf('.');
                    ext = fileContestImage.FileName.Substring(index + 1);
                    contest.ContestGraphicsExt = ext;
                }
                else
                {
                    ContestViewBLL ContestObj = new ContestViewBLL();
                    try
                    {
                        ContestObj.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    DataView dv = ContestObj.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "Contest_ID=" + gvContest.SelectedDataKey[0].ToString();

                    DataTable dt = dv.ToTable();

                    contest.ContestGraphics = (byte[])dt.Rows[0]["Contest_Graphics"];
                    contest.ContestGraphicsExt = dt.Rows[0]["Contest_Graphics_Ext"].ToString();
                }



                if (btnAddContest.Text == "Update" || btnAddContest.Text == "mettre à jour" || btnAddContest.Text == "actualizar")
                {
                    DateTime dtStartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
                    DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim());

                    #region Not Used Commented Code
                    //DateTime dtCurDate = DateTime.Now;

                    //if (dtCurDate.Date <= dtStartDate.Date)
                    //{
                    #endregion

                    if (dtStartDate < dtEndDate)
                        {
                        }
                        else
                        {

                            //alert("End Date Must be Greater Than Start Date")
                            lblmessage.Visible = true;
                            lblmessage.Text = "End Date Must be Greater Than Start Date.";
                            return;
                        }

                    #region Not Used Commented Code
                        //}
                    //else
                    //{
                    //    //alert("Start Date Must be Greater Than Current Date");
                    //    lblmessage.Visible = true;
                    //    lblmessage.Text = "Start Date Must be Greater Than Current Date.";
                    //    return;
                        //}
                        #endregion


                    lblmessage.Visible = false;

                    ContestUpdateBLL UpdateContest = new ContestUpdateBLL();
                    contest.ContestID = int.Parse(gvContest.SelectedDataKey[0].ToString());
                    if (cbActive.Checked)
                    {
                        contest.Active = 1;
                    }
                    else
                    {
                        contest.Active = 0;
                    }
                    UpdateContest.Contest = contest;
                    try
                    {
                        UpdateContest.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.Contest + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Contest;
                    }
                    lblmessage.Visible = true;
                }
                else if (btnAddContest.Text == "Add" || btnAddContest.Text == "Ajouter" || btnAddContest.Text == "añadir")
                {
                    DateTime dtStartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
                    DateTime dtEndDate = Convert.ToDateTime(txtEndDate.Text.Trim());
                    DateTime dtCurDate = DateTime.Now;

                    if (dtCurDate.Date <= dtStartDate.Date)
                    {
                        if (dtStartDate < dtEndDate)
                        {
                        }
                        else
                        {

                            lblmessage.Visible = true;
                            lblmessage.Text = "End Date Must be Greater Than Start Date.";
                            return;
                        }
                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Start Date Must be Greater Than Current Date.";
                        return;
                    }

                    lblmessage.Visible = false;

                    #region Not Used Commented Code
                    //ContestViewBLL contestView = new ContestViewBLL();
                    //try
                    //{
                    //    contestView.Invoke();
                    //}
                    //catch (Exception ex)
                    //{
                    //    //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                    //}

                    //DataView dv = contestView.ResultSet.Tables[0].DefaultView;

                    //dv.RowFilter = "Contest_Name='" + txtContestName.Text.Trim() + "'";

                    //if (dv.ToTable().Rows.Count < 1)
                    //{
                    #endregion

                    ContestInsertBLL insertContest = new ContestInsertBLL();
                    insertContest.Contest = contest;
                    lblmessage.Visible = true;
                    try
                    {
                        insertContest.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.Contest + ' ' + Resources.TestSiteResources.SavedMessage;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.Contest + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.Contest;
                        }
                    }
                    lblmessage.Visible = true;

                    #region Not Used Commented Code
                    //}
                    //else
                    //{
                    //    lblmessage.Visible = true;
                    //    lblmessage.Text = Resources.TestSiteResources.Contest + ' ' + Resources.TestSiteResources.Already;
                    //}
                    #endregion

                }

                btnAddContest.Text = Resources.TestSiteResources.Add;
                rfvGraphic.ValidationGroup = "Insertion";

                #region Not Used Commented Code
                /////CompareValidator1.ValidationGroup = "Insertion";
                /////CompareValidator1.Visible = true;
                // CompareValidator2.ValidationGroup = "Insertion";
                #endregion

                txtContestName.Text = "";
                //txtContestDur.Text = "";
                ddlRole.SelectedIndex = 0;
                ddlSite.SelectedIndex = 0;
                ddlKPI.SelectedIndex = 0;
                txtStartDate.Text = "";
                txtEndDate.Text = "";
                cbActive.Checked = false;
                trActive.Visible = false;
                hplView.Visible = false;
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddContest.Text = Resources.TestSiteResources.Add;
            rfvGraphic.ValidationGroup = "Insertion";

            #region Not Used Commented Code
            /////CompareValidator1.ValidationGroup = "Insertion";
            /////CompareValidator1.Visible = true;
            #endregion

            txtContestName.Text = "";
            //txtContestDur.Text = "";
            ddlRole.SelectedIndex = 0;
            ddlKPI.SelectedIndex = 0;
            ddlSite.SelectedIndex = 0;
            cbActive.Checked = false;
            gvContest.SelectedIndex = -1;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            trActive.Visible = false;
            hplView.Visible = false;
            try
            {
                LoadData();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void gvContest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                tc.Attributes["style"] = "border-color: #ebeef1";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell tc in e.Row.Cells)
                {
                    tc.Attributes["style"] = "border-color: #ebeef1";
                }

                Label lblActiveGrid = (Label)e.Row.FindControl("lblActive");

                if (lblActiveGrid.Text.Trim() == "0")
                {
                    e.Row.BackColor = Color.LightGray;
                    //e.Row.ForeColor = Color.White;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}