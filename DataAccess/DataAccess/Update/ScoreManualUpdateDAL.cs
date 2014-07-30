using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class ScoreManualUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private ScoreUpdateDataParameters _insertParameters;

        public ScoreManualUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateScoreManual.ToString();
        }
        public void Update()
        {

            _insertParameters = new ScoreUpdateDataParameters(User);
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
    public class ScoreUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public ScoreUpdateDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID), 
                                            new MySqlParameter("?p_KPIID",User.KPIID),
                                            new MySqlParameter("?p_Score",User.Score),
                                          new MySqlParameter("?p_Current",User.CurrentLevel)};
            
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
