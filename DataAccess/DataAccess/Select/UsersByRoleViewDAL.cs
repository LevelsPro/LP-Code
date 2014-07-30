using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class UsersByRoleViewDAL : DataAccessBase
    {
        private Common.Roles _role;
        private UsersByRoleParameters _viewParameters;

        public UsersByRoleViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUsersByRole.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new UsersByRoleParameters(Role);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

        }
        public Common.Roles Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
    }
    public class UsersByRoleParameters
    {
        private Common.Roles _role;
        private MySqlParameter[] _parameters;

        public UsersByRoleParameters(Common.Roles role)
        {
            Role = role;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_RoleID",Role.RoleID)
                                            
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
        public Common.Roles Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
    }
}
