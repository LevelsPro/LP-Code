using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   
    public class Level_TargetUpdateDAL : DataAccessBase
    {
        private Common.Target _target;
        private Level_TargetUpdateDataParameters _insertParameters;

        public Level_TargetUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_levels_UpdateTargets.ToString();
        }
        public void Update()
        {

            _insertParameters = new Level_TargetUpdateDataParameters(Target);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Target Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
    }
    public class Level_TargetUpdateDataParameters
    {
        private Common.Target _target;
        private MySqlParameter[] _parameters;

        public Level_TargetUpdateDataParameters(Common.Target target)
        {
            Target = target;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_TargetID",Target.TargetID),
                                              new MySqlParameter("?p_TargetValue",Target.TargetValue),
                                         new MySqlParameter("?p_KpiID",Target.KPIID),
                                          new MySqlParameter("?p_Points",Target.Points),
                                          new MySqlParameter("?p_Order",Target.TargetOrder)
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
        public Common.Target Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
    }
}
