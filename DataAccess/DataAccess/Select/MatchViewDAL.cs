using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class MatchViewDAL : DataAccessBase
    {
        private Common.Match _match;
        public MatchViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetMatch.ToString();
        }

        public DataSet View() 
        {
            DataSet ds;
            MatchViewDataParameters _viewParameters = new MatchViewDataParameters(Match);
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

    public class MatchViewDataParameters 
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchViewDataParameters(Common.Match match) 
        {
            Match = match;
            Build();
        }
        public void Build() 
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_Where", Match.Where)
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
