﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class ScoreInsertBLL : Transaction
    {
        private Common.User _user;

        public ScoreInsertBLL()
        {
        }
        public void Invoke()
        {
            ScoreInsertDAL insertuser = new ScoreInsertDAL();
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
