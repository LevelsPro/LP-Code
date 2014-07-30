using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using System.Data;
using Common;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class SiteEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSiteTypes();
                LoadData();
            }
        }
        #region add and update site
        protected void btnAddSite_Click(object sender, EventArgs e)
        {
            if (txtSiteName.Text.Equals(""))
            {
                return;
            }
            else
            {
                Common.Site site = new Common.Site();
                site.SiteName = txtSiteName.Text.Trim();
                site.SiteTypeName = ddlSiteType.SelectedItem.Text;
                site.SiteAddress = txtSiteAddress.Text.Trim();


                if (btnAddSite.Text == "Update" || btnAddSite.Text == "mettre à jour" || btnAddSite.Text == "actualizar")
                {
                    SiteUpdateBLL UpdateSite = new SiteUpdateBLL();

                    site.SiteID = Convert.ToInt32(Request.QueryString["siteid"]);
                    if (cbActive.Checked)
                    {
                        site.Active = 1;
                    }
                    else
                    {
                        site.Active = 0;
                    }
                    UpdateSite.Site = site;
                    lblmessage.Visible = true;
                    try
                    {
                        UpdateSite.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.SiteH + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.SiteH;
                    }
                }
                else if (btnAddSite.Text == "Add" || btnAddSite.Text == "Ajouter" || btnAddSite.Text == "añadir")
                {
                    SiteInsertBLL insertSite = new SiteInsertBLL();
                    insertSite.Site = site;
                    lblmessage.Visible = true;
                    try
                    {
                        insertSite.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.SiteH + ' ' + Resources.TestSiteResources.SavedMessage;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.SiteH + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.SiteH;
                        }
                    }
                }

                btnAddSite.Text = Resources.TestSiteResources.Add;
                txtSiteName.Text = "";
                ddlSiteType.SelectedIndex = 0;
                txtSiteAddress.Text = "";
                cbActive.Checked = false;
                
                LoadData();
                Response.Redirect("SiteManagement.aspx");
            }
        }
        #endregion
        protected void btnCancelSite_Click(object sender, EventArgs e)
        {
            btnAddSite.Text = Resources.TestSiteResources.Add;
            txtSiteName.Text = "";
            ddlSiteType.SelectedIndex = 0;
            txtSiteAddress.Text = "";
            cbActive.Checked = false;
            Response.Redirect("SiteManagement.aspx");
           
        }

      

  

        protected void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["siteid"]);


            if (id != 0)
            {
                lblActive.Visible = true;
                cbActive.Visible = true;
                lblHeading.Text = Resources.TestSiteResources.EditSite;
                
                SiteViewBLL site = new SiteViewBLL();
                try
                {
                    site.Invoke();
                }
                catch (Exception ex)
                {
                    
                }
                DataView dv = site.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "site_id=" + id.ToString();

                DataTable dt = new DataTable();
                dt = dv.ToTable();
                lblmessage.Visible = false;

                txtSiteName.Text= dt.Rows[0]["site_name"].ToString();
                txtSiteAddress.Text = dt.Rows[0]["site_address"].ToString();
                ddlSiteType.SelectedValue = ddlSiteType.Items.FindByText(dt.Rows[0]["site_type"].ToString()).Value;
                if (dt.Rows[0]["Active"].ToString() == "True")
                {
                    cbActive.Checked = true;
                }
                else
                {
                    cbActive.Checked = false;
                }
                lblmessage.Visible = false;
            
                btnAddSite.Text = Resources.TestSiteResources.Update;
                ;

            }
            else
            {
                lblHeading.Text = Resources.TestSiteResources.Add + " " + Resources.TestSiteResources.Site;
                
                lblActive.Enabled = false;
                cbActive.Enabled= false;

            }
        }

        protected void LoadSiteTypes()
        {
            DropdownViewBLL dropdown = new DropdownViewBLL();
            Dropdown _dropdown = new Dropdown();
            _dropdown.ReferenceCode = "SITE_TYPE";
            dropdown.Dropdown = _dropdown;

            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {

            }

            if (dropdown.ResultSet != null && dropdown.ResultSet.Tables.Count > 0 && dropdown.ResultSet.Tables[0] != null && dropdown.ResultSet.Tables[0].Rows.Count > 0)
            {
                ddlSiteType.DataTextField = "Description";
                ddlSiteType.DataValueField = "ReferenceData_ID";

                ddlSiteType.DataSource = dropdown.ResultSet;//dropdown.ResultSet;
                ddlSiteType.DataBind();

                ListItem li = new ListItem("Select", "0");
                ddlSiteType.Items.Insert(0, li);
            }
        }

       

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
    }
}