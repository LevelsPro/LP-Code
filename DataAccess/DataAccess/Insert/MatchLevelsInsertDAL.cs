using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class MatchLevelsInsertDAL : DataAccessBase
    {
         private Common.Match _match;
         private MatchLevelsInsertDataParameters _insertParameters;

        public MatchLevelsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMatchLevels.ToString();
        }
        public void Add()
        {

            _insertParameters = new MatchLevelsInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
    public class MatchLevelsInsertDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchLevelsInsertDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_RoleID",Match.RoleID),
                                              new MySqlParameter("?p_LevelID",Match.LevelID)
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
        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
}
