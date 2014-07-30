using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class SecurityAnswerInsertBLL : Transaction
    {

        private Common.User _user;

        public SecurityAnswerInsertBLL()
        {
        }
        public void Invoke()
        {
            SecurityAnswerInsertDAL insertuser = new SecurityAnswerInsertDAL();
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
