using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class DataSetDeleteDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataSetDeleteDataParameters _deleteParameters;

        public DataSetDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteDataSet.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new DataSetDeleteDataParameters(Match);
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

    public class DataSetDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetDeleteDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_DataSetID", Match.DataSetID) };
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
