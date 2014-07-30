using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
   public class UserImage
    {
        #region Private Members
        SqlInt32 _useridimage;
        byte[] _userimage;
        SqlString _userimageext;
        SqlInt32 _userid;
        SqlInt16 _active;
        DateTime _uploaddate;
        SqlInt16 _current;

        SqlString _playerimage;
        SqlString _playerthumbnail;


        #endregion

        public UserImage()
        {
        }

        #region Properties
        public SqlInt32 UserIDImage
        {
            get { return _useridimage; }
            set { _useridimage = value; }
        }
        public byte[] UserImages
        {
            get { return _userimage; }
            set { _userimage = value; }
        }
        public SqlString UserImageExt
        {
            get { return _userimageext; }
            set { _userimageext = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public SqlInt16 Current
        {
            get { return _current; }
            set { _current = value; }

        }
        public DateTime UploadDate
        {
            get { return _uploaddate; }
            set { _uploaddate = value; }
        }

        public SqlString PlayerImage
        {
            get { return _playerimage; }
            set { _playerimage = value; }
        }

        public SqlString PlayerThumbnail
        {
            get { return _playerthumbnail; }
            set { _playerthumbnail = value; }
        }
        #endregion
    }
}
