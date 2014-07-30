using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class UserEditUpdateBLL : Transaction
    {
       private Common.User _user;

       public UserEditUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserEditUpdateDAL updateData = new UserEditUpdateDAL();
            updateData.User = this.User;
            updateData.Update();
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
