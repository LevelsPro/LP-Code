using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class LoginUpdateBLL: Transaction
    {
       private Common.User _user;

       public LoginUpdateBLL()
        {
        }
        public void Invoke()
        {
            LoginUpdateDAL updateData = new LoginUpdateDAL();
            updateData.Users = this.Users;
            updateData.Update();
        }

        public Common.User Users
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
