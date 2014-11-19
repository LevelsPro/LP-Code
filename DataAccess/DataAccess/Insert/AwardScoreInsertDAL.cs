using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class AwardScoreInsertDAL : DataAccessBase
    {
       private Common.User _user;
        private AwardScoreInsertAutoParameters _insertParameters;

        public AwardScoreInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertScoreAward.ToString();
        }
        public void Insert()
        {

            _insertParameters = new AwardScoreInsertAutoParameters(User);
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

    public class AwardScoreInsertAutoParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public AwardScoreInsertAutoParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                           new MySqlParameter("?p_UserID",User.UserID), 
                                            new MySqlParameter("?p_KPIID",User.KPIID),
                                            new MySqlParameter("?p_Score",User.Score),
                                          new MySqlParameter("?p_Measure",User.Measure),
                                          new MySqlParameter("?p_EntryDate",User.EntryDate),
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
