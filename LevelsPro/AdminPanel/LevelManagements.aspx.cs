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
using System.Text;
using LevelsPro.App_Code;
using BusinessLogic.Delete;

namespace LevelsPro.AdminPanel
{
    public partial class LevelManagements : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            if (!(Page.IsPostBack))
            {
               
                LoadRoles();
                lblHeading.Text =Resources.TestSiteResources.ManageLevels;
                pnlMain.Visible = true;
                pnlSort.Visible = false;
            }

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

            ListItem li = new ListItem("--Select Role--", "0");
            ddlRole.Items.Insert(0, li);
        }

       

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
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

            if (level.ResultSet != null && level.ResultSet.Tables.Count > 0 && level.ResultSet.Tables[0] != null && level.ResultSet.Tables[0].Rows.Count > 0)
            {
                dlLevel.DataSource = level.ResultSet;
                dlLevel.DataBind();
            }
            else
            {
               
                dlLevel.DataSource = null;
                dlLevel.DataBind();
            }

        }


        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
               
                ViewState["levelid"] = int.Parse(ddlRole.SelectedValue.ToString());
                pnlPlayergrid.Visible = true;
                LoadLevels(int.Parse(ddlRole.SelectedValue.ToString()));
                
            }
            else
            {
                pnlPlayergrid.Visible = false;
                dlLevel.DataSource = null;
                dlLevel.DataBind();
                
            }
            
        }

        protected void btnNewLevel_Click(object sender, EventArgs e)
        {
            int LevelCount = 0;

            if (ddlRole.SelectedIndex > 0)
            {
                lblmessage.Visible = false;
                LevelCount = dlLevel.Items.Count + count + 1;

                Response.Redirect("LevelEdit.aspx?roleid=" + ddlRole.SelectedValue.ToString() + "&count=" + LevelCount.ToString(), false);
            }
            else
            {
                lblmessage.Visible = true;
                lblmessage.Text = "First Select Role";
            }

        }

        protected void dlLevel_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditLevel")
            {
                if (ddlRole.SelectedIndex > 0)
                {
                    Response.Redirect("LevelEdit.aspx?levelid=" + e.CommandArgument.ToString() + "&roleid=" + ddlRole.SelectedValue.ToString(), false);
                }
            }
            else if (e.CommandName == "DeleteLevel")
            {
                LevelsDeleteBLL leveldelete = new LevelsDeleteBLL();
                Levels _level = new Levels();

                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                Session["LevelID"] = arg[0];
                Session["LevelPosition"] = arg[1];
                string[] arg1 = new string[2];
                arg1 = Session["LevelPosition"].ToString().Split('&');
                Session["LevelPosition"] = arg1[0];
                Session["RoleID"] = arg1[1];

                _level.LevelID = Convert.ToInt32(Session["LevelID"]);
                _level.LevelPosition = Convert.ToInt32(Session["LevelPosition"]);
                _level.RoleID = Convert.ToInt32(Session["RoleID"]); 
                leveldelete.Levels = _level;
                try
                {
                    leveldelete.Invoke();
                }
                catch (Exception ex)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = "You cannot delete because this Level is in use ";
                }

                LoadLevels(Convert.ToInt32(ViewState["levelid"]));
            }
        }

        protected void dlLevel_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblActiveGrid = (Label)e.Item.FindControl("lblActive");

                if (lblActiveGrid.Text.Trim().ToLower() == "false")
                {
                    count = count - 1;
                }
            }
        }
        #region set position of level button
        protected void btnSet_Click(object sender, EventArgs e)
        {
            UpdateLevelPositionBLL levelposition = new UpdateLevelPositionBLL();
            Levels level = new Levels();
            StringBuilder strbXML = new StringBuilder();
           
            string strItems = string.Empty;
            
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
                if (ViewState["RoleID"] != null)
                {
                    ddlRole.SelectedValue = ViewState["RoleID"].ToString();
                    LoadLevels(Convert.ToInt32(ddlRole.SelectedValue));
                    pnlMain.Visible = true;
                    pnlSort.Visible = false;
                }
               
            }
            catch (Exception ex)
            {
                lblmessage.Text = Resources.TestSiteResources.LevelError;
                
            }

        }
        #endregion
        #region re arrange levels
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


        protected void btnCancelPriority_Click(object sender, EventArgs e)
        {
            pnlSort.Visible = false;
            ddlRole.SelectedIndex = 0;
            pnlMain.Visible = true;
           
        }

        protected void btnRearrangeLevels_Click(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                ViewState["RoleID"] = ddlRole.SelectedValue;
                pnlMain.Visible = false;
                pnlSort.Visible = true;
                
                lblInfo.Visible = true;
                lblHeading.Text = "Manage Levels";

               
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

               

                if (dtlist != null && dtlist.Rows.Count > 0)
                {
                    lstSelectedSections.DataSource = dtlist;
                    lstSelectedSections.DataTextField = "Level_Name";
                    lstSelectedSections.DataValueField = "Level_ID";
                    lstSelectedSections.DataBind();
                }
            }
        }
        #endregion

        protected void dlLevel_DeleteCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}