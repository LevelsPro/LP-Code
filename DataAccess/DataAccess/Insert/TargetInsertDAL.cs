using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class TargetInsertDAL : DataAccessBase
    {
         private Common.Target _target;
         private TargetInsertDataParameters _insertParameters;

         public TargetInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertTarget.ToString();
        }
        public void Add()
        {

            _insertParameters = new TargetInsertDataParameters(Target);
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
    public class TargetInsertDataParameters
    {
        private Common.Target _target;
        private MySqlParameter[] _parameters;

        public TargetInsertDataParameters(Common.Target target)
        {
            Target = target;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_TargetValue",Target.TargetValue),
                                         new MySqlParameter("?p_KpiID",Target.KPIID),
                                          new MySqlParameter("?p_LevelID",Target.LevelID),
                                           new MySqlParameter("?p_RoleID",Target.RoleID),
                                           new MySqlParameter("?p_Description",Target.Description),
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
