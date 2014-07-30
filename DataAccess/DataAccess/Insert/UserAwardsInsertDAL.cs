using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class UserAwardsInsertDAL:DataAccessBase
    {
        private Common.UserAwards userAward;
        private UserAwardsInsertDataParameters _insertParameters;

        public UserAwardsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertUserAwards.ToString();
        }

        public void Add()
        {

            _insertParameters = new UserAwardsInsertDataParameters(UserAward);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.UserAwards UserAward
        {
            get { return userAward; }
            set { userAward = value; }
        }
    }

    public class UserAwardsInsertDataParameters
    {
        private Common.UserAwards _userAward;
        private MySqlParameter[] _parameters;

        public UserAwardsInsertDataParameters(Common.UserAwards award)
        {
            _userAward = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_user_id",_userAward.User_Id),
                                         new MySqlParameter("?p_award_id",_userAward.Award_Id),                                           
                                           new MySqlParameter("?p_manual",_userAward.Manual),
                                            new MySqlParameter("?p_awardedBy",_userAward.AwardedBy)};
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
        public Common.UserAwards UserAward
        {
            get
            {
                return _userAward;
            }
            set
            {
                _userAward = value;
            }
        }
    }
}
