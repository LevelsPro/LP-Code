using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class ContestInsertDAL : DataAccessBase
    {
         private Common.Contest _contest;
         private ContestInsertDataParameters _insertParameters;

         public ContestInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertContest.ToString();
        }
        public void Add()
        {

            _insertParameters = new ContestInsertDataParameters(Contest);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            int retu = dbHelper.Run(Contest.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);

            //object[] mObjRetu = dbHelper.RunReturnParValueSqlTrans(base.ConnectionString, _insertParameters.Parameters, Match.sqlTransaction);
            Contest.ContestID = Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[6]).Value);

        }

        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }
    }
    public class ContestInsertDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestInsertDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ContestName",Contest.ContestName),                                          
                                          new MySqlParameter("?p_FromDate",Contest.FromDate),
                                          new MySqlParameter("?p_ToDate",Contest.ToDate),
                                          new MySqlParameter("?p_KPIID",Contest.KPIID),
                                          new MySqlParameter("?p_RoleID", Contest.RoleID),
                                          new MySqlParameter("?p_SiteID", Contest.SiteID),                                          
                                          new MySqlParameter("?p_Cid", MySqlDbType.Int16, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, Contest.ContestID)};
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
        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }

    }
}
