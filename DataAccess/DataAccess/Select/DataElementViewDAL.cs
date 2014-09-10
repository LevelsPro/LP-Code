using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class DataElementViewDAL : DataAccessBase
    {
        private Common.Match _match;
        public DataElementViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetDataElement.ToString();
        }

        public DataSet View() 
        {
            DataSet ds;
            DataElementViewDataParameters _viewParameters = new DataElementViewDataParameters(Match);
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

    public class DataElementViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataElementViewDataParameters(Common.Match match) 
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
