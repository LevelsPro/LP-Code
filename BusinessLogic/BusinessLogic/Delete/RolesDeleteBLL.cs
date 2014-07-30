using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
    public class RolesDeleteBLL
    {
        private Common.Roles _roles;
        public RolesDeleteBLL()
        {
        }
        public object Invoke()
        {
            RolesDeleteDAL insertData = new RolesDeleteDAL();
            insertData.Roles = this.Roles;
            return insertData.Delete();
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
