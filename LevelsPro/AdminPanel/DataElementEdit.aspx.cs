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
    public partial class DataElementEdit : AuthorizedPage
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
                    ViewState["eid"] = Request.QueryString["eid"];
                    ViewState["cmd"] = Request.QueryString["cmd"];

                    LoadData(Convert.ToInt32(ViewState["matchid"]), Convert.ToInt32(ViewState["eid"]));

                    btnHome.PostBackUrl = "~/AdminPanel/MatchEdit.aspx?matchid=" + ViewState["matchid"];
                }
            }
        }

        #region show data set for edit
        private void LoadData(int MatchID, int ElementID)
        {
            DataElementViewBLL dataelementview = new DataElementViewBLL();
            
            Match _match = new Match();
            _match.Where = " WHERE MatchID = " + MatchID.ToString() + " AND "
                            + "ElementID = " + ElementID.ToString();
            dataelementview.Match = _match;
            try
            {
                dataelementview.Invoke();
            }
            catch (Exception ex)
            {
            }

            if (dataelementview.ResultSet != null && dataelementview.ResultSet.Tables.Count > 0 && dataelementview.ResultSet.Tables[0] != null && dataelementview.ResultSet.Tables[0].Rows.Count > 0)
            {
                txtMatchID.Text = ViewState["matchid"].ToString();
                txtElementName.Text = dataelementview.ResultSet.Tables[0].Rows[0]["ElementName"].ToString();

                if (Convert.ToInt32(dataelementview.ResultSet.Tables[0].Rows[0]["IsPicture"]) == 0)
                    chkIsPicture.Checked = false;
                else
                    chkIsPicture.Checked = true;                

                switch (ViewState["cmd"].ToString()) 
                {
                    case "edit":
                        btnAddMatchDataElement.Text = Resources.TestSiteResources.Update;
                        this.Title = Resources.TestSiteResources.EditDataElement;
                        lblHeading.Text = Resources.TestSiteResources.EditDataElement;
                        break;
                    case "delete":
                        txtElementName.Enabled = false;
                        btnAddMatchDataElement.Text = Resources.TestSiteResources.Delete;
                        this.Title = Resources.TestSiteResources.DeleteDataElement;
                        lblHeading.Text = Resources.TestSiteResources.DeleteDataElement;
                        break;
                }
            }
            else 
            {
                txtMatchID.Text = ViewState["matchid"].ToString();
                this.Title = Resources.TestSiteResources.AddDataElement;
                lblHeading.Text = Resources.TestSiteResources.AddDataElement;
            }
        }
        #endregion           

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        
        #region add and update data set
        protected void btnAddMatchDataSet_Click(object sender, EventArgs e)
        {
            if (txtMatchID.Text.Equals(""))
            {
                return;
            }
            else
            {
                Match match = new Match();

                match.MatchID = Convert.ToInt32(txtMatchID.Text.Trim());
                if (txtElementName.Text.Trim() != "")
                {
                    match.ElementName = txtElementName.Text.Trim();
                }
                if (chkIsPicture.Checked == true)
                {
                    match.IsPicture = 1;
                }
                else 
                {
                    match.IsPicture = 0;
                }
                if (btnAddMatchDataElement.Text == "Update" || btnAddMatchDataElement.Text == "mettre à jour" || btnAddMatchDataElement.Text == "actualizar")
                {
                    if (ViewState["eid"] != null && ViewState["eid"].ToString() != "")
                    {
                        match.ElementID = Convert.ToInt32(ViewState["eid"]);
                        lblmessage.Visible = true;

                        DataElementUpdateBLL updatedatset = new DataElementUpdateBLL();
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
                    if (btnAddMatchDataElement.Text == "Delete" || btnAddMatchDataElement.Text == "supprimer" || btnAddMatchDataElement.Text == "borrar")
                    {
                        lblmessage.Visible = true;

                        DataElementDeleteBLL deletedataelement = new DataElementDeleteBLL();
                        if (ViewState["eid"] != null && ViewState["eid"].ToString() != "")
                        {
                            match.ElementID = Convert.ToInt32(ViewState["eid"]);
                            deletedataelement.Match = match;
                            try
                            {
                                deletedataelement.Invoke();
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
                        DataElementInsertBLL insertdataelement = new DataElementInsertBLL();
                        match.MatchID = Convert.ToInt32(ViewState["matchid"]);
                        insertdataelement.Match = match;
                        try
                        {
                            insertdataelement.Invoke();

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