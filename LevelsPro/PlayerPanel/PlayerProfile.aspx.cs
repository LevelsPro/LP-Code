using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using LevelsPro.App_Code;
using BusinessLogic.Delete;
using System.Configuration;
using System.IO;
using LevelsPro.Util;

namespace LevelsPro.PlayerPanel
{
    public partial class PlayerProfile : AuthorizedPage
    {
        static int previousid = 0;
        static int currentid = 0;
        private static string pageURL;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;

            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                if (Session["MyCulture"] != null && Session["MyCulture"].ToString() != "")
                {
                    if (Session["MyCulture"].ToString() == "es-ES")
                    {
                        imgUpload.ImageUrl = "Images/upload-photo_spanish.png";
                        rblName.Items[0].Attributes.Add("style", "font-size:18px;");
                        rblName.Items[1].Attributes.Add("style", "font-size:18px;");
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
                try
                {
                    LoadData(Convert.ToInt32(Session["userid"]));
                }
                catch (Exception exp)
                {
                    throw exp;
                }

                //    done.Value = "1";
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData(int UserID)
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                ViewProfile.LoadData();
                lblName.Text = Session["displayname"].ToString() + " - "+Resources.TestSiteResources.EditProfileL;
                UserViewBLL User = new UserViewBLL();
                UserImageViewBLL UserImage = new UserImageViewBLL();


                Common.User _user = new User();

                _user.Where = "";

                User.User = _user;
                try
                {
                    User.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                DataView dv = User.ResultSet.Tables[0].DefaultView;

                dv.RowFilter = "UserID=" + UserID.ToString();

                DataTable dt = new DataTable();
                dt = dv.ToTable();
                lblmessage.Visible = false;

                txtFirstName.Text = dt.Rows[0]["U_FirstName"].ToString();

                txtLastName.Text = dt.Rows[0]["U_LastName"].ToString();
                txtNickName.Text = dt.Rows[0]["U_NickName"].ToString();
                if (dt.Rows[0]["Display_Name"].ToString() == "1")
                {
                    Session["displayname"] = dt.Rows[0]["U_FirstName"].ToString() + ' ' + dt.Rows[0]["U_LastName"].ToString();
                    rblName.Items[0].Selected = true;
                }
                else
                {
                    Session["displayname"] = dt.Rows[0]["U_NickName"].ToString();
                    rblName.Items[1].Selected = true;

                }

               
                Common.UserImage image = new Common.UserImage();

                image.UserID = Convert.ToInt32(Session["userid"]);

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

       

        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Equals(""))
            {
                return;
            }
            else
            {

                User user = new User();
                user.FirstName = txtFirstName.Text.Trim();
                user.UserLastName = txtLastName.Text.Trim();
                user.UserNickName = txtNickName.Text.Trim();
                if (rblName.Items[0].Selected == true)
                {
                    user.DisplayName = 1;

                }
                else
                {
                    if (!txtNickName.Text.Trim().Equals(""))
                    { 
                        user.DisplayName = 0;
                    }
                    else
                    {

                        user.DisplayName = 1;
                    }
                }

                lblmessage.Visible = true;
                UserEditUpdateBLL UpdateUser = new UserEditUpdateBLL();
                int UserID = 0;

                UserID = int.Parse(Session["userid"].ToString());

                user.UserID = UserID;

                UpdateUser.User = user;
                try
                {
                    UpdateUser.Invoke();
                 
                }
                catch (Exception ex)
                {
                    throw ex;
                }


               

                UserImageUpdateBLL UpdateImage = new UserImageUpdateBLL();
                UserImage _userimage = new UserImage();
                int id = Convert.ToInt32(currentid);
                _userimage.UserIDImage = id;

                _userimage.Current = 1;
                _userimage.Active = 1;


                UpdateImage.UserImage = _userimage;
                try
                {
                    UpdateImage.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                int previous = Convert.ToInt32(previousid);
                _userimage.UserIDImage = previous;

                _userimage.Current = 0;
                _userimage.Active = 1;


                UpdateImage.UserImage = _userimage;
                try
                {
                    UpdateImage.Invoke();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtNickName.Text = "";
                try
                {
                    LoadData(UserID);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Response.Redirect("PlayerHome.aspx");
            }
        }

        protected void dlImages_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (e.CommandName == "ViewImages")
            {                                
                UserImageViewBLL UserImages = new UserImageViewBLL();

                Common.UserImage image = new Common.UserImage();
                image.UserID = Convert.ToInt32(Session["userid"]);


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

                

                currentid = Convert.ToInt32(e.CommandArgument);

                DataView dvNewImage = UserImages.ResultSet.Tables[0].DefaultView;

                dvNewImage.RowFilter = "U_UserIDImage = " + currentid.ToString();

                DataTable dtNewImage = dvNewImage.ToTable();
               
                if (currentid != 0)
                {
                    imgCurrentImage.ImageUrl = Thumbpath + dtNewImage.Rows[0]["Player_Thumbnail"].ToString();
                }                
            }
            else if (e.CommandName == "DeleteImage")
            {
                int UserIDImage = Convert.ToInt32(e.CommandArgument);

                UserImageDeleteBLL deleteImage = new UserImageDeleteBLL();
                UserImage userImage = new UserImage();

                userImage.UserIDImage = UserIDImage;

                deleteImage.User = userImage;

                try
                {
                    deleteImage.Invoke();
                    LoadData(Convert.ToInt32(Session["userid"]));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            LoginUpdateBLL loginuser = new LoginUpdateBLL();
            User user = new User();
            user.UserID = Convert.ToInt32(Session["userid"]);
            loginuser.Users = user;
            try
            {
                loginuser.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(ConfigurationManager.AppSettings["PlayersPath"].ToString());
            string Thumbpath = Server.MapPath(ConfigurationManager.AppSettings["PlayersThumbPath"].ToString());

            if (Session["userid"] != null && Session["userid"].ToString() != "")
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

                        images.UserID = Convert.ToInt32(Session["userid"]);
                        UserImageInsertBLL updateimage = new UserImageInsertBLL();
                        try
                        {
                            updateimage.UserImage = images;
                            updateimage.Invoke();

                            LoadData(Convert.ToInt32(Session["userid"]));
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

        protected void rblName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNickName.Text.Trim().Equals(""))
            {
                rblName.Items[1].Selected = false;
                rblName.Items[0].Selected = true;
            }
        }

    }
}