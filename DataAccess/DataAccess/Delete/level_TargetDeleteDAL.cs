using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
   
    public class level_TargetDeleteDAL : DataAccessBase
    {
        private Common.Target _target;
        private Level_TargetDeleteDataParameters _deleteParameters;

        public level_TargetDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteTarget.ToString();
        }
        public object Delete()
        {

            _deleteParameters = new Level_TargetDeleteDataParameters(Target);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
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

    public class Level_TargetDeleteDataParameters
    {
        private Common.Target _target;
        private MySqlParameter[] _parameters;

        public Level_TargetDeleteDataParameters(Common.Target target)
        {
            Target = target;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_TargetID", Target.TargetID) };
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
