using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class DataSetViewDAL : DataAccessBase
    {
        private Common.Match _match;
        public DataSetViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetDataSet.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            DataSetViewDataParameters _viewParameters = new DataSetViewDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
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

    public class DataSetViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetViewDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_Where",Match.Where),
                                              new MySqlParameter("?p_Status",Match.Status)
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
