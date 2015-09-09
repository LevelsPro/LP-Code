using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLogic.Update;
using System.Data;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using BusinessLogic.Select;
using BusinessLogic.Delete;
using System.Configuration;
using System.IO;
using LevelsPro.Util;
using log4net;

namespace LevelsPro
{
    public partial class EditPlayer : AuthorizedPage
    {
        public static DataSet dsPlayer = new DataSet();
        static int currentlevel = 0;
        static int previouslevel = 1;
        static int previousid = 0;
        static int currentid = 0;
        private static string pageURL;
        private ILog log;
        protected string TypedPassword
        {
            get
            {
                if (ViewState["TypedPassword"] != null)
                {
                    return Convert.ToString(ViewState["TypedPassword"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedPassword"] = value;
            }
        }
        protected string TypedCPassword
        {
            get
            {
                if (ViewState["TypedCPassword"] != null)
                {
                    return Convert.ToString(ViewState["TypedCPassword"]);
                }
                return null;
            }
            set
            {
                ViewState["TypedCPassword"] = value;
            }
        }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Control c = GetPostBackControl(this.Page);
            if (c != null)
            {
                if (c.ID == "ddlRole" || c.ID == "ddlLevel")
                {
                    if (txtPassword.Text.Trim().Length > 0 && txtPassword.Text != "")
                    {
                        TypedPassword = txtPassword.Text;
                        txtPassword.Attributes.Add("value", TypedPassword);
                    }
                    if (txtConfirmPassword.Text.Trim().Length > 0 && txtConfirmPassword.Text != "")
                    {
                        TypedCPassword = txtConfirmPassword.Text;
                        txtConfirmPassword.Attributes.Add("value", TypedCPassword);
                    }
                }
            }
            lblmessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!IsPostBack)
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
                try
                {
                    LoadRoles();
                    LoadGeneralRoles();

                    LoadSites();
                    LoadManagers();
                    LoadLevel(0);
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                txtPoints.Enabled = false;
                txtPoints.Text = "0";

               

                if (Request.QueryString["userid"] != null && Request.QueryString["userid"].ToString() != "")
                {
                    divImages.Visible = true;
                    HoursRow.Visible = true;
                    txtWorkedHours.Visible = true;
                    ltHeading.Text =Resources.TestSiteResources.EditPlayer;
                    ViewState["userid"] = Request.QueryString["userid"];
                    try
                    {
                        LoadData(Convert.ToInt32(ViewState["userid"]));
                    }
                    catch (Exception exp)
                    {
                        throw exp;
                    }
                }
                else
                {
                    divImages.Visible = false;
                    txtWorkedHours.Text = "0";
                    HoursRow.Visible = false;
                    txtWorkedHours.Visible = false;
                    ltHeading.Text = Resources.TestSiteResources.AddPlayer;
                }
            }
            ExceptionUtility.CheckForErrorMessage(Session);
        }
        #region insert and update user information
        protected void btnInsertInfo_Click(object sender, EventArgs e)
        {
            string strActive = "";
            if (btnInsertInfo.Text != "Mass Update" && txtFirstName.Text.Equals(""))
            {
               
                return;
            }
            else
            {


                User user = new User();

                user.EmployeeID = txtEmpID.Text.Trim();
                user.UserName = txtUserName.Text.Trim();
                user.FirstName = txtFirstName.Text.Trim();
                user.UserLastName = txtLastName.Text.Trim();
                user.UserNickName = txtNickName.Text.Trim();
                user.UserPassword = txtPassword.Text.Trim();
                user.UserEmail = txtEmail.Text.Trim();
                user.Hours = Convert.ToInt32(txtWorkedHours.Text.Trim());
                user.Score = Convert.ToInt32(txtPoints.Text.Trim());
                
               bool isAdmin =  Convert.ToInt32(ddlRole.SelectedValue)==1 &&  Convert.ToInt32(ddlGeneralRole.SelectedValue)==6; 
               
                if (currentlevel > 0)
                {
                    user.CurrentLevel = currentlevel;
                    user.LastLevel = 0;
                    user.NextLevel = currentlevel + 1;
                }
                user.LevelAchieved = 0;


              
                if (ddlSite.SelectedIndex > 0)
                {
                    user.SiteID = Convert.ToInt32(ddlSite.SelectedValue);
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.SiteRequired;
                    return;
                }
                if (ddlGeneralRole.SelectedIndex > 0)
                {
                    user.UserRoles = ddlGeneralRole.SelectedItem.Text;
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.ApplicationRequired;
                    return;
                }
                if (ddlRole.SelectedIndex > 0)
                {
                    user.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.RoleRequired;
                    return;
                }
                if (ddlManager.SelectedIndex > 0 || ddlGeneralRole.SelectedItem.Text.Equals("Manager"))
                {
                    if (ddlManager.SelectedIndex > 0)
                    {
                        user.ManagerID = Convert.ToInt32(ddlManager.SelectedValue);
                    }
                    else 
                    {
                        user.ManagerID = 0;
                    }
                }
                else
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = Resources.TestSiteResources.ManagerRequired;
                    return;
                }
                if (ddlLevel.SelectedIndex > 0)
                {

                }
                else
                {   
                    //If is not an admin return the error message
                   if(!isAdmin) {
                        lblmessage.Visible = true;
                        lblmessage.Text = Resources.TestSiteResources.LevelRequired;
                        return;                       
                   }

                }

                

                if (btnInsertInfo.Text == "Mass Update" || btnInsertInfo.Text == "Mise à jour de masse" || btnInsertInfo.Text == "masa actualizar")
                {

                    if (cbActive.Checked)
                    {

                        user.Active = 1;

                    }
                    else
                    {
                        user.Active = 0;
                    }
                    user.CurrentLevel = currentlevel;
                    user.NextLevel = currentlevel + 1;

                    

                }
                else if (btnInsertInfo.Text == "Update" || btnInsertInfo.Text == "mettre à jour" || btnInsertInfo.Text == "actualizar")
                {
                    if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
                    {
                        UserUpdateAdminBLL updateuser = new UserUpdateAdminBLL();
                        user.EmployeeID = txtEmpID.Text.Trim();
                        user.UserID = Convert.ToInt32(ViewState["userid"]);

                        if (cbActive.Checked)
                        {

                            user.Active = 1;
                            strActive = "True";
                        }
                        else
                        {
                            user.Active = 0;
                            strActive = "False";
                        }

                        if (dsPlayer != null && dsPlayer.Tables.Count > 0 && dsPlayer.Tables[0] != null && dsPlayer.Tables[0].Rows.Count > 0)
                        {
                            DataView dv = dsPlayer.Tables[0].DefaultView;

                            dv.RowFilter = "UserID=" + ViewState["userid"].ToString();


                            DataTable dt = new DataTable();
                            dt = dv.ToTable();


                            if (dt.Rows[0]["Active"].ToString() != strActive)
                            {

                                user.ActiveUpdateStatus = 1;
                            }

                        }
                        if (previouslevel == Convert.ToInt32(ddlLevel.SelectedValue))
                        {
                            user.LastLevel = 0;
                            user.NextLevel = 0;
                            user.CurrentLevel = currentlevel;
                            user.PreviousLevel = previouslevel;
                            user.ActiveUpdateStatus = 1;
                            updateuser.User = user;
                        }
                        else
                        {
                            user.CurrentLevel = currentlevel;
                            user.LastLevel = previouslevel;
                            user.NextLevel = currentlevel + 1;
                            user.ActiveUpdateStatus = 0;
                            user.PreviousLevel = previouslevel;

                            updateuser.User = user;
                        }
                        try
                        {
                            updateuser.Invoke();

                            UserImageUpdateBLL UpdateImage = new UserImageUpdateBLL();
                            UserImage _userimage = new UserImage();
                            int id = Convert.ToInt32(currentid);
                            _userimage.UserIDImage = id;

                            _userimage.Current = 1;
                            _userimage.Active = 1;


                            UpdateImage.UserImage = _userimage;
                            
                            UpdateImage.Invoke();
                            
                            int previous = Convert.ToInt32(previousid);
                            _userimage.UserIDImage = previous;

                            _userimage.Current = 0;
                            _userimage.Active = 1;


                            UpdateImage.UserImage = _userimage;
                            
                            UpdateImage.Invoke();
                            



                            lblmessage.Visible = true;
                            lblmessage.Text = Resources.TestSiteResources.Player + ' ' + Resources.TestSiteResources.UpdateMessage;
                            
                            LoadData(Convert.ToInt32(ViewState["userid"]));
                            
                        }
                        catch (Exception ex)
                        {
                            ExceptionUtility.ExceptionLogString(ex, Session);
                            Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                            log.Debug(Session["ExpLogString"]);
                            lblmessage.Visible = true;
                            lblmessage.Text = Resources.TestSiteResources.NotUpdate + ' ' + Resources.TestSiteResources.Player;
                        }
                    }
                }
                else
                {
                  
                    UserInsertBLL insertuser = new UserInsertBLL();

                    user.Active = 1;

                    insertuser.User = user;

                    try
                    {
                        
                        insertuser.Invoke();
                        Response.Redirect("PlayerManagement.aspx?saved=1",false);

                        

                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        lblmessage.Visible = true;
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.Player + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.Player;
                        }
                    }
                }

                
            }
        }
        #endregion

        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            // Void Page_Load(System.Object, System.EventArgs)
            // Handle specific exception.
            if (exc is HttpUnhandledException || exc.TargetSite.Name.ToLower().Contains("page_load"))
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void btnCancelInfo_Click(object sender, EventArgs e)
        {

            

        }
        #region load user data
        protected void LoadData(int UserID)
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (UserID > 0)
            {
                UserViewBLL player = new UserViewBLL();
                Common.User _user = new User();

                _user.Where = " WHERE tblUser.UserID = " + UserID.ToString();

                player.User = _user;
                try
                {
                    player.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                dsPlayer = player.ResultSet;
                DataView dvPlayer = player.ResultSet.Tables[0].DefaultView;
                if (dvPlayer != null && dvPlayer.ToTable().Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt = dvPlayer.ToTable();
                    txtEmpID.Text = dt.Rows[0]["U_EmpID"].ToString();
                    txtUserName.Text = dt.Rows[0]["U_Name"].ToString();
                    txtFirstName.Text = dt.Rows[0]["U_FirstName"].ToString();
                    txtLastName.Text = dt.Rows[0]["U_LastName"].ToString();
                    txtNickName.Text = dt.Rows[0]["U_NickName"].ToString();
                    txtWorkedHours.Text = dt.Rows[0]["WorkedHour"].ToString();

                    txtEmail.Text = dt.Rows[0]["U_Email"].ToString();
                    if (dt.Rows[0]["U_SiteID"].ToString() != "")
                        ddlSite.SelectedValue = dt.Rows[0]["U_SiteID"].ToString();
                    if (dt.Rows[0]["U_SysRole"].ToString() != "" && dt.Rows[0]["U_SysRole"].ToString() == "Player")
                    {
                        ddlGeneralRole.SelectedIndex = 3;
                    }
                    else if (dt.Rows[0]["U_SysRole"].ToString() != "" && dt.Rows[0]["U_SysRole"].ToString() == "Manager")
                    {
                        ddlGeneralRole.SelectedIndex = 2;
                    }
                    else if (dt.Rows[0]["U_SysRole"].ToString() != "" && dt.Rows[0]["U_SysRole"].ToString() == "Admin")
                    {
                        ddlGeneralRole.SelectedIndex = 1;
                    }

                    if (dt.Rows[0]["U_RolesID"].ToString() != "")
                        ddlRole.SelectedValue = dt.Rows[0]["U_RolesID"].ToString();

                    if (dt.Rows[0]["ManagerID"].ToString() != "")
                        ddlManager.SelectedValue = dt.Rows[0]["ManagerID"].ToString();

                    if (dt.Rows[0]["Active"].ToString() == "1")
                    {
                        cbActive.Checked = true;
                    }
                    else
                    {
                        cbActive.Checked = false;
                    }
                    ddlRole_SelectedIndexChanged(null, null);
                    if (dt.Rows[0]["LevelID"].ToString() != "")
                        ddlLevel.SelectedValue = dt.Rows[0]["LevelID"].ToString();


                    previouslevel = Convert.ToInt32(ddlLevel.SelectedValue);
                    currentlevel = 0;
                    
                    

                    btnInsertInfo.Text = Resources.TestSiteResources.Update;
                    PointsRow.Visible = true;
                    txtPoints.Text = dt.Rows[0]["U_Points"].ToString(); ;
                    txtPoints.Enabled = true;
                    divPassword.Visible = false;
                    divCPassword.Visible = false;
                    divUserName.Visible = false;
                    if (ddlLevel.SelectedIndex > 0)
                    {
                        Session["LevelCheck"] = ddlLevel.SelectedValue.ToString();
                    }
                    UserImageViewBLL UserImage = new UserImageViewBLL();
                    Common.UserImage image = new Common.UserImage();

                    image.UserID = UserID;

                    UserImage.UserImages = image;

                    try
                    {
                        UserImage.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    DataView dvImage = UserImage.ResultSet.Tables[0].DefaultView;

                    

                    dlImages.DataSource = dvImage.ToTable();
                    dlImages.DataBind();

                    DataView dvImage1 = UserImage.ResultSet.Tables[0].DefaultView;
                    dvImage1.RowFilter = "U_Current=1";
                    DataTable dtcImage = new DataTable();
                    dtcImage = dvImage1.ToTable();
                    if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                    {
                        imgCurrentImage.ImageUrl = Thumbpath + dtcImage.Rows[0]["Player_Thumbnail"].ToString();
                        currentid = Convert.ToInt32(dtcImage.Rows[0]["U_UserIDImage"]);
                    }

                }
            }
           
        }
        #endregion
        protected void LoadRoles()
        {
            RolesViewBLL role = new RolesViewBLL();
            try
            {
                role.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void LoadGeneralRoles()
        {
            DropdownViewBLL dropdown = new DropdownViewBLL();
            Dropdown _dropdown = new Dropdown();
            _dropdown.ReferenceCode = "ROLE_TYPE";
            dropdown.Dropdown = _dropdown;

            try
            {
                dropdown.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            

            ddlGeneralRole.DataTextField = "Description";
            ddlGeneralRole.DataValueField = "ReferenceData_ID";

            ddlGeneralRole.DataSource = dropdown.ResultSet;
            ddlGeneralRole.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlGeneralRole.Items.Insert(0, li);

            
        }

        protected void LoadLevel(int RoleID)
        {
            LevelsViewBLL level = new LevelsViewBLL();
            Roles role = new Roles();
            role.RoleID = RoleID;
            level.Role = role;

            try
            {
                level.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            DataView dv = level.ResultSet.Tables[0].DefaultView;
            dv.RowFilter = "Role_ID=" + RoleID + " AND Active=1";

            ddlLevel.DataTextField = "LevelName";
            ddlLevel.DataValueField = "Level_ID";

            

            ddlLevel.DataSource = dv.ToTable();
            ddlLevel.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlLevel.Items.Insert(0, li);
        }

        private void LoadManagers()
        {
            ManagerDropDownBLL selectddlSite = new ManagerDropDownBLL();
            try
            {
                selectddlSite.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ddlManager.DataTextField = "U_Name";
            ddlManager.DataValueField = "UserID";

            

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlManager.DataSource = dv.ToTable();
            ddlManager.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlManager.Items.Insert(0, li);

            

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
                throw ex;
            }

            ddlSite.DataTextField = "site_name";
            ddlSite.DataValueField = "site_id";

            

            DataView dv = selectddlSite.ResultSet.Tables[0].DefaultView;

            ddlSite.DataSource = dv.ToTable();
            ddlSite.DataBind();

            ListItem li = new ListItem("Select", "0");
            ddlSite.Items.Insert(0, li);

            
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedIndex > 0)
            {
                try
                {
                    LoadLevel(Convert.ToInt32(ddlRole.SelectedValue));
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLevel.SelectedIndex > 0)
            {
                
                Session["LevelCheck"] = ddlLevel.SelectedValue.ToString();
                
                currentlevel = Convert.ToInt32(ddlLevel.SelectedValue);

            }
        }

        #region show user all images and delete functionality of image
        protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();

            if (e.CommandName == "ViewImages")
            {
                if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
                {
                    string strIds = e.CommandArgument.ToString();
                    string[] strArray = strIds.Split('|');
                    UserImageViewBLL UserImages = new UserImageViewBLL();

                    Common.UserImage image = new Common.UserImage();

                    image.UserID = Convert.ToInt32(strArray[1]);


                    UserImages.UserImages = image;

                    try
                    {
                        UserImages.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }                   

                    DataView dvImage1 = UserImages.ResultSet.Tables[0].DefaultView;

                    dvImage1.RowFilter = "U_Current=1";
                    DataTable dtcImage = new DataTable();
                    dtcImage = dvImage1.ToTable();

                    if (dtcImage != null && dtcImage.Rows.Count > 0 && dtcImage.Rows[0]["Player_Thumbnail"].ToString() != "")
                    {
                        previousid = Convert.ToInt32(dtcImage.Rows[0]["U_UserIDImage"]);                                   
                    }

                    currentid = Convert.ToInt32(strArray[0]);

                    DataView dvNewImage = UserImages.ResultSet.Tables[0].DefaultView;

                    dvNewImage.RowFilter = "U_UserIDImage = " + currentid.ToString();

                    DataTable dtNewImage = dvNewImage.ToTable();

                    if (currentid != 0)
                    {
                        imgCurrentImage.ImageUrl = Thumbpath + dtNewImage.Rows[0]["Player_Thumbnail"].ToString();
                    }
                }
            }
            else if (e.CommandName == "DeleteImage")
            {
                if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
                {
                    int UserIDImage = Convert.ToInt32(e.CommandArgument);

                    UserImageDeleteBLL deleteImage = new UserImageDeleteBLL();
                    UserImage userImage = new UserImage();

                    userImage.UserIDImage = UserIDImage;

                    deleteImage.User = userImage;

                    try
                    {
                        deleteImage.Invoke();
                        LoadData(Convert.ToInt32(ViewState["userid"]));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        #endregion
        public static Control GetPostBackControl(Page page)
        {
            Control control = null;

            string ctrlname = page.Request.Params.Get("__EVENTTARGET");
            if (ctrlname != null && ctrlname != string.Empty)
            {
                control = page.FindControl(ctrlname);
            }
            else
            {
                foreach (string ctl in page.Request.Form)
                {
                    Control c = page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)
                    {
                        control = c;
                        break;
                    }
                }
            }
            return control;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PlayerManagement.aspx");
        }

        [System.Web.Services.WebMethod]
        public static void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void btnAwards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerAward.aspx?userid=" + ViewState["userid"].ToString(),false);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["PlayersPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationManager.AppSettings["PlayersThumbPath"].ToString());

            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                UserImage images = new UserImage();
                if (fileUserImage.HasFile)
                {

                    string s = fileUserImage.FileName;
                    FileInfo fleInfo = new FileInfo(s);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        string GuidOne = Guid.NewGuid().ToString();
                        string FileExtension = Path.GetExtension(fileUserImage.FileName).ToLower();
                        fileUserImage.SaveAs(path + GuidOne + FileExtension);
                        images.PlayerImage = string.Format("{0}{1}", GuidOne, FileExtension);

                        System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
                        System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                        thumbImage.Save(Thumbpath + GuidOne + FileExtension);
                        images.PlayerThumbnail = string.Format("{0}{1}", GuidOne, FileExtension);

                        images.UserID = Convert.ToInt32(ViewState["userid"]);
                        UserImageInsertBLL updateimage = new UserImageInsertBLL();
                        try
                        {
                            updateimage.UserImage = images;
                            updateimage.Invoke();

                            LoadData(Convert.ToInt32(ViewState["userid"]));
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }                    
                }
            }
        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }

        protected void btnProgress_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "" && ddlLevel.SelectedIndex > 0)
            {
                Response.Redirect("PlayerProgress.aspx?userid=" + ViewState["userid"].ToString() + "&levelid=" + ddlLevel.SelectedValue, false);
            }
        }

        protected void btnRewards_Click(object sender, EventArgs e)
        {
            if (ViewState["userid"] != null && ViewState["userid"].ToString() != "")
            {
                Response.Redirect("PlayerRewards.aspx?userid=" + ViewState["userid"].ToString(), false);
            }
        }
    }
}