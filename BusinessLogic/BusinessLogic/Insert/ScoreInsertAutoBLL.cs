using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class ScoreInsertAutoBLL
    {
        private Common.User _user;

        public ScoreInsertAutoBLL()
        {
        }
        public void Invoke()
        {
            ScoreInsertAutoDAL insertuser = new ScoreInsertAutoDAL();
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
