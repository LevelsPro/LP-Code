using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class MatchLevelsDeleteDAL : DataAccessBase
    {
       private Common.Match _match;
        private MatchLevelsDeleteDataParameters _deleteParameters;

        public MatchLevelsDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteMatchLevels.ToString();
        }
        public void Delete()
        {
            _deleteParameters = new MatchLevelsDeleteDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _deleteParameters.Parameters);
          
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

    public class MatchLevelsDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchLevelsDeleteDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_MatchID", Match.MatchID) };
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
