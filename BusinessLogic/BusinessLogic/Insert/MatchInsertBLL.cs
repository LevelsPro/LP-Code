﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class MatchInsertBLL : Transaction
    {

        private Common.Match _match;
        public MatchInsertBLL()
        {
        }
        public void Invoke()
        {
            MatchInsertDAL insertData = new MatchInsertDAL();
            insertData.Match = this.Match;
            insertData.Add();
        }

        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
}
