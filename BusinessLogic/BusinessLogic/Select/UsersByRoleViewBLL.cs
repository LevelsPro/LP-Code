using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class UsersByRoleViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Roles _role;
        public UsersByRoleViewBLL()
        {
        }
        public void Invoke()
        {
            UsersByRoleViewDAL selectData = new UsersByRoleViewDAL();
            selectData.Role = this.Role;
            ResultSet = selectData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
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
