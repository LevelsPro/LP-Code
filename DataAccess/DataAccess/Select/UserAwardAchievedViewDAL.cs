using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
   
    public class UserAwardAchievedViewDAL : DataAccessBase
    {
        private Common.User _user;
        private UserAwardAchievedDataParameters _insertParameters;

        public UserAwardAchievedViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUserAwardScore.ToString();
        }
        public DataSet Update()
        {
            DataSet ds;
            _insertParameters = new UserAwardAchievedDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
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
    public class UserAwardAchievedDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserAwardAchievedDataParameters(Common.User users)
        {
            User = users;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID)                                              
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
