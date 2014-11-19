using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
public    class AwardScoreInsertBLL
    {
     private Common.User _user;

     public AwardScoreInsertBLL()
        {
        }
        public void Invoke()
        {
            AwardScoreInsertDAL insertuser = new AwardScoreInsertDAL();
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
