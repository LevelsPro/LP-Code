using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public class DataSetLevelDeleteDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataSetLevelDeleteDataParameters _deleteParameters;

        public DataSetLevelDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteDataSetLevel.ToString();
        }
        public void Delete()
        {
            _deleteParameters = new DataSetLevelDeleteDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _deleteParameters.Parameters);
          
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

    public class DataSetLevelDeleteDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetLevelDeleteDataParameters(Common.Match match)
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
