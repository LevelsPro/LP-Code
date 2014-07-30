using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class UserImageUpdateDAL : DataAccessBase
    {
       private Common.UserImage _userimage;
        private UserImageUpdateDataParameters _insertParameters;

        public UserImageUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateImage.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserImageUpdateDataParameters(UserImage);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

        }

        public Common.UserImage UserImage
        {
            get
            {
                return _userimage;
            }
            set
            {
                _userimage = value;
            }
        }
    }
   public class UserImageUpdateDataParameters
    {
       private Common.UserImage _userimage;
        private MySqlParameter[] _parameters;

        public UserImageUpdateDataParameters(Common.UserImage userimage)
        {
            UserImage = userimage;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserIDImage",UserImage.UserIDImage),
                                           new MySqlParameter("?p_UserImage",UserImage.UserImages),
                                            new MySqlParameter("?p_UserID",UserImage.UserID),
                                          new MySqlParameter("?p_UserImageExt",UserImage.UserImageExt),
                                           new MySqlParameter("?p_Active",UserImage.Active),
                                           new MySqlParameter("?p_UploadDate",UserImage.UploadDate),
                                           new MySqlParameter("?p_Current",UserImage.Current)
                                           
                                          };
            
            Parameters = parameters;
        }
        public MySqlParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }
        public Common.UserImage UserImage
        {
            get
            {
                return _userimage;
            }
            set
            {
                _userimage = value;
            }
        }
    }
}
