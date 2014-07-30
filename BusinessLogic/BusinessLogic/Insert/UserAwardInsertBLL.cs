using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class UserAwardInsertBLL : Transaction
    {
        private Common.UserAwards _award;
        public UserAwardInsertBLL()
        {
        }
        public void Invoke()
        {
            UserAwardsInsertDAL insertData = new UserAwardsInsertDAL();
            insertData.UserAward = this.Award;
            insertData.Add();
        }

        public Common.UserAwards Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
