using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class UserAwardAchievedUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private UserAwardAchievedDataParameters _insertParameters;

        public UserAwardAchievedUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_Update_UserAwardAchieved.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserAwardAchievedDataParameters(User);
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

    public class UserAwardAchievedDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserAwardAchievedDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                          
                                            new MySqlParameter("?p_AwardID",User.AwardID)                                          
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
