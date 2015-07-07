using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;
using System.Configuration;
using System.IO;

namespace Common.Utils
{
    public class FileResources
    {
        private static readonly FileResources _instance = new FileResources();
        protected string[] _allowedExtensions = { ".jpeg", ".jpg", ".bmp", ".png", ".gif" };

        private FileResources()
        {

        }

        public static FileResources Instance
        {
            get
            {
                return FileResources._instance;
            }
        }

        public string[] AllowedExtensions
        {
            get
            {
                return this._allowedExtensions;
            }
            set
            {
                this._allowedExtensions = value;
            }
        }

        protected bool AllowedFile(string extension)
        {
            if (this.AllowedExtensions.Contains(extension))
            {
                return true;
            }
            return false;
        }

        public String save(FileUpload fileUpload, Hashtable hashtable)
        {
            if (!fileUpload.HasFile)
            {
                return null;
            }

            FileInfo fileInfo = new FileInfo(fileUpload.FileName);
            if (this.AllowedFile(fileInfo.Extension))
            {
                string GuidOne = Guid.NewGuid().ToString();
                string FileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                // Check if directory already exist.
                string path = (string)hashtable["folderPath"];
                this.preparePath(path);
                string filename = Path.Combine(path, GuidOne + FileExtension);
                fileUpload.SaveAs(filename);

                System.Drawing.Image img = System.Drawing.Image.FromFile(filename);
                System.Drawing.Image thumbImage = img.GetThumbnailImage(72, 72, null, IntPtr.Zero);
                string thumbPath = (string)hashtable["thumbnailPath"];
                this.preparePath(thumbPath);
                string thumbFileName = Path.Combine(thumbPath, GuidOne + FileExtension);
                thumbImage.Save(thumbFileName);

                return string.Format("{0}{1}", GuidOne, FileExtension);
            }

            return null;
        }

        public void preparePath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
