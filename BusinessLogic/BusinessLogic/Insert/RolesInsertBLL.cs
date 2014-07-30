using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;
namespace BusinessLogic.Insert
{
    public class RolesInsertBLL : Transaction 
    {
        private Common.Roles _roles;
        public RolesInsertBLL()
        {
        }
        public void Invoke()
        {
            RolesInsertDAL insertData = new RolesInsertDAL();
            insertData.Roles = this.Roles;
            insertData.Add();
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
