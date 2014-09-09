using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class MatchScoreInsertBLL : Transaction
    {
      
        private Common.Match _match;
        public MatchScoreInsertBLL()
        {
        }
        public void Invoke()
        {
            MatchScoreInsertDAL insertData = new MatchScoreInsertDAL();
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
