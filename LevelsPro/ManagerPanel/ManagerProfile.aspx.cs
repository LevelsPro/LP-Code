using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LevelsPro.App_Code;
using Common;
using BusinessLogic.Update;
using BusinessLogic.Select;
using System.Data;
using BusinessLogic.Insert;
using BusinessLogic.Delete;
using System.Configuration;
using System.IO;

namespace LevelsPro.ManagerPanel
{
    public partial class ManagerProfile : AuthorizedPage
    {
        static int previousid = 0;
        static int currentid = 0;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;

            if (!(Page.IsPostBack))
            {
                //    #region Authentication Code
                //    try
                //    {
                //        usr = (string)Session["username"];
                //        pwd = (string)Session["password"];
                //        loc = (string)Session["location"];
                //        if ((usr == null) || (pwd == null))
                //        {
                //            Response.Redirect("~/Login.aspx");
                //        }
                //        else
                //        {
                //            AccountRoles ar = new AccountRoles();
                //            if (!(ar.Authorization(Roles(usr, pwd, loc), usr, pwd, loc)))
                //            {
                //                ClientScript.RegisterStartupScript(typeof(Page), "warning", "<script>alert('Invalid UserName/Password')</script>");
                //            }
                //            else
                //            {
                //                string str = (string)Session["role"];
                //                if (!(str.Equals("sadmin")))
                //                {
                //                    Response.Redirect("~/Login.aspx");
                //                }
                //                else
                //                {
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        ClientScript.RegisterClientScriptBlock(typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>");
                //    }
                //    #endregion
                //LoadRoles();

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

                LoadData(Convert.ToInt32(Session["userid"]));


                //    done.Value = "1";
            }
        }
        protected void LoadData(int UserID)
        {
            string Thumbpath = ConfigurationManager.AppSettings["PlayersThumbPath"].ToString();
            if (Session["userid"] != null && Session["userid"].ToString() != "")
            {
                ViewProfile.LoadData();
                lblName.Text = Session["displayname"].ToString() + " - Edit Profile";
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

                //txtFbID.Text = dt.Rows[0]["U_FbUserID"].ToString();
                //txtFbPassword.Text = dt.Rows[0]["U_FbPassword"].ToString();
                //txtTwID.Text = dt.Rows[0]["U_TwUserID"].ToString();
                //txtTwPassword.Text = dt.Rows[0]["U_TwPassword"].ToString();
                Common.UserImage image = new Common.UserImage();

                image.UserID = Convert.ToInt32(Session["userid"]);

                UserImage.UserImages = image;

                try
                {
                    UserImage.Invoke();
                }
                catch (Exception ex)
                {
                }

                DataView dvImage = UserImage.ResultSet.Tables[0].DefaultView;

                //dvImage.RowFilter = "Active=1 AND UserID=" + Convert.ToInt32(Session["userid"]);

                // DataTable dtImage = new DataTable();
                // dtImage = dvImage.ToTable();
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

                //btnUpdat.Text = "Update";
                //gvInfo.DataSource = User.ResultSet;
                //gvInfo.DataBind();
            }
        }

        //protected void LoadRoles()
        //{
        //    RolesViewBLL role = new RolesViewBLL();
        //    try
        //    {
        //        role.Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    ddlRole.DataTextField = "Role_Name";
        //    ddlRole.DataValueField = "Role_ID";

        //    DataView dv = role.ResultSet.Tables[0].DefaultView;

        //    dv.RowFilter = "Active=1";

        //    ddlRole.DataSource = dv.ToTable();
        //    ddlRole.DataBind();

        //    ListItem li = new ListItem("Select", "0");
        //    ddlRole.Items.Insert(0, li);
        //}

        /*  protected void gvInfo_SelectedIndexChanged(object sender, EventArgs e)
          {
              //if (gvInfo.SelectedIndex != -1)
              //{
              //    lblmessage.Visible = false;
              //    //ImageButton gvLevelRow = (ImageButton)sender;
              //    //GridViewRow row = (GridViewRow)gvLevelRow.NamingContainer;
              //    Label lblRoleID = (Label)gvInfo.SelectedRow.FindControl("lblRoleID");
              //    Label lblActive = (Label)gvInfo.SelectedRow.FindControl("lblActive");
              //    txtFirstName.Text = "";
              //    txtFirstName.Text = gvInfo.SelectedRow.Cells[4].Text.Trim();
              //    ddlRole.SelectedValue = lblRoleID.Text.Trim();
              //    txtLastName.Text = gvInfo.SelectedRow.Cells[5].Text.Trim();
              //    txtNickName.Text = gvInfo.SelectedRow.Cells[6].Text.Trim();
              //    txtLocation.Text = gvInfo.SelectedRow.Cells[8].Text.Trim();
              //    txtFbID.Text = gvInfo.SelectedRow.Cells[9].Text.Trim();
              //    txtFbPassword.Text = gvInfo.SelectedRow.Cells[10].Text.Trim();
              //    txtTwID.Text = gvInfo.SelectedRow.Cells[11].Text.Trim();
              //    txtTwPassword.Text = gvInfo.SelectedRow.Cells[12].Text.Trim();



              //    if (lblActive.Text.Trim() == "1")
              //    {
              //        cbActive.Checked = true;
              //    }
              //    else
              //    {
              //        cbActive.Checked = false;
              //    }
              //    trActive.Visible = true;
              //    //btnUpdat.Text = "Update";
              //}

          }*/

        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Equals(""))
            {
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Provide country to add')</script>", false);
                return;
            }
            else
            {

                User user = new User();
                user.FirstName = txtFirstName.Text.Trim();
                // user.RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                user.UserLastName = txtLastName.Text.Trim();
                user.UserNickName = txtNickName.Text.Trim();
                if (rblName.Items[0].Selected == true)
                {
                    user.DisplayName = 1;

                }
                else
                {
                    user.DisplayName = 0;
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
                    //lblmessage.Text = Constants._TargetUpdated;//"Level has been updated successfully";
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('Updation successfully performed')</script>", false);
                }
                catch (Exception ex)
                {
                    // lblmessage.Text = Constants._TargetNotUpdated;
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Warning", "<script>alert('" + ex.Message + "')</script>", false);
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
                }

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtNickName.Text = "";

                LoadData(UserID);
                Response.Redirect("TeamPerformance.aspx");
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

                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
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
    }
}