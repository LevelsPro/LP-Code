using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class RolesInsertDAL : DataAccessBase
    {
        private Common.Roles _roles;
        private RolesInsertDataParameters _insertParameters;
        
        public RolesInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertRole.ToString();
        }
        public void Add()
        {

            _insertParameters = new RolesInsertDataParameters(Roles);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Roles Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
    }
    public class RolesInsertDataParameters
    {
        private Common.Roles _roles;
        private MySqlParameter[] _parameters;

        public RolesInsertDataParameters(Common.Roles roles)
        {
            Roles = roles;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_RoleName", Roles.RoleName)
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
        public Common.Roles Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
            }
        }
    }
}
