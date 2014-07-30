using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class UserInfoByEmailDAL : DataAccessBase
    {
        private Common.User _user;
        public UserInfoByEmailDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUserInfoByEmail.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            UserInfoByEmailParameters _viewParameters = new UserInfoByEmailParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);           
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

        }
        public Common.User User
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
    public class UserInfoByEmailParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserInfoByEmailParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_Email",User.UserEmail)                                           
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
        public Common.User User
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
