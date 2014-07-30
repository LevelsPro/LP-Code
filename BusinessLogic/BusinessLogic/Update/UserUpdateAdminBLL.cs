using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class UserUpdateAdminBLL : Transaction
    {
        private Common.User _user;

        public UserUpdateAdminBLL()
        {
        }
        public void Invoke()
        {
            UserUpdateAdminDAL updateuser = new UserUpdateAdminDAL();
            updateuser.User = this.User;
            updateuser.Update();
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
