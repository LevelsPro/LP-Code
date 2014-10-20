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
using LevelsPro.App_Code;
using LevelsPro.Util;
using log4net;

namespace LevelsPro.AdminPanel
{
    public partial class RoleEdit :  AuthorizedPage
    {
        private static string pageURL;
        private ILog log;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        int count = 0;
        static String checks = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Visible = false;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            if (!(Page.IsPostBack))
            {
                System.Uri url = Request.Url;
                pageURL = url.AbsolutePath.ToString();
                try
                {
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
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.Remote, Session, Server, Response,log, exc);
            }
            else
            {
                ExceptionUtility.GenerateExpResponse(pageURL, RedirectionStrategy.local, Session, Server, Response,log, exc);
            }
            // Clear the error from the server.
            Server.ClearError();
        }

        protected void LoadData()
        {
            string path =ConfigurationSettings.AppSettings["RolePath"].ToString();
            string Thumbpath = ConfigurationSettings.AppSettings["RoleThumbPath"].ToString();
            if (Request.QueryString["roleid"] != null && Request.QueryString["roleid"].ToString() != "")
            {
                ViewState["roleid"] = Request.QueryString["roleid"];
                int id = Convert.ToInt32(Request.QueryString["roleid"]);


                if (id != 0)
                {
                  
                    lblActive.Visible = true;
                    cbActive.Visible = true;
                    lblHeading.Text = Resources.TestSiteResources.EditRole;
                    RolesViewBLL role = new RolesViewBLL();
                    try
                    {
                        role.Invoke();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    DataView dv = role.ResultSet.Tables[0].DefaultView;

                    dv.RowFilter = "Role_ID=" + id.ToString();

                    DataTable dt = new DataTable();
                    dt = dv.ToTable();
                    lblmessage.Visible = false;

                    txtRoleName.Text = dt.Rows[0]["Role_Name"].ToString();
                    //if (dt.Rows[0]["ImageName"].ToString() != null && dt.Rows.Count >0 && dt.Rows[0]["ImageName"].ToString() != "")
                    //{
                    //    string imagepath = dt.Rows[0]["ImageName"].ToString();


                    //    hplView.Visible = true;
                    //    rfvGraphic.ValidationGroup = "update";
                    //    hplView.NavigateUrl = path + imagepath;
                    //}
                    if (dt.Rows[0]["Active"].ToString() == "1")
                    {
                        cbActive.Checked = true;
                    }
                    else
                    {
                        cbActive.Checked = false;
                    }
                    lblmessage.Visible = false;

                    btnAddRole.Text = Resources.TestSiteResources.Update;
                }
                else
                {
                    lblHeading.Text = Resources.TestSiteResources.AddRole;
                    lblActive.Enabled = false;
                    cbActive.Enabled = false;

                }
            }
        }
        #region add and update role
        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            string Thumbpath = ConfigurationSettings.AppSettings["RoleThumbPath"].ToString();
            string path = ConfigurationSettings.AppSettings["RolePath"].ToString();
            if (txtRoleName.Text.Equals(""))
            {
                
                return;
            }
            else
            {
                Roles role = new Roles();
                role.RoleName = txtRoleName.Text.Trim();
                

                //String imageID = SaveImageInFolder();
                //if (imageID != "")
                //{

                //    role.ImageName = imageID;
                    
                //}
                //else
                //{
                //    RolesViewBLL roles = new RolesViewBLL();
                //    try
                //    {
                //        roles.Invoke();
                //    }
                //    catch (Exception ex)
                //    {
                //    }

                //    DataView dv = roles.ResultSet.Tables[0].DefaultView;
                //    dv.RowFilter = "Role_ID=" + Convert.ToInt32(Request.QueryString["roleid"]);
                //    DataTable dt = dv.ToTable();

                //    role.ImageName = dt.Rows[0]["ImageName"].ToString();
                   

                //}


                if (btnAddRole.Text == "Update" || btnAddRole.Text == "mettre à jour" || btnAddRole.Text == "actualizar")
                {
                    RolesUpdateBLL UpdateRole = new RolesUpdateBLL();
                    role.RoleID = Convert.ToInt32(Request.QueryString["roleid"]);
                    if (cbActive.Checked)
                    {
                        role.Active = 1;
                    }
                    else
                    {
                        role.Active = 0;
                    }
                    if (checks == Convert.ToString(role.Active))
                    {

                        role.ActiveStatus = 0;
                    }
                    else
                    {
                        role.ActiveStatus = 1;
                    }
                    UpdateRole.Roles = role;
                    lblmessage.Visible = true;
                    try
                    {
                        UpdateRole.Invoke();
                        lblmessage.Text = Resources.TestSiteResources.RoleH + ' ' + Resources.TestSiteResources.UpdateMessage;
                        
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        lblmessage.Text = ex.Message;//Constants._RoleNotUpdated;
                        
                    }
                }
                else if (btnAddRole.Text == "Add" || btnAddRole.Text == "Ajouter" || btnAddRole.Text == "añadir")
                {
                    
                    RolesInsertBLL insertRole = new RolesInsertBLL();
                    insertRole.Roles = role;
                    lblmessage.Visible = true;
                    try
                    {
                        insertRole.Invoke();
                        Response.Redirect("RoleManagement.aspx",false);
                        lblmessage.Text = Resources.TestSiteResources.RoleH + ' ' + Resources.TestSiteResources.SavedMessage;
                       
                    }
                    catch (Exception ex)
                    {
                        ExceptionUtility.ExceptionLogString(ex, Session);
                        Session["ExpLogString"] += " Aditional Info : Message Box displayed";
                        log.Debug(Session["ExpLogString"]);
                        if (ex.Message.Contains("Duplicate"))
                        {
                            lblmessage.Text = Resources.TestSiteResources.RoleH + ' ' + Resources.TestSiteResources.Already;
                        }
                        else
                        {
                            lblmessage.Text = Resources.TestSiteResources.NotAdd + ' ' + Resources.TestSiteResources.RoleH;
                        }
                       
                    }
                   
                }

                btnAddRole.Text = Resources.TestSiteResources.Add;
                txtRoleName.Text = "";
                cbActive.Checked = false;
              //  rfvGraphic.ValidationGroup = "Insertion";
                //hplView.Visible = false;
                try
                {
                    LoadData();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
                
            }
        }
        #endregion
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddRole.Text = Resources.TestSiteResources.Add;
            txtRoleName.Text = "";
            cbActive.Checked = false;
           // hplView.Visible = false;
            //rfvGraphic.ValidationGroup = "Insertion";

            Response.Redirect("RoleManagement.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Index.aspx");
        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };
            if (strArr.Contains(extension))
                return true;
            return false;
        }
        //public String SaveImageInFolder()
        //{
        //    string path = Server.MapPath(ConfigurationSettings.AppSettings["RolePath"].ToString());
        //    string Thumbpath = Server.MapPath(ConfigurationSettings.AppSettings["RoleThumbPath"].ToString());
        //    if (fileQuizImage.HasFile)
        //    {
        //        string s = fileQuizImage.FileName;
        //        FileInfo fleInfo = new FileInfo(s);
        //        if (AllowedFile(fleInfo.Extension))
        //        {
        //            string GuidOne = Guid.NewGuid().ToString();
        //            string FileExtension = Path.GetExtension(fileQuizImage.FileName).ToLower();
        //            fileQuizImage.SaveAs(path + GuidOne + FileExtension);
        //            string ipath =string.Format("{0}{1}", GuidOne, FileExtension);

        //            System.Drawing.Image img = System.Drawing.Image.FromFile(path + GuidOne + FileExtension);
        //            System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
        //            thumbImage.Save(Thumbpath + GuidOne + FileExtension);
                   
        //            return ipath;
        //        }
        //        else
        //            return "";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
       
    }
}