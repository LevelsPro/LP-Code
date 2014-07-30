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
using System.IO;
using BusinessLogic.Delete;
using LevelsPro.App_Code;

namespace LevelsPro.AdminPanel
{
    public partial class RewardEdit : AuthorizedPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        static DataTable dtImages = new DataTable();
        static int imageid = 0;
        static int previousid = 0;
        static int currentid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                #region language image code
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
                if (Convert.ToInt32(Request.QueryString["rewardid"]) != 0)
                {
                    ViewState["rewardid"] = Request.QueryString["rewardid"];
                   
                    LoadImagesData(Convert.ToInt32(ViewState["rewardid"]));
                    pnlCurrentImage.Visible = true;
                }
                LoadData();
            }

        }

        protected void LoadData()
        {
            string Thumbpath = ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString();
            int id = Convert.ToInt32(Request.QueryString["rewardid"]);

            if (id != 0)
            {
                cbActive.Visible = true;
              
                lblHeading.Text = Resources.TestSiteResources.EditReward;
                RewardViewBLL reward = new RewardViewBLL();

            
                try
                {
                    reward.Invoke();
                }
                catch (Exception ex)
                {
                    
                }
                DataView dv = reward.ResultSet.Tables[0].DefaultView;
                dv.RowFilter = "Reward_ID=" + id.ToString();
                DataTable dt = new DataTable();
                dt = dv.ToTable();
                lblmessage.Visible = false;
                txtRewardName.Text = dt.Rows[0]["Reward_Name"].ToString();
                txtRewardDescp.Text = dt.Rows[0]["Reward_Descp"].ToString();
                txtRewardPoints.Text = dt.Rows[0]["Reward_Cost"].ToString();
                
                 ddlType.SelectedValue = dt.Rows[0]["Reward_Type"].ToString();
                
              
                if (dt.Rows[0]["Active"].ToString() == "True")
                {
                    cbActive.Checked = true;
                }
                else
                {
                    cbActive.Checked = false;
                }

                btnAddReward.Text = Resources.TestSiteResources.Update;

            }
            else
            {
                lblHeading.Text = Resources.TestSiteResources.AddReward;
                cbActive.Enabled = false;
                ddlType.SelectedValue ="-1";
            
                imageid = 0;
                dtImages = new DataTable();
                LoadImagesData(0);
                dtImages.Columns.Add("ID", typeof(int));
                dtImages.Columns.Add("Reward_Image", typeof(string));
                dtImages.Columns.Add("Reward_Thumbnail", typeof(string));
                dtImages.Columns.Add("Active", typeof(int));
                dtImages.Columns.Add("Reward_ID", typeof(int));
                dtImages.Columns.Add("Current_Image", typeof(int));

            }

        }

        protected void btnCancelReward_Click(object sender, EventArgs e)
        {
            btnAddReward.Text = Resources.TestSiteResources.Add;
   
            txtRewardName.Text = "";
            txtRewardPoints.Text = "";
            ddlType.SelectedValue = "-1";
            cbActive.Checked = false;
        
            txtRewardDescp.Text = "";
            Response.Redirect("RewardManagement.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }
        #region add and update reward
        protected void btnAddReward_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationSettings.AppSettings["RewardsPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString());
            if (txtRewardName.Text.Equals(""))
            {
                return;
            }
            else
            {

                Reward reward = new Reward();
                reward.RewardName = txtRewardName.Text.Trim();
                reward.RewardPoints = Convert.ToInt32(txtRewardPoints.Text.Trim());
                reward.RewardDescp = txtRewardDescp.Text.Trim();
                if (ddlType.SelectedValue == "1")
                {
                    reward.RewardType = 1;
                }
                else
                {
                    reward.RewardType = 0;
                }

                if (btnAddReward.Text == "Update" || btnAddReward.Text == "mettre à jour" || btnAddReward.Text == "actualizar")
                {
                    RewardUpdateBLL UpdateReward = new RewardUpdateBLL();

                    reward.RewardID = Convert.ToInt32(Request.QueryString["rewardid"]);

                    if (cbActive.Checked)
                    {
                        reward.Active = 1;
                    }
                    else
                    {
                        reward.Active = 0;
                    }
                    int id = Convert.ToInt32(currentid);
                    reward.ID = id;

                    reward.CurrentImage = 1;


                    UpdateReward.Reward = reward;
                    try
                    {
                        UpdateReward.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.Reward + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Reward;
                    }
                    int previous = Convert.ToInt32(previousid);
                    reward.ID = previous;

                    reward.CurrentImage = 0;


                    UpdateReward.Reward = reward;
                    try
                    {
                        UpdateReward.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.Reward + ' ' + Resources.TestSiteResources.UpdateMessage;
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Reward;
                    }


                }
                else if (btnAddReward.Text == "Add" || btnAddReward.Text == "Ajouter" || btnAddReward.Text == "añadir")
                {
                    RewardInsertBLL insertReward = new RewardInsertBLL();
                    insertReward.Reward = reward;
                    lblmessage.Visible = true;
                    try
                    {
                        int RewardID = insertReward.Invoke();
                        RewardImageInsertBLL insertimage = new RewardImageInsertBLL();
                        if (dtImages != null && dtImages.Rows.Count > 0)
                        {
                            foreach (DataRow drow in dtImages.Rows)
                            {
                                reward.RewardID = RewardID;
                                reward.RewardImage = drow["Reward_Image"].ToString();
                                reward.RewardThumbnail = drow["Reward_Thumbnail"].ToString();
                                if (currentid == Convert.ToInt32(drow["ID"]))
                                {
                                    reward.CurrentImage = 1;
                                }
                                else
                                {
                                    reward.CurrentImage = 0;
                                }
                                insertimage.Reward = reward;
                                try
                                {
                                    insertimage.Invoke();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }

                        lblmessage.Text = Resources.TestSiteResources.Reward + ' ' + Resources.TestSiteResources.SavedMessage;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.Reward + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.Reward;
                        }
                    }
                }

                btnAddReward.Text = Resources.TestSiteResources.Add;
  
                txtRewardName.Text = "";
                txtRewardPoints.Text = "";
                txtRewardDescp.Text = "";
                ddlType.SelectedValue = "-1";
                cbActive.Checked = false;
              
                LoadData();
                Response.Redirect("RewardManagement.aspx");
            }

        }
        #endregion
        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RewardImageInsertBLL insertimage = new RewardImageInsertBLL();
            string path = Server.MapPath(ConfigurationSettings.AppSettings["RewardsPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString());

            Reward reward = new Reward();
            if (ViewState["rewardid"] != null && ViewState["rewardid"].ToString() != "" && Convert.ToInt32(ViewState["rewardid"]) != 0)
            {
                reward.RewardID = Convert.ToInt32(ViewState["rewardid"]);

                if (fileRewardImage.HasFile)
                {
                    string s = fileRewardImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fileRewardImage.FileName).ToLower();
                        fileRewardImage.SaveAs(path + GuidOne + FileExtension);
                        reward.RewardImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);
                        reward.RewardThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);
                        reward.CurrentImage = 0;

                        try
                        {
                            insertimage.Reward = reward;
                            insertimage.Invoke();

                          
                            LoadImagesData(Convert.ToInt32(Request.QueryString["rewardid"]));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            else
            {

                reward.RewardID = Convert.ToInt32(ViewState["rewardid"]);

                if (fileRewardImage.HasFile)
                {
                    string s = fileRewardImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fileRewardImage.FileName).ToLower();
                        fileRewardImage.SaveAs(path + GuidOne + FileExtension);
                        reward.RewardImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);
                        reward.RewardThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);


                        try
                        {
                            dtImages.Rows.Add(imageid, reward.RewardImage, reward.RewardThumbnail, 1, 1, 0);
                            imageid++;
                            dtImages.AcceptChanges();
                            LoadImagesData(0);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }

        }

        protected void LoadImagesData(int RewardID)
        {
            if (RewardID != 0)
            {
                string path = Server.MapPath(ConfigurationSettings.AppSettings["RewardsPath"].ToString());
                string Thumbpath = ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString();

                RewardImagesViewBLL rewardimage = new RewardImagesViewBLL();
                Reward _reward = new Reward();



                try
                {
                    rewardimage.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dvImage = rewardimage.ResultSet.Tables[0].DefaultView;

                DataTable dt = new DataTable();
                dt = dvImage.ToTable();


                dvImage.RowFilter = "Reward_ID=" + RewardID.ToString();

                dlImages.DataSource = dvImage.ToTable();
                dlImages.DataBind();

                dlImages.DataSource = dvImage.ToTable();
                dlImages.DataBind();

                DataView dvImage1 = rewardimage.ResultSet.Tables[0].DefaultView;
                dvImage1.RowFilter = "Current_Image=1 AND Reward_ID=" + RewardID.ToString();
                DataTable dtcImage = new DataTable();
                dtcImage = dvImage1.ToTable();
                if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Reward_Image"].ToString() != "")
                {
                    imgCurrentImage.ImageUrl = Thumbpath + dtcImage.Rows[0]["Reward_Image"].ToString();
                   
                }
            }
            else
            {

                if (dtImages != null && dtImages.Rows.Count > 0)
                {
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

        protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ViewImages")
            {

                string path = Server.MapPath(ConfigurationSettings.AppSettings["RewardsPath"].ToString());
                string Thumbpath = ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString();
                if (ViewState["rewardid"] != null && ViewState["rewardid"].ToString() != "" && Convert.ToInt32(ViewState["rewardid"]) != 0)
                {
                    RewardImagesViewBLL rewardimage = new RewardImagesViewBLL();
                    Reward _reward = new Reward();



                    try
                    {
                        rewardimage.Invoke();
                    }
                    catch (Exception ex)
                    {
                    }

                    DataView dvImage = rewardimage.ResultSet.Tables[0].DefaultView;


                    dvImage.RowFilter = "Current_Image=1 AND Reward_ID=" + Request.QueryString["rewardid"].ToString();

                    DataTable dtcImage = new DataTable();
                    dtcImage = dvImage.ToTable();

                    currentid = Convert.ToInt32(e.CommandArgument);

                    DataView dvImage1 = rewardimage.ResultSet.Tables[0].DefaultView;


                    dvImage.RowFilter = "Reward_ID=" + Request.QueryString["rewardid"].ToString() + " AND ID=" + currentid;


                    DataTable dtcImage1 = new DataTable();
                    dtcImage1 = dvImage1.ToTable();

                    if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["ID"].ToString() != "")
                    {
                        previousid = Convert.ToInt32(dtcImage.Rows[0]["ID"]);
                    }



                    if (currentid != 0)
                    {

                        imgCurrentImage.ImageUrl = Thumbpath + dtcImage1.Rows[0]["Reward_Thumbnail"];
                    }
                }
                else
                {
                    currentid = Convert.ToInt32(e.CommandArgument);
                    if (dtImages != null && dtImages.Rows.Count > 0)
                    {
                        DataView dvImage = dtImages.DefaultView;
                        dvImage.RowFilter = "ID = " + currentid.ToString();

                        imgCurrentImage.ImageUrl = Thumbpath + dvImage.ToTable().Rows[0]["Reward_Thumbnail"];
                        dvImage.RowFilter = "";
                        dtImages.AcceptChanges();
                    }
                }
            }

            else if (e.CommandName == "DeleteImage")
            {
                if (ViewState["rewardid"] != null && ViewState["rewardid"].ToString() != "" && Convert.ToInt32(ViewState["rewardid"]) != 0)
                {
                    int ID = Convert.ToInt32(e.CommandArgument);

                    RewardImageDeleteBLL deleteImage = new RewardImageDeleteBLL();
                    Reward reward = new Reward();

                    reward.ID = ID;

                    deleteImage.Reward = reward;

                    try
                    {
                        deleteImage.Invoke();
                        LoadImagesData(Convert.ToInt32(Request.QueryString["rewardid"]));
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    for (int i = 0; i < dtImages.Rows.Count; i++)
                    {
                        if (ID == Convert.ToInt32(dtImages.Rows[i]["ID"]) )
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