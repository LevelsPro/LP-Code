using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class MatchScoreDeleteDAL : DataAccessBase
    {
       private Common.Match _match;
        private MatchScoreDeleteDataParameters _deleteParameters;

        public MatchScoreDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteMatchUserScore.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new MatchScoreDeleteDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
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

    public class MatchScoreDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchScoreDeleteDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID", Match.UserID) };
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
