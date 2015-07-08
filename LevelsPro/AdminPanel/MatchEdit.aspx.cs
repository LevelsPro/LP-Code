using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Common;
using System.IO;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using BusinessLogic.Update;
using BusinessLogic.Delete;
using LevelsPro.App_Code;
using log4net;
using LevelsPro.Util;
using MySql.Data.MySqlClient;
using System.Collections;
using Common.Utils;

namespace LevelsPro.AdminPanel
{
    public partial class MatchEdit : AuthorizedPage
    {
        private static string pageURL;
        protected static Hashtable fileMetadata;
        static DataSet dss;
        private ILog log;

        static MatchEdit()
        {
            fileMetadata = new Hashtable();
            fileMetadata.Add("folderPath", "MatchPath");
            fileMetadata.Add("thumbnailPath", "MatchThumbPath");

            string[] metadataKeys = { "folderPath", "thumbnailPath" };
            foreach (string key in metadataKeys)
            {
                string appKey = (string)fileMetadata[key];
                string settingValue = ConfigurationManager.AppSettings[appKey].ToString();
                fileMetadata[key] = HttpContext.Current.Server.MapPath(settingValue);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();

                try
                {
                    LoadKPI();

                    if (Request.QueryString["matchid"] != null && Request.QueryString["matchid"].ToString() != "")
                    {
                        ViewState["matchid"] = Request.QueryString["matchid"];

                        LoadData(Convert.ToInt32(ViewState["matchid"]));
                    }
                    else
                    {
                        this.Title = Resources.TestSiteResources.AddMatch;
                        lblHeading.Text = Resources.TestSiteResources.AddMatch;
                        btnNewDataElement.Enabled = false;
                        btnAddRound.Enabled = false;
                    }
                    loadDataList();
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        #region show match for edit
        private void LoadData(int MatchID)
        {
            string path = ConfigurationManager.AppSettings["MatchPath"].ToString();
            MatchViewBLL matchview = new MatchViewBLL();

            Match _match = new Match();
            _match.Where = " WHERE MatchID = " + MatchID.ToString();
            matchview.Match = _match;
            try
            {
                matchview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (matchview.ResultSet != null && matchview.ResultSet.Tables.Count > 0 && matchview.ResultSet.Tables[0] != null && matchview.ResultSet.Tables[0].Rows.Count > 0)
            {
                txtMatchName.Text = matchview.ResultSet.Tables[0].Rows[0]["MatchName"].ToString();
                txtPointsForCompletation.Text = matchview.ResultSet.Tables[0].Rows[0]["PointsForCompletation"].ToString();
                txtMaxPlaysPerDay.Text = matchview.ResultSet.Tables[0].Rows[0]["MaxPlaysPerDay"].ToString();
                switch (matchview.ResultSet.Tables[0].Rows[0]["NoOfDataSet"].ToString())
                {
                    case "2":
                        ddlNoOfDataSet.SelectedIndex = 0;
                        break;
                    case "3":
                        ddlNoOfDataSet.SelectedIndex = 1;
                        break;
                    case "4":
                        ddlNoOfDataSet.SelectedIndex = 2;
                        break;
                }
                txtNoOfRounds.Text = matchview.ResultSet.Tables[0].Rows[0]["NoOfRounds"].ToString();
                ddlKPI_ID.SelectedValue = matchview.ResultSet.Tables[0].Rows[0]["KPI_ID"].ToString();
                hdImage.Value = path + matchview.ResultSet.Tables[0].Rows[0]["MatchImage"].ToString();

                ViewState["MatchImage"] = matchview.ResultSet.Tables[0].Rows[0]["MatchImage"].ToString();
                ViewState["MatchImageThumbnail"] = matchview.ResultSet.Tables[0].Rows[0]["MatchImageThumbnail"].ToString();

                LoadDataElements(Convert.ToInt32(ViewState["matchid"]));
                LoadRounds(Convert.ToInt32(ViewState["matchid"]));
                //LoadDS(Convert.ToInt32(ViewState["matchid"]));

                btnAddMatch.Text = Resources.TestSiteResources.Update;
            }
        }
        #endregion

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

            ddlKPI_ID.DataTextField = "KPI_name";
            ddlKPI_ID.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1";

            ddlKPI_ID.DataSource = dv.ToTable();
            ddlKPI_ID.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlKPI_ID.Items.Insert(0, li);
        }

        protected void LoadDataElements(int MatchID)
        {
            DataElementViewBLL dataelement = new DataElementViewBLL();
            Match _match = new Match();
            _match.Where = " WHERE MatchID = " + MatchID.ToString();
            dataelement.Match = _match;
            try
            {
                dataelement.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = dataelement.ResultSet.Tables[0].DefaultView;
            if (dv.Count > 0)
            {
                grdDataElements.DataSource = dv.ToTable();
                grdDataElements.DataBind();
                if (dv.Count == Convert.ToInt32(ddlNoOfDataSet.SelectedValue))
                {
                    btnNewDataElement.Enabled = false;
                }
            }
            else
            {
                dv.AddNew();
                grdDataElements.DataSource = dv.ToTable();
                grdDataElements.DataBind();
                int TotalColumns = grdDataElements.Rows[0].Cells.Count;
                grdDataElements.Rows[0].Cells.Clear();
                grdDataElements.Rows[0].Cells.Add(new TableCell());
                grdDataElements.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                grdDataElements.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                grdDataElements.Rows[0].Cells[0].Text = "No Record Found";
            }
        }

        protected void LoadRounds(int MatchID)
        {
            RoundViewBLL rounds = new RoundViewBLL();
            Match _match = new Match();
            _match.Where = " WHERE MatchID = " + MatchID.ToString();
            rounds.Match = _match;
            try
            {
                rounds.Invoke();
            }
            catch (Exception ex)
            {
            }
            DataView dv = rounds.ResultSet.Tables[0].DefaultView;
            if (dv.Count > 0)
            {
                grdRounds.DataSource = dv.ToTable();
                grdRounds.DataBind();
                if (dv.Count >= Convert.ToInt32(txtNoOfRounds.Text))
                {
                    btnAddRound.Enabled = false;
                }
            }
            else
            {
                dv.AddNew();
                grdRounds.DataSource = dv.ToTable();
                grdRounds.DataBind();
                int TotalColumns = grdRounds.Rows[0].Cells.Count;
                grdRounds.Rows[0].Cells.Clear();
                grdRounds.Rows[0].Cells.Add(new TableCell());
                grdRounds.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                grdRounds.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                grdRounds.Rows[0].Cells[0].Text = "No Record Found";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        #region add and update match
        protected void btnAddMatch_Click(object sender, EventArgs e)
        {
            if (txtMatchName.Text.Equals(""))
            {
                return;
            }
            else
            {
                Match match = new Match();
                match.MatchName = txtMatchName.Text.Trim();
                if (txtPointsForCompletation.Text.Trim() != "")
                {
                    match.PointsForCompletation = Convert.ToInt32(txtPointsForCompletation.Text.Trim());
                }

                if (txtMaxPlaysPerDay.Text.Trim() != "")
                {
                    match.MaxPlaysPerDay = Convert.ToInt32(txtMaxPlaysPerDay.Text.Trim());
                }

                match.NoOfDataSet = Convert.ToInt32(ddlNoOfDataSet.SelectedValue);

                if (txtNoOfRounds.Text.Trim() != "")
                {
                    match.NoOfRounds = Convert.ToInt32(txtNoOfRounds.Text.Trim());
                }

                if (ddlKPI_ID.SelectedIndex > 0)
                {
                    match.KPIID = Convert.ToInt32(ddlKPI_ID.SelectedValue);
                }
                FileResources resource = FileResources.Instance;
                string imageId = resource.save(fuMatchImage, fileMetadata);
                if (!string.IsNullOrEmpty(imageId))
                {
                    match.MatchImage = imageId;
                    match.MatchImageThumbnail = imageId;
                }
                else
                {
                    if (ViewState["MatchImage"] != null && ViewState["MatchImage"].ToString() != "")
                    {
                        match.MatchImage = ViewState["MatchImage"].ToString();
                    }
                    if (ViewState["MatchImageThumbnail"] != null && ViewState["MatchImageThumbnail"].ToString() != "")
                    {
                        match.MatchImageThumbnail = ViewState["MatchImageThumbnail"].ToString();
                    }
                }

                MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                scon.Open();
                MySqlTransaction sqlTrans = scon.BeginTransaction();
                match.sqlTransaction = sqlTrans;

                try
                {
                    if (btnAddMatch.Text == "Update" || btnAddMatch.Text == "mettre à jour" || btnAddMatch.Text == "actualizar")
                    {
                        if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
                        {
                            match.MatchID = Convert.ToInt32(ViewState["matchid"]);
                            lblmessage.Visible = true;

                            MatchUpdateBLL updategame = new MatchUpdateBLL();
                            updategame.Match = match;
                            lblmessage.Visible = true;
                            try
                            {
                                updategame.Invoke();
                                lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.UpdateMessage;
                                LoadData(Convert.ToInt32(ViewState["matchid"]));

                            }
                            catch (Exception ex)
                            {
                                ExceptionUtility.ExceptionLogString(ex, Session);
                                Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                                log.Debug(Session["ExpLogString"]);
                                lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.GameName;
                            }
                        }
                    }
                    else
                    {

                        lblmessage.Visible = true;
                        MatchInsertBLL insertmatch = new MatchInsertBLL();
                        insertmatch.Match = match;
                        try
                        {
                            insertmatch.Invoke();
                            //LoadData(Convert.ToInt32(ViewState["matchid"]));
                            //Response.Redirect("MatchManagement.aspx",false);
                        }
                        catch (Exception ex)
                        {
                            ExceptionUtility.ExceptionLogString(ex, Session);
                            Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                            log.Debug(Session["ExpLogString"]);
                            if (ex.Message.Contains("Duplicate"))
                            {
                                lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.Already;
                            }
                            else
                            {
                                //show unsuceess
                                lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.GameName;
                            }
                        }
                    }

                    MatchLevelsDeleteBLL del = new MatchLevelsDeleteBLL();
                    MatchLevelsInsertBLL mLevels = new MatchLevelsInsertBLL();

                    del.Match = match;
                    del.Invoke();

                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        if (dss.Tables[0].Rows[i]["Allow"].ToString() == "yes")
                        {
                            match.RoleID = Convert.ToInt32(dss.Tables[0].Rows[i]["Role_ID"].ToString());
                            match.LevelID = Convert.ToInt32(dss.Tables[0].Rows[i]["Level_ID"].ToString());
                            mLevels.Match = match;
                            mLevels.Invoke();
                        }

                    }
                    sqlTrans.Commit();

                    if (btnAddMatch.Text == "Update" || btnAddMatch.Text == "mettre à jour" || btnAddMatch.Text == "actualizar")
                    {
                        LoadData(int.Parse(match.MatchID.ToString()));
                        lblmessage.Visible = true;
                        lblmessage.Text = "Match info " + Resources.TestSiteResources.UpdateMessage;
                        Response.Redirect("MatchEdit.aspx?mess=1" + "&matchid=" + ViewState["matchid"].ToString(), false);

                    }
                    else
                    {
                        Response.Redirect("MatchEdit.aspx?matchid=" + match.MatchID.ToString(), true);
                    }

                }
                catch (Exception ex)
                {
                    ExceptionUtility.ExceptionLogString(ex, Session);
                    Session["ExpLogString"] += " Aditional Info : Transaction Rolledback";
                    log.Debug(Session["ExpLogString"]);
                    //sqlTrans.Rollback();
                }
                finally
                {
                    sqlTrans.Dispose();
                    scon.Close();
                }
            }
        }
        #endregion

        #region add dataelement
        protected void btnNewMatchElement_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataElementEdit.aspx?matchid=" + ViewState["matchid"].ToString());
        }
        #endregion

        #region add round
        protected void btnNewMatchRound_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoundEdit.aspx?matchid=" + ViewState["matchid"].ToString());
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MatchManagement.aspx");
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {

        }

        protected void dlRoles_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataList dlLevels = e.Item.FindControl("dlLevels") as DataList;
                Literal ltRoleID = e.Item.FindControl("ltRoleID") as Literal;

                DataView dv = dss.Tables[0].DefaultView;
                dv.RowFilter = "Role_ID=" + Convert.ToInt32(ltRoleID.Text.Trim());
                dlLevels.DataSource = dv.ToTable();
                dlLevels.DataBind();


                foreach (DataListItem item in dlLevels.Items)
                {
                    Button btnLevel = item.FindControl("btnLevels") as Button;

                    if (dv.ToTable().Rows[item.ItemIndex]["Allow"].ToString().Trim() == "yes")
                    {
                        btnLevel.CssClass = "lvl-green";
                    }
                    else
                    {
                        btnLevel.CssClass = "lvl-white";

                    }

                }

            }
        }

        protected void dlLevels_ItemCommand(object source, DataListCommandEventArgs e)
        {
            DataList dlLevels = source as DataList;
            Button btnLevel = dlLevels.Items[e.Item.ItemIndex].FindControl("btnLevels") as Button;

            for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
            {

                if (dss.Tables[0].Rows[i]["Level_ID"].ToString() == e.CommandArgument.ToString().Trim())
                {
                    if (btnLevel.CssClass == "lvl-green")
                    {
                        dss.Tables[0].Rows[i]["Allow"] = null;
                        btnLevel.CssClass = "lvl-white";
                    }
                    else
                    {
                        dss.Tables[0].Rows[i]["Allow"] = "yes";
                        btnLevel.CssClass = "lvl-green";
                    }
                    break;
                }

            }
        }

        private void loadDataList()
        {
            try
            {
                MatchLevelsBLL Rolelevel = new MatchLevelsBLL();
                Match match = new Match();

                if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
                {
                    match.MatchID = Convert.ToInt32(ViewState["matchid"]);

                }
                else
                {
                    match.MatchID = -1;
                }
                Rolelevel.Match = match;
                Rolelevel.Invoke();
                dss = new DataSet();
                dss = Rolelevel.ResultSet;
                dlRoles.DataSource = Rolelevel.ResultSet.Tables[0].DefaultView.ToTable(true, "Role_ID", "Role_Name");
                dlRoles.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}