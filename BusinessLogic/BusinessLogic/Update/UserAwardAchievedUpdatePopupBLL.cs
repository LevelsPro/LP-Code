using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class UserAwardAchievedUpdatePopupBLL : Transaction
    {
          private Common.User _user;

          public UserAwardAchievedUpdatePopupBLL()
        {
        }
        public void Invoke()
        {
            UserAwardAchievedUpdatePopupDAL updateData = new UserAwardAchievedUpdatePopupDAL();
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
