using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class UserPointsUpdateBLL :Transaction
    {
        private Common.User _user;

        public UserPointsUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserPointsUpdateDAL updateData = new UserPointsUpdateDAL();
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
