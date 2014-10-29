using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class RoundDeleteDAL : DataAccessBase
    {
        private Common.Match _match;
        private RoundDeleteDataParameters _deleteParameters;

        public RoundDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteRound.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new RoundDeleteDataParameters(Match);
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

    public class RoundDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public RoundDeleteDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_RoundID", Match.RoundID)};
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
