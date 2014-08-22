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
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class KPIEdit : AuthorizedPage
    {

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                LoadKPIType();
                LoadCategory();
                LoadData();
                
            }

        }
        protected void LoadData()
        {
            if (Request.QueryString["kpiid"] != null && Request.QueryString["kpiid"].ToString() != "")
            {
                int id = Convert.ToInt32(Request.QueryString["kpiid"]);


                if (id != 0)
                {
                    lblActive.Visible = true;
                    cbActive.Visible = true;
                    lblHeading.Text = Resources.TestSiteResources.EditKPI;
                    KPIViewBLL kpi = new KPIViewBLL();
                    try
                    {
                        kpi.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }
                    DataView dv = kpi.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "KPI_ID=" + id.ToString();

                    DataTable dt = new DataTable();
                    dt = dv.ToTable();
                    lblmessage.Visible = false;

                    txtKPIName.Text = dt.Rows[0]["KPI_name"].ToString();

                    txtKPIMeasure.Text = dt.Rows[0]["KPI_measure"].ToString();
                    txtDescp.Text = dt.Rows[0]["KPI_Descp"].ToString();
                    ddlKPIType.SelectedValue = dt.Rows[0]["KPI_type"].ToString();
                    ddlCategory.SelectedValue = dt.Rows[0]["KPI_Category"].ToString();
                    if (dt.Rows[0]["Active"].ToString() == "1")
                    {
                        cbActive.Checked = true;
                    }
                    else
                    {
                        cbActive.Checked = false;
                    }
                    lblmessage.Visible = false;
                    btnAddKPI.Text = Resources.TestSiteResources.Update;
                }
                else
                {
                    lblHeading.Text = Resources.TestSiteResources.AddKPI;
                    lblActive.Enabled = false;
                    cbActive.Enabled = false;
                    ddlKPIType.SelectedIndex = 0;
                    ddlCategory.SelectedIndex = 0;

                }
            }
        }

        protected void LoadKPIType()
        {
            DropdownViewBLL dropdown = new DropdownViewBLL();

            Dropdown _dropdown = new Dropdown();
            _dropdown.ReferenceCode = "KPI_TYPE";
            dropdown.Dropdown = _dropdown;
            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlKPIType.DataTextField = "Description";
            ddlKPIType.DataValueField = "ReferenceData_ID";

            ddlKPIType.DataSource = dropdown.ResultSet;
            ddlKPIType.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlKPIType.Items.Insert(0, li);
        }

        protected void LoadCategory()
        {
            DropdownViewBLL dropdown = new DropdownViewBLL();

            Dropdown _dropdown = new Dropdown();
            _dropdown.ReferenceCode = "KPI_CATEGORY";
            dropdown.Dropdown = _dropdown;
            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
            }

            ddlCategory.DataTextField = "Description";
            ddlCategory.DataValueField = "ReferenceData_ID";

            ddlCategory.DataSource = dropdown.ResultSet;
            ddlCategory.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlCategory.Items.Insert(0, li);
        }

        #region add update kpi code
        protected void btnAddKPI_Click(object sender, EventArgs e)
        {
            if (txtKPIName.Text.Equals(""))
            {
               
                return;
            }
            else
            {
                lblmessage.Visible = true;
                KPI kpi = new KPI();
                kpi.KPIName = txtKPIName.Text.Trim();
                kpi.KPIDescription = txtDescp.Text.Trim();
                kpi.KPIMeasure = txtKPIMeasure.Text.Trim();
                kpi.KPIType = ddlKPIType.SelectedValue;
                kpi.KPICategory = ddlCategory.SelectedValue;
            


                if (btnAddKPI.Text == "Update" || btnAddKPI.Text == "mettre à jour" || btnAddKPI.Text == "actualizar")
                {
                    KPIUpdateBLL UpdateKPI = new KPIUpdateBLL();
                    kpi.KPIID = Convert.ToInt32(Request.QueryString["kpiid"]);
                    if (cbActive.Checked)
                    {
                        kpi.Active = 1;
                    }
                    else
                    {
                        kpi.Active = 0;
                    }

                    UpdateKPI.KPI = kpi;
                    try
                    {
                        UpdateKPI.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.KPI + ' ' + Resources.TestSiteResources.UpdateMessage;
                        
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.KPI;
                       
                    }
                }
                else if (btnAddKPI.Text == "Add" || btnAddKPI.Text == "Ajouter" || btnAddKPI.Text == "añadir")
                {
                    
                    lblmessage.Visible = true;
                    KPIInsertBLL insertKPI = new KPIInsertBLL();
                    insertKPI.KPI = kpi;
                    try
                    {
                        insertKPI.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.KPI + ' ' + Resources.TestSiteResources.SavedMessage;
                        
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.KPI + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.KPI;
                        }
                        
                    }
                   
                }

                btnAddKPI.Text = Resources.TestSiteResources.Add;
                txtKPIName.Text = "";
                txtKPIMeasure.Text = "";
                txtDescp.Text = "";
               
                ddlKPIType.SelectedIndex = 0;
                cbActive.Checked = false;
             
                LoadData();
                Response.Redirect("KPIManagement.aspx");
            }
        }
        #endregion
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddKPI.Text = Resources.TestSiteResources.Add;
            txtKPIName.Text = "";
            txtKPIMeasure.Text = "";
            txtDescp.Text = "";
           
            ddlKPIType.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            cbActive.Checked = false;
          
            Response.Redirect("KPIManagement.aspx");
          
            
        }


        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnHyperLink_Click(object sender, EventArgs e)
        {
            mpeTipsTricks.Show();
        }
    }
}