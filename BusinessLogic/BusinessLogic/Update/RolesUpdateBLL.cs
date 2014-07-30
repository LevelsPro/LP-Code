using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class RolesUpdateBLL
    {
        private Common.Roles _roles;

        public RolesUpdateBLL()
        {
        }
        public void Invoke()
        {
            RolesUpdateDAL updateData = new RolesUpdateDAL();
            updateData.Roles = this.Roles;
            updateData.Update();
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
