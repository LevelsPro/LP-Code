using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    
    public class UserAwardAchievedUpdateBLL : Transaction
    {
        private Common.User _user;

        public UserAwardAchievedUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserAwardAchievedUpdateDAL updateData = new UserAwardAchievedUpdateDAL();
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
