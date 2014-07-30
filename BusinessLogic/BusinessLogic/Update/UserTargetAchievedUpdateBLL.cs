using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   
    public class UserTargetAchievedUpdateBLL : Transaction
    {
        private Common.User _user;

        public UserTargetAchievedUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserTargetAchievedUpdateDAL updateData = new UserTargetAchievedUpdateDAL();
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
