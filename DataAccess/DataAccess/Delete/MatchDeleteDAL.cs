using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class MatchDeleteDAL : DataAccessBase
    {
        private Common.Match _match;
        private MatchDeleteDataParameters _deleteParameters;

        public MatchDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteMatch.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new MatchDeleteDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
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

    public class MatchDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchDeleteDataParameters(Common.Match match)
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
