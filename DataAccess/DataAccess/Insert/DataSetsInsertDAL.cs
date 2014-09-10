using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class DataSetsInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataSetsInsertDataParameters _insertParameters;

        public DataSetsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertDataSet.ToString();
        }
        public void Add()
        {

            _insertParameters = new DataSetsInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            int retu = dbHelper.Run(Match.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);

            //object[] mObjRetu = dbHelper.RunReturnParValueSqlTrans(base.ConnectionString, _insertParameters.Parameters, Match.sqlTransaction);
            Match.DataSetID = Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[5]).Value);
            
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
    public class DataSetsInsertDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataSetsInsertDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_DataSetElementsData", Match.DataElementData),
                                              new MySqlParameter("?p_SiteID",Match.SiteID),
                                              new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_DataSetImage",Match.DataSetImage),
                                              new MySqlParameter("?p_DataSetImageThumbnail",Match.DataSetImageThumbnail),
                                              new MySqlParameter("?p_Did", MySqlDbType.Int16, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, Match.DataSetID)
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
