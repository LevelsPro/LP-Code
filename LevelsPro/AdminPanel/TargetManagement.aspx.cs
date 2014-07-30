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

namespace LevelsPro.AdminPanel
{
    public partial class TargetManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            if (!(Page.IsPostBack))
            {
               
                LoadKPI();
                LoadRoles();

                
            }
           

        }
        protected void LoadData(int RoleID, int LevelID)
        {
            TargetViewBLL Target = new TargetViewBLL();
            try
            {
                Target.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = Target.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Role_ID=" + RoleID.ToString() + "AND Level_ID =" + LevelID.ToString();
            

            gvTarget.DataSource = dv.ToTable();
            gvTarget.DataBind();
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
            }

            ddlRole.DataTextField = "Role_Name";
            ddlRole.DataValueField = "Role_ID";

            DataView dv = role.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlRole.DataSource = dv.ToTable();
            ddlRole.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlRole.Items.Insert(0, li);
        }

        protected void LoadLevel(int RoleID)
        {
            LevelsViewBLL level = new LevelsViewBLL();
            Common.Roles role = new Roles();
            role.RoleID = RoleID;
            level.Role = role;
            try
            {
                level.Invoke();
            }
            catch (Exception)
            {
            }

            ddlLevel.DataTextField = "Level_Name";
            ddlLevel.DataValueField = "Level_ID";

            
            ddlLevel.DataSource = level.ResultSet;
            ddlLevel.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlLevel.Items.Insert(0, li);
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


        protected void btnAddTarget_Click(object sender, EventArgs e)
        {
            if (txtTargetValue.Text.Equals(""))
            {
               
                return;
            }
            else
            {

                Target target = new Target();
                target.TargetValue = Convert.ToInt32(txtTargetValue.Text.Trim());
                target.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                target.LevelID = Convert.ToInt32(ddlLevel.SelectedValue);
                target.KPIID = Convert.ToInt32(ddlKPI.SelectedValue);
              
                target.Description = txtDescription.Text.Trim();

                if (btnAddTarget.Text == "Update" || btnAddTarget.Text == "mettre à jour" || btnAddTarget.Text == "actualizar")
                {
                    lblmessage.Visible = true;
                    TargetUpdateBLL UpdateTarget = new TargetUpdateBLL();
                    target.TargetID = int.Parse(gvTarget.SelectedDataKey[0].ToString());
                    if (cbActive.Checked)
                    {
                        target.Active = 1;
                    }
                    else
                    {
                        target.Active = 0;
                    }
                    UpdateTarget.Target = target;
                    try
                    {
                        UpdateTarget.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.TargetValue + ' ' + Resources.TestSiteResources.UpdateMessage;//"Level has been updated successfully";
                       
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.TargetValue;
                       
                    }
                }
                else if (btnAddTarget.Text == "Add" || btnAddTarget.Text == "Ajouter" || btnAddTarget.Text == "añadir")
                {
                    TargetViewBLL targetView = new TargetViewBLL();
                    try
                    {
                        targetView.Invoke();
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    DataView dv = targetView.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "Target_Value='" + txtTargetValue.Text.Trim() + "' AND Role_ID='" + ddlRole.SelectedValue + "' AND KPI_ID='" + ddlKPI.SelectedValue + "' AND Level_ID='" + ddlLevel.SelectedValue + "'";

                    if (dv.ToTable().Rows.Count < 1)
                    {
                        lblmessage.Visible = true;
                        TargetInsertBLL insertTarget = new TargetInsertBLL();
                        insertTarget.Target = target;
                        try
                        {
                            insertTarget.Invoke();
                            //show success lable
                            lblmessage.Text = Resources.TestSiteResources.TargetValue + ' ' + Resources.TestSiteResources.SavedMessage;//"Level has been saved successfully";
                           
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("Duplicate"))
                            {
                                lblmessage.Text = Resources.TestSiteResources.TargetValue + ' ' + Resources.TestSiteResources.Already;
                            }
                            else
                            {
                                //show unsuceess
                                lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.TargetValue;
                            }
                            
                        }
                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = Resources.TestSiteResources.TargetValue + ' ' + Resources.TestSiteResources.Already;
                    }
                }

                btnAddTarget.Text = Resources.TestSiteResources.Add;
                txtTargetValue.Text = "";
               
                ddlKPI.SelectedIndex = 0;
                cbActive.Checked = false;
                trActive.Visible = false;
                txtDescription.Text = "";
                LoadData(Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlLevel.SelectedValue));
            }
        }

        protected void btnCancelTarget_Click(object sender, EventArgs e)
        {
            btnAddTarget.Text = Resources.TestSiteResources.Add;
            txtTargetValue.Text = "";
            
            cbActive.Checked = false;
            trActive.Visible = false;
            gvTarget.SelectedIndex = -1;
            txtDescription.Text = "";
            ddlKPI.SelectedIndex = 0;
            ddlLevel_SelectedIndexChanged(null,null);
           
        }

        protected void gvTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvTarget.SelectedIndex != -1)
            {
                lblmessage.Visible = false;
               
                Label lblActive = (Label)gvTarget.SelectedRow.FindControl("lblActive");
                Label lblKPIID = (Label)gvTarget.SelectedRow.FindControl("lblKPIID");
               
                txtTargetValue.Text = "";
                txtTargetValue.Text = gvTarget.SelectedRow.Cells[6].Text.Trim();
                Label lblTargetDescription = (Label)gvTarget.SelectedRow.FindControl("lblTarget_Desc");
                txtDescription.Text = lblTargetDescription.Text.Trim();
               
                 ddlKPI.SelectedValue = lblKPIID.Text.Trim();
                if (lblActive.Text.Trim().ToLower() == "true")
                {
                    cbActive.Checked = true;
                }
                else
                {
                    cbActive.Checked = false;
                }
                trActive.Visible = true;
                btnAddTarget.Text = Resources.TestSiteResources.Update;
            }

        }

        protected void gvTarget_RowDataBound(object sender, GridViewRowEventArgs e)
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
                   
                }
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                LoadLevel(Convert.ToInt32(ddlRole.SelectedValue));
            }

        }


        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLevel.SelectedIndex > 0)
            {
                LoadData(Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlLevel.SelectedValue));
            }
            else
            {
                gvTarget.DataSource = null;
                gvTarget.DataBind();
            }
        }        

    }
}