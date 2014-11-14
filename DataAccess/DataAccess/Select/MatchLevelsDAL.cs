using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
 public   class MatchLevelsDAL : DataAccessBase
    {
      private Common.Match _match;

      public MatchLevelsDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_MatchLevels.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            MatchRolesLevelsViewDataParameters _viewParameters = new MatchRolesLevelsViewDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

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
    public class MatchRolesLevelsViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchRolesLevelsViewDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID",Match.MatchID)
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
