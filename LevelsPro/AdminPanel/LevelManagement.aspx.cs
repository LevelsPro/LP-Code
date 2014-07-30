using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using BusinessLogic.Select;
using System.Data;
using System.Drawing;
using System.Text;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class LevelManagement : AuthorizedPage
    {
        int count = 0;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            //#region pageLoad
            if (!(Page.IsPostBack))
            {
                //    #region Authentication Code
                //    try
                //    {
                //        usr = (string)Session["username"];
                //        pwd = (string)Session["password"];
                //        loc = (string)Session["location"];
                //        if ((usr == null) || (pwd == null))
                //        {
                //            Response.Redirect("~/Login.aspx");
                //        }
                //        else
                //        {
                //            AccountRoles ar = new AccountRoles();
                //            if (!(ar.Authorization(Roles(usr, pwd, loc), usr, pwd, loc)))
                //            {
                //                ClientScript.RegisterStartupScript(typeof(Page), "warning", "<script>alert('Invalid UserName/Password')</script>");
                //            }
                //            else
                //            {
                //                string str = (string)Session["role"];
                //                if (!(str.Equals("sadmin")))
                //                {
                //                    Response.Redirect("~/Login.aspx");
                //                }
                //                else
                //                {
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                //    }
                //    #endregion
                LoadRoles();
                pnlSort.Visible = false;
                pnlPlayergrid.Visible = false;

                //    done.Value = "1";
            }
            //else
            //{
            //    try
            //    {
            //        if ((Session["role"].ToString() == null))
            //        {
            //            Response.Redirect("~/Login.aspx");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        Response.Redirect("~/Login.aspx");
            //    }
            //}
            //# endregion

        }

        protected void LoadLevels(int RoleID)
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

            //DataView dv = level.ResultSet.Tables[0].DefaultView;
            //dv.RowFilter = "Role_ID=" + RoleID.ToString();
            //gvLevel.DataSource = dv.ToTable();

            gvLevel.DataSource = level.ResultSet;
            gvLevel.DataBind();



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

        protected void gvLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvLevel.SelectedIndex != -1)
            {
                lblmessage.Visible = false;
                //ImageButton gvLevelRow = (ImageButton)sender;
                //GridViewRow row = (GridViewRow)gvLevelRow.NamingContainer;
                //Label lblRoleID = (Label)gvLevel.SelectedRow.FindControl("lblRoleID");
                Label lblActive = (Label)gvLevel.SelectedRow.FindControl("lblActive");

                txtLevelName.Text = gvLevel.SelectedRow.Cells[4].Text.Trim();
                txtPosition.Text = gvLevel.SelectedRow.Cells[3].Text.Trim();
                txtBaseHours.Text = gvLevel.SelectedRow.Cells[5].Text.Trim();
                //txtDimension_top.Text = gvLevel.SelectedRow.Cells[6].Text.Trim();
                //txtDimension_left.Text = gvLevel.SelectedRow.Cells[7].Text.Trim();
                ////ddlRole.SelectedValue = lblRoleID.Text.Trim();
                if (lblActive.Text.Trim().ToLower() == "true")
                {
                    cbActive.Checked = true;
                    hdnCheckStatus.Value = "True";
                }
                else
                {
                    cbActive.Checked = false;
                    hdnCheckStatus.Value = "False";
                }
                trActive.Visible = true;
                btnAddLevel.Text = Resources.TestSiteResources.Update;
            }

        }

        protected void btnAddLevels_Click(object sender, EventArgs e)
        {
            if (txtLevelName.Text.Equals(""))
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Provide country to add')</script>", false);
                return;
            }
            else
            {
                Levels level = new Levels();
                level.LevelName = txtLevelName.Text.Trim();
                level.RoleID = Convert.ToInt32(ddlRole.SelectedValue);

                //level.LevelPosition = Convert.ToInt32(txtPosition.Text.Trim());
                string levelposition = txtPosition.Text.Substring(6);
                level.LevelPosition = Convert.ToInt32(levelposition.Trim());


                level.BaseHours = Convert.ToInt32(txtBaseHours.Text.Trim());
               // level.SiteID = Convert.ToInt32(Session["siteid"]);


                if (levelposition == "1")
                {
                    level.Dimension_top = 30;//Convert.ToInt32(txtDimension_top.Text.Trim());
                    level.Dimension_left = 13;//Convert.ToInt32(txtDimension_left.Text.Trim());
                }
                else if (levelposition == "2")
                {
                    level.Dimension_top = 20;
                    level.Dimension_left = 20;
                }
                else if (levelposition == "3")
                {
                    level.Dimension_top = 30;
                    level.Dimension_left = 30;
                }
                else if (levelposition == "4")
                {
                    level.Dimension_top = 23;
                    level.Dimension_left = 43;
                }
                else if (levelposition == "5")
                {
                    level.Dimension_top = 18;
                    level.Dimension_left = 53;
                }
                else if (levelposition == "6")
                {
                    level.Dimension_top = 30;
                    level.Dimension_left = 63;
                }
                else if (levelposition == "7")
                {
                    level.Dimension_top = 45;
                    level.Dimension_left = 70;
                }
                else if (levelposition == "8")
                {
                    level.Dimension_top = 50;
                    level.Dimension_left = 80;
                }
                else if (levelposition == "9")
                {
                    level.Dimension_top = 55;
                    level.Dimension_left = 85;
                }
                else if (levelposition == "10")
                {
                    level.Dimension_top = 60;
                    level.Dimension_left = 90;
                }

                else
                {
                    level.Dimension_top = 40;
                    level.Dimension_left = 13;
                }




                if (btnAddLevel.Text == "Update" || btnAddLevel.Text == "mettre à jour" || btnAddLevel.Text == "actualizar")
                {
                    lblmessage.Visible = true;
                    LevelsUpdateBLL UpdateLevel = new LevelsUpdateBLL();
                    level.LevelID = int.Parse(gvLevel.SelectedDataKey[0].ToString());
                    if (cbActive.Checked)
                    {
                        level.Active = 1;
                    }
                    else
                    {
                        level.Active = 0;
                    }

                    UpdateLevel.Levels = level;
                    try
                    {
                        UpdateLevel.Invoke();

                        if (hdnCheckStatus.Value != cbActive.Checked.ToString())
                        {
                            btnSort_Click(null, null);
                            btnSet_Click(null, null);
                        }

                        lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.UpdateMessage;
                        pnlPlayergrid.Visible = true;
                        pnlSort.Visible = false;
                        //r.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Updation successfully performed')</script>", false);
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Level;
                        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
                    }
                }
                else if (btnAddLevel.Text == "Add" || btnAddLevel.Text == "Ajouter" || btnAddLevel.Text == "añadir")
                {
                    LevelsViewBLL levelView = new LevelsViewBLL();
                    Common.Roles role = new Roles();
                    role.RoleID = int.Parse(ddlRole.SelectedValue);
                    levelView.Role = role;
                    try
                    {
                        levelView.Invoke();
                    }
                    catch (Exception ex)
                    {
                        //ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                    }

                    DataView dv = levelView.ResultSet.Tables[0].DefaultView;

                    //dv.RowFilter = "Level_Name='" + txtLevelName.Text.Trim() + "' AND Role_ID='" + ddlRole.SelectedValue + "'";
                    dv.RowFilter = "Level_Name='" + txtLevelName.Text.Trim() + "'";

                    if (dv.ToTable().Rows.Count < 1)
                    {
                        lblmessage.Visible = true;
                        LevelsInsertBLL insertLevel = new LevelsInsertBLL();
                        insertLevel.Levels = level;
                        try
                        {
                            insertLevel.Invoke();
                            //show success lable
                            lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.SavedMessage;//"Level has been saved successfully";
                            // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Insertion successfully performed..')</script>", false);
                        }
                        catch (Exception ex)
                        {
                            //show unsuceess
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.Level;
                            // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
                        }
                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = Resources.TestSiteResources.Level + ' ' + Resources.TestSiteResources.Already;
                    }
                }

                //btnAddLevel.Text = Resources.TestSiteResources.Add;
                //txtLevelName.Text = "";
                //txtPosition.Text = "";
                ////ddlRole.SelectedIndex = 0;
                //cbActive.Checked = false;
                //trActive.Visible = false;
                ////txtDimension_top.Text = "";
                ////txtDimension_left.Text = "";
                //txtBaseHours.Text = "";
                //LoadData(Convert.ToInt32(ddlRole.SelectedValue));
                btnCancel_Click(null, null);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddLevel.Text = Resources.TestSiteResources.Add;
            txtLevelName.Text = "";
            //txtPosition.Text = "";
            ////ddlRole.SelectedIndex = 0;
            cbActive.Checked = false;
            trActive.Visible = false;
            txtBaseHours.Text = "";
            gvLevel.SelectedIndex = -1;
            lstSelectedSections.Items.Clear();
            LoadLevels(Convert.ToInt32(ddlRole.SelectedValue));
            if (ddlRole.SelectedIndex > 0)
            {
               // txtPosition.Text = "Level " + (gvLevel.Rows.Count + 1).ToString();
                txtPosition.Text = "Level " + (gvLevel.Rows.Count + count + 1).ToString();
            }
            else
            {
                txtPosition.Text = "";
            }
        }

        protected void gvLevel_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            
            //foreach (TableCell tc in e.Row.Cells)
            //{
            //    tc.Attributes["style"] = "border-color: #ebeef1";
            //}

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //foreach (TableCell tc in e.Row.Cells)
                //{
                //    tc.Attributes["style"] = "border-color: #ebeef1";
                //}

                Label lblActiveGrid = (Label)e.Row.FindControl("lblActive");

                if (lblActiveGrid.Text.Trim().ToLower() == "false")
                {
                    e.Row.BackColor = Color.LightGray;
                    //e.Row.ForeColor = Color.White;
                    count = count - 1;
                   
                }
            }
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
               // LoadLevels(Convert.ToInt32(ddlRole.SelectedValue));
                pnlSort.Visible = false;
                pnlPlayergrid.Visible = true;
            }
            else
            {
                gvLevel.DataSource = null;
                gvLevel.DataBind();
            }
            btnCancel_Click(null, null);
            if (ddlRole.SelectedIndex > 0)
            {
                //txtPosition.Text = "Level " + (gvLevel.Rows.Count + 1).ToString();
                txtPosition.Text = "Level " + (gvLevel.Rows.Count + count + 1).ToString();
            }
            else
            {
                txtPosition.Text = "";
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            UpdateLevelPositionBLL levelposition = new UpdateLevelPositionBLL();
            Levels level = new Levels();
            StringBuilder strbXML = new StringBuilder();
            //int RetValue = 0;
            string strItems = string.Empty;
            // int WorkFlowID = Convert.ToInt32(ddlWorkFlowNames.SelectedValue);
            strbXML.Append("<ROOT>");
            string strXML = strbXML.ToString();

            for (int i = 0; i < lstSelectedSections.Items.Count; i++)
            {
                strbXML.Append("<levelid>" + lstSelectedSections.Items[i].Value + "</levelid><levelposition>" + (i + 1) + "</levelposition>");
            }
            strbXML.Append("</ROOT>");
            strItems = strbXML.ToString();

            level.XML = strItems;
            levelposition.Levels = level;
            lblmessage.Visible = true;
            try
            {
                levelposition.Invoke();
                lblmessage.Text = Resources.TestSiteResources.LevelChange;//"Level has been updated successfully";
                //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Updation successfully performed')</script>", false);
            }
            catch (Exception ex)
            {
                lblmessage.Text = Resources.TestSiteResources.LevelError;
                //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
            }

        }

        protected void btnUp_Click(object sender, ImageClickEventArgs e)
        {
            int SelectedIndex = lstSelectedSections.SelectedIndex;


            if (SelectedIndex == -1) // nothing selected
                return;
            if (SelectedIndex == 0) // already at top of list  
                return;


            ListItem Temp;
            Temp = lstSelectedSections.SelectedItem;


            lstSelectedSections.Items.Remove(lstSelectedSections.SelectedItem);
            lstSelectedSections.Items.Insert(SelectedIndex - 1, Temp);

        }

        protected void btnDown_Click(object sender, ImageClickEventArgs e)
        {
            int SelectedIndex = lstSelectedSections.SelectedIndex;


            if (SelectedIndex == -1)  // nothing selected
                return;
            if (SelectedIndex == lstSelectedSections.Items.Count - 1)  // already at top of list            
                return;


            ListItem Temp;
            Temp = lstSelectedSections.SelectedItem;


            lstSelectedSections.Items.Remove(lstSelectedSections.SelectedItem);
            lstSelectedSections.Items.Insert(SelectedIndex + 1, Temp);

        }

        protected void btnSort_Click(object sender, EventArgs e)
        {

            pnlSort.Visible = true;
            pnlPlayergrid.Visible = false;
            lblInfo.Visible = true;

            //DataTable dt = new DataTable();

            LevelsViewBLL level = new LevelsViewBLL();
            Common.Roles role = new Roles();
            role.RoleID = int.Parse(ddlRole.SelectedValue);
            level.Role = role;

            try
            {
                level.Invoke();
            }
            catch (Exception ex)
            {
            }

            DataView dv = level.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active = 1";
            DataTable dtlist = new DataTable();
            dtlist = dv.ToTable();

            // if (level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)

            if (dtlist != null && dtlist.Rows.Count > 0)
            {
                lstSelectedSections.DataSource = dtlist;//level.ResultSet.Tables[0];
                lstSelectedSections.DataTextField = "Level_Name";
                lstSelectedSections.DataValueField = "Level_ID";
                lstSelectedSections.DataBind();
            }
        }

        protected void btnCancelPriority_Click(object sender, EventArgs e)
        {
            pnlSort.Visible = false;
            ddlRole.SelectedIndex = 0;
            if (ddlRole.SelectedIndex > 0)
            {
                //txtPosition.Text = "Level " + (gvLevel.Rows.Count + 1).ToString();
                txtPosition.Text = "Level " + (gvLevel.Rows.Count + count + 1).ToString();
            }
            else
            {
                txtPosition.Text = "";
            }
            btnCancel_Click(null, null);
        }
    }
}