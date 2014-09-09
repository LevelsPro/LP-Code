using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class RoundViewDAL : DataAccessBase
    {
        private Common.Match _match;
        public RoundViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetRound.ToString();
        }

        public DataSet View() 
        {
            DataSet ds;
            RoundViewDataParameters _viewParameters = new RoundViewDataParameters(Match);
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

    public class RoundViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public RoundViewDataParameters(Common.Match match) 
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
