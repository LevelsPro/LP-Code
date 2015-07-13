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
using System.Configuration;
using BusinessLogic.Delete;
using System.IO;
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;
using Common.Utils;
using System.Collections;

namespace LevelsPro.AdminPanel
{
    public partial class AwardEdit : AuthorizedPage
    {
        private static string pageURL;
        protected static Hashtable fileMetadata;
        static DataTable dtImages = new DataTable();
        static int imageid = 0;
        static int previousid = 0;
        static int currentid = 0;
        private ILog log;

        static AwardEdit()
        {
            fileMetadata = new Hashtable();
            fileMetadata.Add("folderPath", "AwardsPath");
            fileMetadata.Add("thumbnailPath", "AwardsThumbPath");

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
            if (!Page.IsPostBack)
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();

                #region language check for images
                if (Session["MyCulture"] != null && Session["MyCulture"].ToString() != "")
                {
                    if (Session["MyCulture"].ToString() == "es-ES")
                    {
                        imgUpload.ImageUrl = "Images/upload-photo_spanish.png";
                    }
                    else if (Session["MyCulture"].ToString() == "fr-FR")
                    {
                        imgUpload.ImageUrl = "Images/upload-photo_french.png";
                    }
                    else
                    {
                        imgUpload.ImageUrl = "Images/upload-photo.png";
                    }
                }
                #endregion

                if (Request.QueryString["awardid"] != null && Request.QueryString["awardid"].ToString() != "")
                {
                    ViewState["awardid"] = Request.QueryString["awardid"];
                    LoadImagesData(Convert.ToInt32(ViewState["awardid"]));
                }
                try
                {
                    LoadCategory();
                    LoadKPI();
                    LoadData();
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

        #region load all awards from db code

        protected void LoadData()
        {
            string Thumbpath = ConfigurationManager.AppSettings["AwardsThumbPath"].ToString();//get path for award image
            int id = Convert.ToInt32(Request.QueryString["awardid"]);

            if (id != 0)
            {
                lblActive.Visible = true;
                cbActive.Visible = true;
                lblHeading.Text = Resources.TestSiteResources.EditAward;

                AwardViewBLL award = new AwardViewBLL();

                try
                {
                    award.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataView dv = award.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "Award_ID=" + id.ToString();

                DataTable dt = new DataTable();
                dt = dv.ToTable();
                lblmessage.Visible = false;

                txtAwardName.Text = dt.Rows[0]["Award_Name"].ToString();

                txtAwardDesc.Text = dt.Rows[0]["Award_Desc"].ToString();
                txtTarget.Text = dt.Rows[0]["Target_Value"].ToString();
                ddlKPI.SelectedValue = dt.Rows[0]["KPIID"].ToString();
                ddlAwardCategory.SelectedValue = dt.Rows[0]["AwardCategoryID"].ToString();



                if (dt.Rows[0]["Award_Manual"].ToString() == "1")
                {
                    ddlManual.SelectedIndex = 2;
                    revTarget.ValidationGroup = "manual";
                    ddlKPI.Style.Add("visibility", "hidden");
                    txtTarget.Style.Add("visibility", "hidden");
                    lblAwardKPI.Style.Add("visibility", "hidden");
                    lblTarget.Style.Add("visibility", "hidden");

                }
                else
                {
                    ddlManual.SelectedIndex = 1;
                    revTarget.ValidationGroup = "Insertion";
                    ddlKPI.Style.Add("visibility", "visible");
                    txtTarget.Style.Add("visibility", "visible");
                    lblAwardKPI.Style.Add("visibility", "visible");
                    lblTarget.Style.Add("visibility", "visible");
                }
                if (dt.Rows[0]["Active"].ToString() == "1")
                {
                    cbActive.Checked = true;
                }
                else
                {
                    cbActive.Checked = false;
                }
                lblmessage.Visible = false;



                pnlImg.Visible = true;
                btnAddAward.Text = Resources.TestSiteResources.Update;
            }
            else
            {
                lblHeading.Text = Resources.TestSiteResources.AddAward;

                ddlManual.SelectedIndex = 0;
                lblActive.Visible = false;
                cbActive.Visible = false;
                imageid = 0;
                dtImages = new DataTable();
                LoadImagesData(0);
                dtImages.Columns.Add("ID", typeof(int));
                dtImages.Columns.Add("Award_Image", typeof(string));
                dtImages.Columns.Add("Award_Thumbnail", typeof(string));
                dtImages.Columns.Add("Active", typeof(int));
                dtImages.Columns.Add("Award_ID", typeof(int));
                dtImages.Columns.Add("Current_Image", typeof(int));
            }
        }
        #endregion
        #region laod kpi for drop down list

        protected void LoadKPI()
        {
            KPIViewBLL kpi = new KPIViewBLL();
            try
            {
                kpi.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlKPI.DataTextField = "KPI_name";
            ddlKPI.DataValueField = "KPI_ID";

            DataView dv = kpi.ResultSet.Tables[0].DefaultView;

            dv.RowFilter = "Active=1 AND TypeAward='Award'";
            try
            {
                ddlKPI.DataSource = dv.ToTable();
                ddlKPI.DataBind();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            ListItem li = new ListItem("Select", "0");
            ddlKPI.Items.Insert(0, li);
        }
        #endregion

        #region load category for drop down list
        protected void LoadCategory()
        {
            DropdownViewBLL dropdown = new DropdownViewBLL();
            Dropdown _dropdown = new Dropdown();
            _dropdown.ReferenceCode = "AWARD_CATEGORY";
            dropdown.Dropdown = _dropdown;

            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dropdown.ResultSet != null && dropdown.ResultSet.Tables.Count > 0 && dropdown.ResultSet.Tables[0] != null && dropdown.ResultSet.Tables[0].Rows.Count > 0)
            {
                ddlAwardCategory.DataTextField = "Description";
                ddlAwardCategory.DataValueField = "ReferenceData_ID";

                ddlAwardCategory.DataSource = dropdown.ResultSet;
                ddlAwardCategory.DataBind();

                ListItem li = new ListItem("Select", "0");
                ddlAwardCategory.Items.Insert(0, li);
            }
        }
        #endregion

        #region add and update award code
        protected void btnAddAward_Click(object sender, EventArgs e)
        {
            if (txtAwardName.Text.Equals(""))
            {
                return;
            }
            else
            {
                string Thumbpath = (string)fileMetadata["thumbnailPath"];
                Award award = new Award();
                award.AwardName = txtAwardName.Text.Trim();
                award.AwardDesc = txtAwardDesc.Text.Trim();
                award.AwardCategoryID = Convert.ToInt32(ddlAwardCategory.SelectedValue);

                if (ddlManual.SelectedIndex == 2)
                {
                    revTarget.ValidationGroup = "manual";
                    award.AwardManual = 1;
                    award.KPIID = 0;
                    award.TargetID = 0;

                    ddlKPI.Style.Add("visibility", "hidden");
                    txtTarget.Style.Add("visibility", "hidden");
                    lblAwardKPI.Style.Add("visibility", "hidden");
                    lblTarget.Style.Add("visibility", "hidden");
                }
                else
                {
                    revTarget.ValidationGroup = "Insertion";
                    if (txtTarget.Text.Trim() != "")
                    {
                        award.KPIID = Convert.ToInt32(ddlKPI.SelectedValue);
                        award.TargetID = Convert.ToInt32(txtTarget.Text.Trim());
                        award.AwardManual = 0;
                        ddlKPI.Style.Add("visibility", "visible");
                        txtTarget.Style.Add("visibility", "visible");
                        lblAwardKPI.Style.Add("visibility", "visible");
                        lblTarget.Style.Add("visibility", "visible");
                    }
                    else
                    {
                        lblmessage.Visible = true;
                        lblmessage.Text = "Target is required.";
                        award.AwardManual = 0;
                        ddlKPI.Style.Add("visibility", "visible");
                        txtTarget.Style.Add("visibility", "visible");
                        lblAwardKPI.Style.Add("visibility", "visible");
                        lblTarget.Style.Add("visibility", "visible");
                        return;
                    }

                }


                if (btnAddAward.Text == "Update" || btnAddAward.Text == "mettre à jour" || btnAddAward.Text == "actualizar")
                {
                    AwardUpdateBLL UpdateAward = new AwardUpdateBLL();
                    award.AwardID = Convert.ToInt32(Request.QueryString["awardid"]);
                    lblmessage.Visible = true;
                    if (cbActive.Checked)
                    {
                        award.Active = 1;
                    }
                    else
                    {
                        award.Active = 0;
                    }
                    int id = Convert.ToInt32(currentid);
                    award.ID = id;

                    award.CurrentImage = 1;
                    UpdateAward.Award = award;
                    try
                    {
                        UpdateAward.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.AwardsB;
                    }
                    int previous = Convert.ToInt32(previousid);
                    award.ID = previous;

                    award.CurrentImage = 0;
                    UpdateAward.Award = award;
                    try
                    {
                        UpdateAward.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.AwardsB;
                    }
                }
                else if (btnAddAward.Text == "Add" || btnAddAward.Text == "Ajouter" || btnAddAward.Text == "añadir")
                {
                    pnlImg.Visible = false;

                    AwardInsertBLL insertAward = new AwardInsertBLL();
                    insertAward.Award = award;
                    lblmessage.Visible = true;
                    try
                    {
                        int AwardID = insertAward.Invoke();

                        AwardImageInsertBLL insertimage = new AwardImageInsertBLL();
                        if (dtImages != null && dtImages.Rows.Count > 0)
                        {
                            foreach (DataRow drow in dtImages.Rows)
                            {
                                award.AwardID = AwardID;
                                award.AwardImage = drow["Award_Image"].ToString();
                                award.AwardThumbnail = drow["Award_Thumbnail"].ToString();
                                if (currentid == Convert.ToInt32(drow["ID"]))
                                {
                                    award.CurrentImage = 1;
                                }
                                else
                                {
                                    award.CurrentImage = 0;
                                }
                                insertimage.Award = award;
                                insertimage.Invoke();

                            }
                        }

                        lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.SavedMessage;
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Visible = true;
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.AwardsB + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.AwardsB;
                        }
                    }



                }
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                btnAddAward.Text = Resources.TestSiteResources.Add;
                txtAwardName.Text = "";

                txtAwardDesc.Text = "";
                ddlKPI.Style.Add("visibility", "visible");
                txtTarget.Style.Add("visibility", "visible");
                lblAwardKPI.Style.Add("visibility", "visible");
                lblTarget.Style.Add("visibility", "visible");
                ddlKPI.SelectedIndex = -1;
                txtTarget.Text = "";
                cbActive.Checked = false;

                ddlManual.SelectedIndex = 0;

                revTarget.ValidationGroup = "Insertion";
                Response.Redirect("AwardManagement.aspx");
            }
        }
        #endregion
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddAward.Text = Resources.TestSiteResources.Add;
            txtAwardName.Text = "";

            txtAwardDesc.Text = "";
            ddlKPI.SelectedIndex = -1;
            ddlManual.SelectedIndex = 0;
            txtTarget.Text = "";
            cbActive.Checked = false;

            revTarget.ValidationGroup = "Insertion";
            ddlKPI.Style.Add("visibility", "visible");
            txtTarget.Style.Add("visibility", "visible");
            lblAwardKPI.Style.Add("visibility", "visible");
            lblTarget.Style.Add("visibility", "visible");

            Response.Redirect("AwardManagement.aspx");

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        #region image upload and save code
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FileResources resource = FileResources.Instance;
            AwardImageInsertBLL insertimage = new AwardImageInsertBLL();

            Award award = new Award();
            if (ViewState["awardid"] != null && ViewState["awardid"].ToString() != "" && Convert.ToInt32(ViewState["awardid"]) != 0)
            {
                award.AwardID = Convert.ToInt32(ViewState["awardid"]);
                string imageId = resource.save(fileAwardImage, fileMetadata);
                if (!string.IsNullOrEmpty(imageId))
                {
                    award.AwardImage = imageId;
                    award.AwardThumbnail = imageId;
                    award.CurrentImage = 0;
                    try
                    {
                        insertimage.Award = award;
                        insertimage.Invoke();

                        LoadImagesData(Convert.ToInt32(Request.QueryString["awardid"]));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {

                award.AwardID = Convert.ToInt32(Request.QueryString["awardid"]);
                string imageId = resource.save(fileAwardImage, fileMetadata);
                if (!string.IsNullOrEmpty(imageId))
                {
                    award.AwardImage = imageId;
                    award.AwardThumbnail = imageId;

                    try
                    {
                        dtImages.Rows.Add(imageid, award.AwardImage, award.AwardThumbnail, 1, 1, 0);
                        imageid++;
                        dtImages.AcceptChanges();
                        LoadImagesData(0);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }
        #endregion

        #region get award image
        protected void LoadImagesData(int AwardID)
        {

            if (AwardID != 0)
            {
                string Thumbpath = ConfigurationManager.AppSettings["AwardsThumbPath"].ToString();
                AwardImagesViewBLL awardimage = new AwardImagesViewBLL();
                Award _award = new Award();

                try
                {
                    awardimage.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dvImage = awardimage.ResultSet.Tables[0].DefaultView;

                DataTable dt = new DataTable();
                dt = dvImage.ToTable();

                dvImage.RowFilter = "Award_ID=" + AwardID.ToString();

                dlImages.DataSource = dvImage.ToTable();
                dlImages.DataBind();

                DataView dvImage1 = awardimage.ResultSet.Tables[0].DefaultView;
                dvImage1.RowFilter = "Current_Image=1 AND Award_ID=" + AwardID.ToString();
                DataTable dtcImage = new DataTable();
                dtcImage = dvImage1.ToTable();
                if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Award_Image"].ToString() != "")
                {
                    imgCurrentImage.ImageUrl = Thumbpath + dtcImage.Rows[0]["Award_Image"].ToString();

                }
            }
            else
            {
                if (dtImages != null && dtImages.Rows.Count > 0)
                {
                    dlImages.DataSource = null;
                    dlImages.DataBind();
                    dlImages.DataSource = dtImages;
                    dlImages.DataBind();
                }
                else
                {
                    dlImages.DataSource = null;
                    dlImages.DataBind();
                }
            }
        }
        #endregion

        protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewImages")
            {

                string Thumbpath = ConfigurationManager.AppSettings["AwardsThumbPath"].ToString();
                if (ViewState["awardid"] != null && ViewState["awardid"].ToString() != "" && Convert.ToInt32(ViewState["awardid"]) != 0)
                {
                    AwardImagesViewBLL awardimage = new AwardImagesViewBLL();
                    Award _award = new Award();

                    try
                    {
                        awardimage.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    DataView dvImage = awardimage.ResultSet.Tables[0].DefaultView;

                    dvImage.RowFilter = "Current_Image=1 AND Award_ID=" + Request.QueryString["awardid"].ToString();

                    DataTable dtcImage = new DataTable();
                    dtcImage = dvImage.ToTable();

                    currentid = Convert.ToInt32(e.CommandArgument);

                    DataView dvImage1 = awardimage.ResultSet.Tables[0].DefaultView;


                    dvImage.RowFilter = "Award_ID=" + Request.QueryString["awardid"].ToString() + " AND ID=" + currentid;


                    DataTable dtcImage1 = new DataTable();
                    dtcImage1 = dvImage1.ToTable();

                    if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["ID"].ToString() != "")
                    {
                        previousid = Convert.ToInt32(dtcImage.Rows[0]["ID"]);
                    }

                    if (currentid != 0)
                    {

                        imgCurrentImage.ImageUrl = Thumbpath + dtcImage1.Rows[0]["Award_Thumbnail"];
                    }
                }
                else
                {
                    currentid = Convert.ToInt32(e.CommandArgument);
                    if (dtImages != null && dtImages.Rows.Count > 0)
                    {
                        DataView dvImage = dtImages.DefaultView;
                        dvImage.RowFilter = "ID = " + currentid.ToString();

                        imgCurrentImage.ImageUrl = Thumbpath + dvImage.ToTable().Rows[0]["Award_Thumbnail"];
                        dvImage.RowFilter = "";
                        dtImages.AcceptChanges();
                    }
                }
            }
            else if (e.CommandName == "DeleteImage")
            {
                if (ViewState["awardid"] != null && ViewState["awardid"].ToString() != "" && Convert.ToInt32(ViewState["awardid"]) != 0)
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    AwardImageDeleteBLL deleteImage = new AwardImageDeleteBLL();
                    Award award = new Award();

                    award.ID = ID;

                    deleteImage.Award = award;

                    try
                    {
                        deleteImage.Invoke();
                        LoadImagesData(Convert.ToInt32(Request.QueryString["awardid"]));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    for (int i = 0; i < dtImages.Rows.Count; i++)
                    {
                        if (ID == Convert.ToInt32(dtImages.Rows[i]["ID"]))
                        {
                            dtImages.Rows[i].Delete();
                            dtImages.AcceptChanges();
                            if (currentid == ID)
                            {
                                imgCurrentImage.ImageUrl = null;
                            }
                        }
                    }
                    LoadImagesData(0);
                }
            }

        }
    }
}
