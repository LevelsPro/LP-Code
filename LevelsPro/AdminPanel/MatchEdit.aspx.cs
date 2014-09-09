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

namespace LevelsPro.AdminPanel
{
    public partial class MatchEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            if (!IsPostBack)
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
            }
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
            catch(Exception ex)
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

        //protected void LoadDS(int MatchID)
        //{
        //    DataElementViewBLL dsview = new DataElementViewBLL();
        //    Match _match = new Match();
        //    _match.Where = " WHERE MatchID = " + MatchID.ToString(); ;
        //    dsview.Match = _match;
        //    try
        //    {
        //        dsview.Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    if (dsview.ResultSet.Tables[0] != null && dsview.ResultSet.Tables[0].Rows.Count > 0)
        //    {

        //        dlDataElements.DataSource = dsview.ResultSet.Tables[0];
        //        dlDataElements.DataBind();
        //    }

        //}

        //protected void dlDataElements_ItemCommand(object source, DataListCommandEventArgs e)
        //{
        //    if (e.CommandName == "EditElement")
        //    {
        //        Response.Redirect("DataElementEdit.aspx?eid=" + e.CommandArgument.ToString() + "&matchid=" + ViewState["matchid"].ToString());
        //    }
        //    else if (e.CommandName == "DeleteElement")
        //    {
                
        //        DataElementDeleteBLL matchdelete = new DataElementDeleteBLL();
        //        Match _match = new Match();
        //        _match.MatchID = Convert.ToInt32(e.CommandArgument);
        //        matchdelete.Match = _match;
        //        try
        //        {
        //            matchdelete.Invoke();
        //        }
        //        catch (Exception ex)
        //        {
        //        }

        //        LoadDS(Convert.ToInt32(ViewState["matchid"]));
        //    }
        //    else if (e.CommandName == "ManageDataSets")
        //    {
        //        Response.Redirect("DataSetsManagement.aspx?matchid=" + e.CommandArgument.ToString());
        //    }

        //}

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        
        #region add and update match
        protected void btnAddMatch_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["MatchPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationManager.AppSettings["MatchThumbPath"].ToString());
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
                if (fuMatchImage.HasFile)
                {
                    string s = fuMatchImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fuMatchImage.FileName).ToLower();
                        fuMatchImage.SaveAs(path + GuidOne + FileExtension);

                        match.MatchImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);

                        match.MatchImageThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);
                    }
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

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {            
            Response.Redirect("MatchManagement.aspx");
        }

        protected void btnAddImage_Click(object sender, EventArgs e)
        {

        }
    }
}