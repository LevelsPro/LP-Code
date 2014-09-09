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
    public partial class RoundEdit : AuthorizedPage
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
                //LoadKPI();

                if (Request.QueryString["matchid"] != null && Request.QueryString["matchid"].ToString() != "")
                {
                    ViewState["matchid"] = Request.QueryString["matchid"];
                    ViewState["rid"] = Request.QueryString["rid"];
                    ViewState["cmd"] = Request.QueryString["cmd"];

                    LoadData(Convert.ToInt32(ViewState["matchid"]), Convert.ToInt32(ViewState["rid"]));

                    btnHome.PostBackUrl = "~/AdminPanel/MatchEdit.aspx?matchid=" + ViewState["matchid"];
                }                
            }
        }

        #region show round for edit
        private void LoadData(int MatchID, int RoundID)
        {
            RoundViewBLL Roundview = new RoundViewBLL();
            
            Match _match = new Match();
            _match.Where = " WHERE MatchID = " + MatchID.ToString() + " AND "
                            + "RoundID = " + RoundID.ToString();
            Roundview.Match = _match;
            try
            {
                Roundview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (Roundview.ResultSet != null && Roundview.ResultSet.Tables.Count > 0 && Roundview.ResultSet.Tables[0] != null && Roundview.ResultSet.Tables[0].Rows.Count > 0)
            {
                txtMatchID.Text = ViewState["matchid"].ToString();
                txtRoundNumber.Text = Roundview.ResultSet.Tables[0].Rows[0]["RoundNumber"].ToString();
                txtRoundName.Text = Roundview.ResultSet.Tables[0].Rows[0]["RoundName"].ToString();
                txtNoOfDataSets.Text = Roundview.ResultSet.Tables[0].Rows[0]["NoOfDataSets"].ToString();
                txtTimePerRound.Text = Roundview.ResultSet.Tables[0].Rows[0]["TimePerRound"].ToString();
                txtPointsPerRound.Text = Roundview.ResultSet.Tables[0].Rows[0]["PointsPerRound"].ToString();
                if (Convert.ToInt32(Roundview.ResultSet.Tables[0].Rows[0]["ShowHint"]) == 0)
                    chkShowHint.Checked = false;
                else
                    chkShowHint.Checked = true;  

                switch (ViewState["cmd"].ToString())
                {
                    case "edit":
                        btnAddMatchRound.Text = Resources.TestSiteResources.Update;
                        this.Title = Resources.TestSiteResources.EditRound;
                        lblHeading.Text = Resources.TestSiteResources.EditRound;
                        break;
                    case "delete":
                        txtRoundNumber.Enabled = false;
                        txtRoundName.Enabled = false;
                        txtNoOfDataSets.Enabled = false;
                        txtTimePerRound.Enabled = false;
                        txtPointsPerRound.Enabled = false;
                        btnAddMatchRound.Text = Resources.TestSiteResources.Delete;
                        this.Title = Resources.TestSiteResources.DeleteRound;
                        lblHeading.Text = Resources.TestSiteResources.DeleteRound;
                        break;
                }
            }
            else
            {
                txtMatchID.Text = ViewState["matchid"].ToString();
                this.Title = Resources.TestSiteResources.AddRound;
                lblHeading.Text = Resources.TestSiteResources.AddRound;
            }
        }
        #endregion           

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        
        #region add and update data set
        protected void btnAddMatchRound_Click(object sender, EventArgs e)
        {
            if (txtMatchID.Text.Equals(""))
            {
                return;
            }
            else
            {
                Match match = new Match();

                match.MatchID = Convert.ToInt32(txtMatchID.Text.Trim());
                if (txtRoundNumber.Text.Trim() != "")
                {
                    match.NoRound = Convert.ToInt32(txtRoundNumber.Text.Trim());
                }
                if (txtRoundName.Text.Trim() != "") 
                {
                    match.RoundName = txtRoundName.Text.Trim();
                }
                if (txtNoOfDataSets.Text.Trim() != "") 
                {
                    match.NoDataSetPerRound = Convert.ToInt32(txtNoOfDataSets.Text.Trim());
                }
                if (txtTimePerRound.Text.Trim() != "") 
                {
                    match.TimePerRound = Convert.ToInt32(txtTimePerRound.Text.Trim());
                }
                if (txtPointsPerRound.Text.Trim() != "") 
                {
                    match.PointsPerRound = Convert.ToInt32(txtPointsPerRound.Text.Trim());
                }
                if (chkShowHint.Checked == true)
                {
                    match.ShowHint = 1;
                }
                else
                {
                    match.ShowHint = 0;
                }
                if (btnAddMatchRound.Text == "Update" || btnAddMatchRound.Text == "mettre à jour" || btnAddMatchRound.Text == "actualizar")
                {
                    if (ViewState["rid"] != null && ViewState["rid"].ToString() != "")
                    {
                        match.RoundID = Convert.ToInt32(ViewState["rid"]);
                        lblmessage.Visible = true;

                        RoundUpdateBLL updatedatset = new RoundUpdateBLL();
                        updatedatset.Match = match;
                        lblmessage.Visible = true;
                        try
                        {
                            updatedatset.Invoke();
                            lblmessage.Text = Resources.TestSiteResources.GameName + ' ' + Resources.TestSiteResources.UpdateMessage;
                            Response.Redirect("MatchEdit.aspx?matchid=" + ViewState["matchid"], false);

                        }
                        catch (Exception ex)
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.GameName;
                        }
                    }
                }
                else
                {
                    if (btnAddMatchRound.Text == "Delete" || btnAddMatchRound.Text == "supprimer" || btnAddMatchRound.Text == "borrar")
                    {
                        lblmessage.Visible = true;

                        RoundDeleteBLL deleteround = new RoundDeleteBLL();
                        if (ViewState["rid"] != null && ViewState["rid"].ToString() != "")
                        {
                            match.RoundID = Convert.ToInt32(ViewState["rid"]);
                            deleteround.Match = match;
                            try
                            {
                                deleteround.Invoke();
                                Response.Redirect("MatchEdit.aspx?matchid=" + ViewState["matchid"], false);
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
                        RoundInsertBLL insertRound = new RoundInsertBLL();
                        insertRound.Match = match;
                        try
                        {
                            insertRound.Invoke();

                            Response.Redirect("MatchEdit.aspx?matchid=" + ViewState["matchid"], false);
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
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MatchEdit.aspx?matchid=" + ViewState["matchid"]);
        }
    }
}