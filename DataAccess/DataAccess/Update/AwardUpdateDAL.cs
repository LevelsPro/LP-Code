using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class AwardUpdateDAL : DataAccessBase
    {
       private Common.Award _award;
        private AwardUpdateDataParameters _insertParameters;

        public AwardUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateAward.ToString();
        }
        public void Update()
        {

            _insertParameters = new AwardUpdateDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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
    public class AwardUpdateDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public AwardUpdateDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_AwardID",Award.AwardID),
                                           new MySqlParameter("?p_AwardName",Award.AwardName),
                                            new MySqlParameter("?p_AwardDesc",Award.AwardDesc),
                                          
                                           new MySqlParameter("?p_KPIID",Award.KPIID),
                                           new MySqlParameter("?p_TargetID",Award.TargetID),
                                           new MySqlParameter("?p_AwardManual",Award.AwardManual),
                                           new MySqlParameter("?p_Active",Award.Active),
                                            new MySqlParameter("?p_ID",Award.ID),
                                             new MySqlParameter("?p_CurrentImage",Award.CurrentImage),
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
