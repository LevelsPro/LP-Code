using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class RolesUpdateDAL : DataAccessBase
    {
        private Common.Roles _roles;
        private RolesUpdateDataParameters _insertParameters;

        public RolesUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateRole.ToString();
        }
        public void Update()
        {

            _insertParameters = new RolesUpdateDataParameters(Roles);
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
    public class RolesUpdateDataParameters
    {
        private Common.Roles _roles;
        private MySqlParameter[] _parameters;

        public RolesUpdateDataParameters(Common.Roles roles)
        {
            Roles = roles;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_RoleID", Roles.RoleID), 
                                            new MySqlParameter("?p_RoleName", Roles.RoleName),
                                            new MySqlParameter("?p_Active", Roles.Active),
                                             new MySqlParameter("?p_ActiveStatus", Roles.ActiveStatus)
                                            
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
