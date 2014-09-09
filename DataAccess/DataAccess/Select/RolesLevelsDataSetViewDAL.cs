using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class RolesLevelsDataSetViewDAL: DataAccessBase
    {
        private Common.Match _match;

        public RolesLevelsDataSetViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_RolesLevelsMatchDataSet.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            DataSetRolesLevelsViewDataParameters _viewParameters = new DataSetRolesLevelsViewDataParameters(Match);
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
    public class DataSetRolesLevelsViewDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetRolesLevelsViewDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_DataSetID", Match.DataSetID)
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
