using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using LevelsPro.Util;

namespace LevelsPro.AdminPanel
{
    public partial class BannerConfiguration : System.Web.UI.Page
    {
        private static string pageURL;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Uri url = Request.Url;
            pageURL = url.AbsolutePath.ToString();
            ExceptionUtility.CheckForErrorMessage(Session);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        protected bool AllowedFile(string extension)
        {
            string[] strArr = {".png"};
            if (strArr.Contains(extension))
                return true;
            return false;
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

        protected void btnAddQuiz_Click(object sender, EventArgs e)
        {
            try
            {
                string MainPath = Server.MapPath(ConfigurationManager.AppSettings["MainImagePath"].ToString());
                string PlayerPath = Server.MapPath(ConfigurationManager.AppSettings["PlayerPanelImagePath"].ToString());
                string AdminPath = Server.MapPath(ConfigurationManager.AppSettings["AdminPanelImagePath"].ToString());
                string ManagerPath = Server.MapPath(ConfigurationManager.AppSettings["ManagerPanelImagePath"].ToString());
            
                #region Logo Chaning Logic in all folders
                if (fpLogoImage.HasFile)
                {
                    FileInfo fleInfo = new FileInfo(fpLogoImage.FileName);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        fpLogoImage.SaveAs(MainPath + "logo" + fleInfo.Extension);
                        fpLogoImage.SaveAs(PlayerPath + "logo" + fleInfo.Extension);
                        fpLogoImage.SaveAs(AdminPath + "logo" + fleInfo.Extension);
                        fpLogoImage.SaveAs(ManagerPath + "logo" + fleInfo.Extension);
                    }
                }
                #endregion

                #region Text Image Changing Logic in all folders
                if (fpTextImage.HasFile)
                {
                    FileInfo fleInfo = new FileInfo(fpTextImage.FileName);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        fpTextImage.SaveAs(MainPath + "acme-inc" + fleInfo.Extension);
                        fpTextImage.SaveAs(PlayerPath + "acme-inc" + fleInfo.Extension);
                        fpTextImage.SaveAs(AdminPath + "acme-inc" + fleInfo.Extension);
                        fpTextImage.SaveAs(ManagerPath + "acme-inc" + fleInfo.Extension);
                    }
                }
                #endregion

                #region Banner Backgroung Image Changing Logic in all folders
                if (fpBannerImage.HasFile)
                {
                    FileInfo fleInfo = new FileInfo(fpBannerImage.FileName);
                    if (AllowedFile(fleInfo.Extension))
                    {
                        fpBannerImage.SaveAs(MainPath + "banner-bg" + fleInfo.Extension);
                        fpBannerImage.SaveAs(PlayerPath + "banner-bg" + fleInfo.Extension);
                        fpBannerImage.SaveAs(AdminPath + "banner-bg" + fleInfo.Extension);
                        fpBannerImage.SaveAs(ManagerPath + "banner-bg" + fleInfo.Extension);
                    }
                }
                #endregion

                Common.Utils.WebMessageBoxUtil.Show("Banner Has been updated successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}