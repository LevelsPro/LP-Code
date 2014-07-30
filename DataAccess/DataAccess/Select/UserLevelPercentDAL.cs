using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class UserLevelPercentDAL : DataAccessBase
    {
        private Common.User _user;
        public UserLevelPercentDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetPlayerLevelPercent.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            UserLevelPercentDataParameters _insertParameters = new UserLevelPercentDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
            ds = dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class UserLevelPercentDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserLevelPercentDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",User.UserID)
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
