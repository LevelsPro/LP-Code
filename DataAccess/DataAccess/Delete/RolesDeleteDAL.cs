using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class RolesDeleteDAL : DataAccessBase
    {
        private Common.Roles _roles;
        private RolesDeleteDataParameters _insertParameters;

        public RolesDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_deleterole.ToString();
        }
        public object Delete()
        {

            _insertParameters = new RolesDeleteDataParameters(Roles);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            return dbHelper.RunScalar(base.ConnectionString, _insertParameters.Parameters);

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
    public class RolesDeleteDataParameters
    {
        private Common.Roles _roles;
        private MySqlParameter[] _parameters;

        public RolesDeleteDataParameters(Common.Roles roles)
        {
            Roles = roles;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?roleid ", Roles.RoleID) };
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
