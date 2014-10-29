using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class UserImageDeleteDAL : DataAccessBase
    {
        private Common.UserImage _user;
        private UserImageDeleteDataParameters _deleteParameters;

        public UserImageDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteUserImage.ToString();
        }
        public object Delete()
        {

            _deleteParameters = new UserImageDeleteDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
             
             return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.UserImage User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }

    public class UserImageDeleteDataParameters
    {
        private Common.UserImage _user;
        private MySqlParameter[] _parameters;

        public UserImageDeleteDataParameters(Common.UserImage user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserIDImage", User.UserIDImage) };
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
        public Common.UserImage User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
