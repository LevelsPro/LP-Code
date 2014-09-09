using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{   
    public class DataSetLevelsInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataSetLevelsInsertDataParameters _insertParameters;

        public DataSetLevelsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertDataSetLevels.ToString();
        }
        public void Add()
        {

            _insertParameters = new DataSetLevelsInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);
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
    public class DataSetLevelsInsertDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetLevelsInsertDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_DataSetID",Match.DataSetID),
                                              new MySqlParameter("?p_RoleID",Match.RoleID),
                                              new MySqlParameter("?p_LevelID",Match.LevelID)
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
