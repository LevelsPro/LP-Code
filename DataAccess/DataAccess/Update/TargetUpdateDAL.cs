using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class TargetUpdateDAL : DataAccessBase
    {
        private Common.Target _target;
         private TargetUpdateDataParameters _insertParameters;

         public TargetUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateTarget.ToString();
        }
        public void Update()
        {

            _insertParameters = new TargetUpdateDataParameters(Target);
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
    public class TargetUpdateDataParameters
    {
        private Common.Target _target;
        private MySqlParameter[] _parameters;

        public TargetUpdateDataParameters(Common.Target target)
        {
            Target = target;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_TargetID",Target.TargetID),
                                              new MySqlParameter("?p_TargetValue",Target.TargetValue),
                                         new MySqlParameter("?p_KpiID",Target.KPIID),
                                          new MySqlParameter("?p_LevelID",Target.LevelID),
                                           new MySqlParameter("?p_RoleID",Target.RoleID),
                                           new MySqlParameter("?p_Active",Target.Active),
                                            new MySqlParameter("?p_Description",Target.Description)
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
