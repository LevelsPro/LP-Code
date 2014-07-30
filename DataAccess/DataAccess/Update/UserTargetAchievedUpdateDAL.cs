using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    
    public class UserTargetAchievedUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private UserTargetAchievedDataParameters _insertParameters;

        public UserTargetAchievedUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_Update_UserTargetAchieved.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserTargetAchievedDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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

    public class UserTargetAchievedDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserTargetAchievedDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                          
                                            new MySqlParameter("?p_TargetID",User.TargetID)                                          
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
