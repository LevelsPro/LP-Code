using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;
using Common;


namespace BusinessLogic.Update
{
   public class UserUpdateBLL :Transaction
    {
        private Common.User _user;

        public UserUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserUpdateDAL updateData = new UserUpdateDAL();
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
