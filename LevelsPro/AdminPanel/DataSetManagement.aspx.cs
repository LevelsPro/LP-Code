using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Select;
using BusinessLogic.Insert;
using Common;
using BusinessLogic.Delete;
using System.Data;
using LevelsPro.App_Code;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using Common.Utils;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class DataSetManagement : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                if (Request.QueryString["matchid"] != null && Request.QueryString["matchid"].ToString() != "")
                {
                    ViewState["matchid"] = Request.QueryString["matchid"];
                    LoadDataSets(Convert.ToInt32(ViewState["matchid"]));
                    //LoadRoles();
                }
            }
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
            }

            ddlRole.DataTextField = "site_name";
            ddlRole.DataValueField = "site_id";

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlRole.DataSource = dv.ToTable();
            ddlRole.DataBind();

            ListItem liFilter = new ListItem("Select All Location", "0");
            ddlRole.Items.Insert(0, liFilter);

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

            ddlLevel.DataTextField = "Level_Name";
            ddlLevel.DataValueField = "Level_ID";

            ddlLevel.DataSource = level.ResultSet;
            ddlLevel.DataBind();

            ListItem liFilter = new ListItem("Select Level", "0");
            ddlLevel.Items.Insert(0, liFilter);

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

            ListItem liFilter = new ListItem("Select Role", "0");
            ddlRole.Items.Insert(0, liFilter);
        }
        #region show all datasets
        protected void LoadDataSets(int MatchID)
        {
            DataSetViewBLL datasetview = new DataSetViewBLL();
            Match _match = new Match();


            if (ViewState["roleid"] != null && ViewState["roleid"].ToString() != "")
            {
                _match.Status = 1;
                _match.Where = " WHERE MatchID=" + MatchID.ToString() + " AND tblmatchdatasetlevels.RoleID=" + Convert.ToInt32(ViewState["roleid"]) + " AND LevelID=" + Convert.ToInt32(ViewState["levelid"]);
            }
            else if (ViewState["siteid"] != null && ViewState["siteid"].ToString() != "")
            {
                _match.Status = 0;
                _match.Where = " WHERE MatchID= " + MatchID.ToString() + " AND SiteID=" + Convert.ToInt32(ViewState["siteid"]);

            }
            else
            {
                _match.Status = 0;
                _match.Where = " WHERE MatchID= " + MatchID.ToString();
            }

            datasetview.Match = _match;
            try
            {
                datasetview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (datasetview.ResultSet != null && datasetview.ResultSet.Tables[0] != null && datasetview.ResultSet.Tables[0].Rows.Count > 0)
            {
                dlDataSets.DataSource = datasetview.ResultSet.Tables[0];
                dlDataSets.DataBind();
            }
            else
            {
                dlDataSets.DataSource = null;
                dlDataSets.DataBind();
            }

        }

        #endregion
        protected void dlDataSets_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EditDataSet")
            {
                if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
                {
                    Response.Redirect("DataSetEdit.aspx?datasetid=" + e.CommandArgument.ToString() + "&matchid=" + ViewState["matchid"].ToString(), false);
                }
            }
            else if (e.CommandName == "DeleteDataSet")
            {
                DataSetDeleteBLL datasetdelete = new DataSetDeleteBLL();
                Match _match = new Match();
                _match.DataSetID = Convert.ToInt32(e.CommandArgument);
                datasetdelete.Match = _match;
                try
                {
                    datasetdelete.Invoke();
                }
                catch (Exception ex)
                {
                }

                LoadDataSets(Convert.ToInt32(ViewState["matchid"]));
            }
        }

        protected void btnAddDataSet_Click(object sender, EventArgs e)
        {
            if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
            {
                Response.Redirect("DataSetEdit.aspx?matchid=" + ViewState["matchid"].ToString(), false);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                if (Convert.ToInt32(ViewState["roleid"]) == 1)
                {
                    ViewState["siteid"] = null;
                    ViewState["roleid"] = ddlRole.SelectedValue;
                    LoadLevels(Convert.ToInt32(ViewState["roleid"]));
                    // LoadDataSets(Convert.ToInt32(ViewState["matchid"]));
                }
                else if (Convert.ToInt32(ViewState["siteid"]) == 1 || Convert.ToInt32(ViewState["check"]) == 1)
                {
                    ViewState["roleid"] = null;
                    ViewState["siteid"] = ddlRole.SelectedValue;
                    LoadDataSets(Convert.ToInt32(ViewState["matchid"]));
                }
            }
            else if (ddlRole.SelectedIndex == 0 && Convert.ToInt32(ViewState["check"]) == 1)
            {
                ViewState["roleid"] = null;
                ViewState["siteid"] = ddlRole.SelectedValue;
                LoadDataSets(Convert.ToInt32(ViewState["matchid"]));

            }
        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".xls", ".xlsx" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void btnBulkInsert_Click(object sender, EventArgs e)
        {
            string FilePath = "";
            if (fpBulk.HasFile)
            {
                string s = fpBulk.FileName;
                s = Convert.ToString(System.DateTime.Now.Ticks) + "." + s;
                FilePath = Server.MapPath(@"~\APIExcelSheet");
                FileResources resource = FileResources.Instance;
                resource.preparePath(FilePath);
                FileInfo fleInfo = new FileInfo(s);
                if (AllowedFile(fleInfo.Extension))
                {
                    string GuidOne = Guid.NewGuid().ToString();
                    string FileExtension = Path.GetExtension(fpBulk.FileName).ToLower();
                    fpBulk.SaveAs(FilePath + s);

                }

                DataSet dsBulk = new DataSet();
                string filePath = FilePath + s;
                DataTable dtBulk = SpreadsheetReader.loadDataTable(filePath);
                dsBulk.Tables.Add(dtBulk);

                BulkInsertMatchDataSetsBLL BulkInsert = new BulkInsertMatchDataSetsBLL();
                BulkInsert.Invoke(dsBulk, FilePath);

                if (BulkInsert.BulkResult.Equals("Successfull"))
                {
                    //success
                }
                else
                {
                    //not successFilePath + s
                }
            }
        }

        protected void ddlFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFilterBy.SelectedIndex > 0)
            {
                if (ddlFilterBy.SelectedValue == "1")
                {
                    ViewState["check"] = null;
                    ViewState["siteid"] = null;
                    ViewState["roleid"] = 1;
                    LoadRoles();
                }
                else if (ddlFilterBy.SelectedValue == "2")
                {
                    ddlLevel.Items.Clear();

                    ViewState["roleid"] = null;
                    ViewState["siteid"] = 1;
                    ViewState["check"] = 1;
                    LoadSites();
                    ddlRole_SelectedIndexChanged(null, null);
                }

            }
            else if (ddlFilterBy.SelectedIndex == 0)
            {
                ddlRole.Items.Clear();
                ddlLevel.Items.Clear();

                ViewState["roleid"] = null;
                ViewState["siteid"] = null;
                ViewState["check"] = null;
                LoadDataSets(Convert.ToInt32(ViewState["matchid"]));

            }
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                ViewState["levelid"] = ddlLevel.SelectedValue;
                LoadDataSets(Convert.ToInt32(ViewState["matchid"]));

            }
        }
    }
}