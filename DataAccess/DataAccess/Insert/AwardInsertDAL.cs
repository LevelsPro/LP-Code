using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class AwardInsertDAL : DataAccessBase
    {
        private Common.Award _award;
        private AwardInsertDataParameters _insertParameters;

        public AwardInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertAwards.ToString();
        }
        public int Add()
        {

            _insertParameters = new AwardInsertDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

            return Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[5]).Value);
        }

        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
    public class AwardInsertDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public AwardInsertDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_AwardName",Award.AwardName),
                                         new MySqlParameter("?p_AwardDesc",Award.AwardDesc),
                                          
                                            new MySqlParameter("?p_KPIID",Award.KPIID),
                                           new MySqlParameter("?p_TargetID",Award.TargetID),
                                           new MySqlParameter("?p_AwardManual",Award.AwardManual),
                                           new MySqlParameter("?p_AwardID",MySqlDbType.Int32,4,System.Data.ParameterDirection.Output,true,0,0,"Award_ID",System.Data.DataRowVersion.Current,Award.AwardID),
                                           new MySqlParameter("?p_AwardCategoryID",Award.AwardCategoryID)
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
        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
