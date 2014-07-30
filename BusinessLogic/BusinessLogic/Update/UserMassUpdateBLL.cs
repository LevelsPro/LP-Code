using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class UserMassUpdateBLL : Transaction
    {
         private Common.User _user;

         public UserMassUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserMassUpdateDAL updateuser = new UserMassUpdateDAL();
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
