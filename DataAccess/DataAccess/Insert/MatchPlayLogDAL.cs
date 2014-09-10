using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class MatchPlayLogDAL : DataAccessBase
    {
        private Common.Match _match;
        private MatchPlayInsertDataParameters _insertParameters;

        public MatchPlayLogDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMatchPlayLog.ToString();
        }

        public void Add()
        {

            _insertParameters = new MatchPlayInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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

    public class MatchPlayInsertDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchPlayInsertDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {
                                              new MySqlParameter("?p_UserID",Match.UserID),
                                              new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_MatchTime",Match.MatchTime),
                                              new MySqlParameter("?p_MatchPlays", Match.MatchPlays)
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
