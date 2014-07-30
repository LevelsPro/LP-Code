using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class ScoreInsertDAL : DataAccessBase
    {

        private Common.User _user;
        private ScoreInsertDataParameters _insertParameters;

        public ScoreInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertScore.ToString();
        }
        public void Insert()
        {

            _insertParameters = new ScoreInsertDataParameters(User);
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

    public class ScoreInsertDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public ScoreInsertDataParameters(Common.User user)
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
                                          new MySqlParameter("?p_EntryDate",User.EntryDate)
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
