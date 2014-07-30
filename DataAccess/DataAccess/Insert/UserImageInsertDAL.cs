using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
  public  class UserImageInsertDAL : DataAccessBase
    {
      private Common.UserImage _userimage;
        private UserImageInsertDataParameters _insertParameters;

        public UserImageInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertImage.ToString();
        }
        public void Add()
        {

            _insertParameters = new UserImageInsertDataParameters(UserImage);
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
    public class UserImageInsertDataParameters
    {
        private Common.UserImage _userimage;
        private MySqlParameter[] _parameters;

        public UserImageInsertDataParameters(Common.UserImage userimage)
        {
            UserImage = userimage;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_PlayerImage",UserImage.PlayerImage),
                                         new MySqlParameter("?p_PlayerThumbnail",UserImage.PlayerThumbnail),
                                          new MySqlParameter("?p_UserID",UserImage.UserID)
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
