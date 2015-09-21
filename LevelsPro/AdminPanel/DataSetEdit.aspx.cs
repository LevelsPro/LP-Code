using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using BusinessLogic.Select;
using Common;
using System.IO;
using BusinessLogic.Update;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using System.Data;
using MySql.Data.MySqlClient;
using BusinessLogic.Delete;
using Common.Utils;
using System.Collections;

namespace LevelsPro.AdminPanel
{
    public partial class DataSetEdit : AuthorizedPage
    {
        static DataSet dss;
        protected static Hashtable fileMetadata;
        int CountTextBoxes = 0;
        int CountHtmlImage = 0;
        private TextBox[] dynamicTextBoxes;
        private HtmlImage[] dynamicHtmlImage;
        private FileUpload[] dynamicFileUpload;

        static DataSetEdit()
        {
            fileMetadata = new Hashtable();
            fileMetadata.Add("folderPath", "DataSetPath");
            fileMetadata.Add("thumbnailPath", "DataSetThumbPath");

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
            if (Request.QueryString["matchid"] != null && Request.QueryString["matchid"].ToString() != "")
            {
                ViewState["matchid"] = Request.QueryString["matchid"];
                LoadDataElements(Convert.ToInt32(ViewState["matchid"]));
            }
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            lblMessage.Visible = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["mess"] != null && Request.QueryString["mess"].ToString() != "")
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "DataSet info " + Resources.TestSiteResources.UpdateMessage;
                }

                LoadSites();

                if (Request.QueryString["datasetid"] != null && Request.QueryString["datasetid"].ToString() != "")
                {
                    ViewState["datasetid"] = Request.QueryString["datasetid"];
                    LoadData(Convert.ToInt32(ViewState["datasetid"]));
                }
                loadDataList();
            }
            else
            {
                dynamicTextBoxes = (TextBox[])Session["dynamicTextBoxes"];
                dynamicHtmlImage = (HtmlImage[])Session["dynamicHtmlImage"];
                dynamicFileUpload = (FileUpload[])Session["dynamicFileUpload"];
            }
        }

        #region add controls
        private void LoadDataElements(int MatchID)
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
            if (dataelement.ResultSet != null && dataelement.ResultSet.Tables.Count > 0 && dataelement.ResultSet.Tables[0] != null && dataelement.ResultSet.Tables[0].Rows.Count > 0)
            {
                var elementid = 0;
                var elementname = "";
                var ispicture = 0;

                for (var i = dataelement.ResultSet.Tables[0].Rows.Count; i-- > 0; )
                {
                    elementid = Convert.ToInt32(dataelement.ResultSet.Tables[0].Rows[i]["ElementID"].ToString());
                    elementname = dataelement.ResultSet.Tables[0].Rows[i]["ElementName"].ToString();
                    ispicture = Convert.ToInt32(dataelement.ResultSet.Tables[0].Rows[i]["IsPicture"].ToString());

                    if (ispicture == 0)
                        CountTextBoxes++;
                    else
                        CountHtmlImage++;
                }

                dynamicTextBoxes = new TextBox[CountTextBoxes];
                dynamicHtmlImage = new HtmlImage[CountHtmlImage];
                dynamicFileUpload = new FileUpload[CountHtmlImage];

                CountTextBoxes = 0;
                CountHtmlImage = 0;

                for (var i = dataelement.ResultSet.Tables[0].Rows.Count; i-- > 0; )
                {
                    elementid = Convert.ToInt32(dataelement.ResultSet.Tables[0].Rows[i]["ElementID"].ToString());
                    elementname = dataelement.ResultSet.Tables[0].Rows[i]["ElementName"].ToString();
                    ispicture = Convert.ToInt32(dataelement.ResultSet.Tables[0].Rows[i]["IsPicture"].ToString());

                    if (ispicture == 0)
                        CountTextBoxes++;
                    else
                        CountHtmlImage++;

                    if (ispicture == 0)
                        CreateDataSetControls(elementid, elementname, ispicture, CountTextBoxes);
                    else
                        CreateDataSetControls(elementid, elementname, ispicture, CountHtmlImage);
                }
                Session["dynamicTextBoxes"] = dynamicTextBoxes;
                Session["dynamicHtmlImage"] = dynamicHtmlImage;
                Session["dynamicFileUpload"] = dynamicFileUpload;
            }
        }

        private void CreateDataSetControls(int ElementID, string ElementName, int IsPicture, int counter)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            HtmlGenericControl flwrapper = (HtmlGenericControl)content.FindControl("flWrapper");

            int controlNumber = 2;

            if (IsPicture == 1)
            {
                #region Picture
                //div fl-wrapper img-r mt10 pr
                HtmlGenericControl _flwrapper = new HtmlGenericControl();
                _flwrapper.Attributes.Add("class", "fl-wrapper img-r mt10 pr");
                _flwrapper.TagName = "div";
                _flwrapper.Style.Add("overflow", "hidden");
                _flwrapper.Style.Add("margin", "5px");

                //div r-image
                HtmlGenericControl _rimage = new HtmlGenericControl();
                _rimage.Attributes.Add("class", "r-image");
                _rimage.TagName = "div";

                //img imgDataSet
                HtmlImage imgDataSet = new HtmlImage();
                imgDataSet.ID = "imgDataSet_" + ElementID;
                imgDataSet.Src = "/Images/No_Image_Wide.png";
                imgDataSet.Style.Add("width", "284px");
                imgDataSet.Style.Add("height", "223px");
                dynamicHtmlImage[counter - 1] = imgDataSet;

                //field hdImage
                HiddenField hdImage = new HiddenField();
                hdImage.ID = "hdImage_" + ElementID;
                hdImage.Value = "/Images/No_Image_Wide.png";

                _rimage.Controls.Add(imgDataSet);
                _rimage.Controls.Add(hdImage);

                _flwrapper.Controls.Add(_rimage);

                //div _greenbtn
                HtmlGenericControl _greenbtn = new HtmlGenericControl();
                _greenbtn.Attributes.Add("class", "green-btn create-reward change-img fr");
                _greenbtn.TagName = "div";

                Label lblimg = new Label();
                lblimg.ID = "lblimg_" + ElementID;
                lblimg.Text = Resources.TestSiteResources.ChangeImage;

                _greenbtn.Controls.Add(lblimg);

                _flwrapper.Controls.Add(_greenbtn);

                FileUpload fuDataSetImage = new FileUpload();
                fuDataSetImage.ID = "fuQuestionImage_" + ElementID;
                fuDataSetImage.CssClass = "change-img-transparent";
                fuDataSetImage.Attributes.Add("onchange", "readURL(this, '" + content.ID + "_" + imgDataSet.ID + "');");
                dynamicFileUpload[counter - 1] = fuDataSetImage;

                _flwrapper.Controls.Add(fuDataSetImage);

                Button btnAddImage = new Button();
                btnAddImage.CssClass = "green-btn create-reward change-img fr";
                btnAddImage.Text = Resources.TestSiteResources.AddImage;
                btnAddImage.Visible = false;

                _flwrapper.Controls.Add(btnAddImage);

                HtmlGenericControl _clear = new HtmlGenericControl();
                _clear.Attributes.Add("class", "clear");
                _clear.TagName = "div";

                _flwrapper.Controls.Add(_clear);

                flwrapper.Controls.AddAt(controlNumber, _flwrapper);

                controlNumber = controlNumber + _flwrapper.Controls.Count + 1;
                #endregion
            }
            else
            {
                #region TextBox
                //div strip
                HtmlGenericControl _strip = new HtmlGenericControl();
                _strip.Attributes.Add("class", "strip");
                _strip.TagName = "div";

                Label lblDataSetText = new Label();
                lblDataSetText.ID = "lblDataSetText_" + ElementID;
                lblDataSetText.CssClass = "edit-left";
                lblDataSetText.Text = ElementName;

                _strip.Controls.Add(lblDataSetText);

                HtmlGenericControl _editright = new HtmlGenericControl();
                _editright.Attributes.Add("class", "edit-right tl");

                TextBox txtDataSet = new TextBox();
                txtDataSet.ID = "txtDataSet_" + ElementID;
                txtDataSet.CssClass = "qq-admin";
                txtDataSet.MaxLength = 200;
                txtDataSet.AutoCompleteType = AutoCompleteType.Disabled;
                txtDataSet.Attributes.Add("onfocus", "disableautocompletion(this.id);");
                dynamicTextBoxes[counter - 1] = txtDataSet;

                _editright.Controls.Add(txtDataSet);

                RequiredFieldValidator rfvDataSet = new RequiredFieldValidator();
                rfvDataSet.ID = "rfvDataSet_" + ElementID;
                rfvDataSet.ErrorMessage = "Provide " + ElementName;
                rfvDataSet.ControlToValidate = "txtDataSet_" + ElementID;
                rfvDataSet.Display = ValidatorDisplay.Dynamic;
                rfvDataSet.SetFocusOnError = true;
                rfvDataSet.ValidationGroup = "Insertion";
                rfvDataSet.Text = " * ";

                _editright.Controls.Add(rfvDataSet);

                _strip.Controls.Add(_editright);

                HtmlGenericControl _clear = new HtmlGenericControl();
                _clear.Attributes.Add("class", "clear");
                _clear.TagName = "div";

                _strip.Controls.Add(_clear);

                flwrapper.Controls.AddAt(controlNumber, _strip);

                controlNumber = controlNumber + _strip.Controls.Count + 1;
                #endregion
            }

        }
        #endregion

        #region show question for edit
        private void LoadData(int DataSetID)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");

            string path = ConfigurationManager.AppSettings["DataSetPath"].ToString();
            DataSetViewBLL matchview = new DataSetViewBLL();
            Match _match = new Match();
            _match.Status = 0;
            _match.Where = " WHERE DataSetID = " + DataSetID.ToString();
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
                ddlLocation.SelectedIndex = ddlLocation.Items.IndexOf(ddlLocation.Items.FindByValue(matchview.ResultSet.Tables[0].Rows[0]["SiteID"].ToString()));

                //ddlLocation.SelectedValue = matchview.ResultSet.Tables[0].Rows[0]["SiteID"].ToString();

                var imgDataSet = (HtmlImage)content.FindControl(dynamicHtmlImage[0].ID);

                imgDataSet.Src = path + matchview.ResultSet.Tables[0].Rows[0]["DataSetImage"].ToString();

                string[] dataElementData = matchview.ResultSet.Tables[0].Rows[0]["DataSetElementsData"].ToString().Split('|');

                for (var j = 0; j < dataElementData.Length; j++)
                {
                    if (!string.IsNullOrEmpty(dataElementData[j]))
                    {
                        var txtData = (TextBox)content.FindControl(dynamicTextBoxes[j].ID);

                        txtData.Text = dataElementData[j];
                    }
                }

                ViewState["DataSetImage"] = matchview.ResultSet.Tables[0].Rows[0]["DataSetImage"].ToString();
                ViewState["DataSetImageThumbnail"] = matchview.ResultSet.Tables[0].Rows[0]["DataSetImageThumbnail"].ToString();

                btnAddDataSet.Text = Resources.TestSiteResources.Update;
            }
        }
        #endregion

        private void LoadSites()
        {
            Site_DropDownBLL Site = new Site_DropDownBLL();
            try
            {
                Site.Invoke();
            }
            catch (Exception)
            {
            }

            ddlLocation.DataTextField = "site_name";
            ddlLocation.DataValueField = "site_id";
            ddlLocation.DataSource = Site.ResultSet;
            ddlLocation.DataBind();
            this.ddlLocation.Items.Insert(0, new ListItem("Select All", "0"));
            this.ddlLocation.SelectedIndex = 0;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
            {
                Response.Redirect("DataSetManagement.aspx?matchid=" + ViewState["matchid"].ToString(), false);
            }
        }

        #region add and update question
        protected void btnAddDataSet_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
            FileResources resource = FileResources.Instance;

            Match match = new Match();

            string data = "";
            for (int i = 0; i < dynamicTextBoxes.Length; i++)
            {
                //var txtData = (TextBox)content.FindControl(dynamicTextBoxes[i].ID);
                var txtData = Request[dynamicTextBoxes[i].UniqueID].ToString(); // (TextBox)content.FindControl(dynamicTextBoxes[i].ID);
                data = data + txtData + "|";
            }

            match.DataElementData = data;

            match.SiteID = Convert.ToInt32(Request[ddlLocation.UniqueID]);

            var fuDataSetImage = Request.Files[dynamicFileUpload[0].UniqueID];
            string imageId = resource.save(fuDataSetImage, fileMetadata);
            if (!string.IsNullOrEmpty(imageId))
            {
                match.DataSetImage = imageId;
                match.DataSetImageThumbnail = imageId;
            }
            else
            {
                if (ViewState["DataSetImage"] != null && ViewState["DataSetImage"].ToString() != "")
                {
                    match.DataSetImage = ViewState["DataSetImage"].ToString();
                }
                if (ViewState["DataSetImageThumbnail"] != null && ViewState["DataSetImageThumbnail"].ToString() != "")
                {
                    match.DataSetImageThumbnail = ViewState["DataSetImageThumbnail"].ToString();
                }
            }

            if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
            {
                match.MatchID = Convert.ToInt32(ViewState["matchid"]);

                MySqlConnection scon = new MySqlConnection(ConfigurationManager.ConnectionStrings["SQLCONN"].ToString());
                scon.Open();
                MySqlTransaction sqlTrans = scon.BeginTransaction();
                match.sqlTransaction = sqlTrans;
                try
                {
                    if (btnAddDataSet.Text == "Update" || btnAddDataSet.Text == "mettre à jour" || btnAddDataSet.Text == "actualizar")
                    {
                        if (ViewState["datasetid"] != null && ViewState["datasetid"].ToString() != "")
                        {
                            DataSetUpdateBLL updategame = new DataSetUpdateBLL();
                            match.DataSetID = Convert.ToInt32(ViewState["datasetid"]);

                            updategame.Match = match;
                            updategame.Invoke();
                        }
                    }
                    else
                    {
                        DataSetsInsertBLL insertmatch = new DataSetsInsertBLL();

                        insertmatch.Match = match;
                        insertmatch.Invoke();
                    }

                    DataSetLevelDeleteBLL del = new DataSetLevelDeleteBLL();
                    DataSetLevelsInsertBLL qLevels = new DataSetLevelsInsertBLL();

                    del.Match = match;
                    del.Invoke();

                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {
                        if (dss.Tables[0].Rows[i]["Allow"].ToString() == "yes")
                        {
                            match.RoleID = Convert.ToInt32(dss.Tables[0].Rows[i]["Role_ID"].ToString());
                            match.LevelID = Convert.ToInt32(dss.Tables[0].Rows[i]["Level_ID"].ToString());
                            qLevels.Match = match;
                            qLevels.Invoke();
                        }

                    }
                    sqlTrans.Commit();

                    if (btnAddDataSet.Text == "Update" || btnAddDataSet.Text == "mettre à jour" || btnAddDataSet.Text == "actualizar")
                    {
                        //LoadDataElements(Convert.ToInt32(ViewState["matchid"]));
                        LoadData(int.Parse(match.DataSetID.ToString()));
                        lblMessage.Visible = true;
                        lblMessage.Text = "DataSet info " + Resources.TestSiteResources.UpdateMessage;
                        Response.Redirect("DataSetEdit.aspx?mess=1" + "&datasetid=" + ViewState["datasetid"].ToString() + "&matchid=" + ViewState["matchid"].ToString(), false);

                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "DataSet info " + ' ' + Resources.TestSiteResources.SavedMessage;
                        Response.Redirect("DataSetManagement.aspx?matchid=" + ViewState["matchid"].ToString(), false);
                    }
                }
                catch (Exception)
                {
                    sqlTrans.Rollback();
                }
                finally
                {
                    sqlTrans.Dispose();
                    scon.Close();
                }
            }
        }
        #endregion

        protected void dlLevels_ItemCommand(object sender, DataListCommandEventArgs e)
        {
            DataList dlLevels = sender as DataList;
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

        protected void btnHome_Click(object sender, EventArgs e)
        {
            if (ViewState["matchid"] != null && ViewState["matchid"].ToString() != "")
            {
                Response.Redirect("DataSetManagement.aspx?matchid=" + ViewState["matchid"].ToString(), false);
            }
        }

        private void loadDataList()
        {
            RolesLevelsDataSetViewBLL Rolelevel = new RolesLevelsDataSetViewBLL();
            Match match = new Match();

            if (ViewState["datasetid"] != null && ViewState["datasetid"].ToString() != "")
            {
                match.DataSetID = Convert.ToInt32(ViewState["datasetid"]);
            }
            else
            {
                match.DataSetID = -1;
            }
            Rolelevel.Match = match;
            Rolelevel.Invoke();
            dss = new DataSet();
            dss = Rolelevel.ResultSet;
            dlRoles.DataSource = Rolelevel.ResultSet.Tables[0].DefaultView.ToTable(true, "Role_ID", "Role_Name");
            dlRoles.DataBind();
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
    }
}