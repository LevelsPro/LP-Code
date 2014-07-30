using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class PasswordResetUpdateBLL : Transaction
    {
      private Common.User _user;

      public PasswordResetUpdateBLL()
        {
        }
        public void Invoke()
        {
            PasswordResetUpdateDAL updateData = new PasswordResetUpdateDAL();
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
