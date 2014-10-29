using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class DataElementDeleteDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataElementDeleteDataParameters _deleteParameters;

        public DataElementDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteDataElement.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new DataElementDeleteDataParameters(Match);
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

    public class DataElementDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataElementDeleteDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_MatchID", Match.MatchID),
                                              new MySqlParameter("?p_ElementID", Match.ElementID)
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
