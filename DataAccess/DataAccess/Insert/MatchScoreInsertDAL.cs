using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class MatchScoreInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private MatchScoreInsertDataParameters _insertParameters;

        public MatchScoreInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMatchScore.ToString();
        }
        public void Add()
        {

            _insertParameters = new MatchScoreInsertDataParameters(Match);
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
    public class MatchScoreInsertDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchScoreInsertDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",Match.UserID),
                                              new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_Points",Match.AchievedPoints),
                                              new MySqlParameter("?p_ElapsedTime",Match.Elapsed),
                                              new MySqlParameter("?p_IsCorrect",Match.IsCorrect)
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
