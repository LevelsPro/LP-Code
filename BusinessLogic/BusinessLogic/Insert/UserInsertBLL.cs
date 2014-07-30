using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class UserInsertBLL : Transaction
    {
        private Common.User _user;

        public UserInsertBLL()
        {
        }
        public void Invoke()
        {
            UserInsertDAL insertuser = new UserInsertDAL();
            insertuser.User = this.User;
            insertuser.Insert();
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
