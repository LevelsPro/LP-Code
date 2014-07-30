using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class UpdatePasswordBLL : Transaction
    {
        private Common.User _user;

        public UpdatePasswordBLL()
        {
        }
        public void Invoke()
        {
            UpdatePasswordDAL updateuser = new UpdatePasswordDAL();
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
