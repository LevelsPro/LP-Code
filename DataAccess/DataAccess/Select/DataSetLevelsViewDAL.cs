using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{   
    public class DataSetLevelsViewDAL : DataAccessBase
    {
        private Common.Match _match;
        public DataSetLevelsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetDataSetLevels.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            DataSetLevelsViewDataParameters _viewParameters = new DataSetLevelsViewDataParameters(Match);
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

    public class DataSetLevelsViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetLevelsViewDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_DataSetID",Match.DataSetID),
                                              new MySqlParameter("?p_RoleID",Match.RoleID)
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
