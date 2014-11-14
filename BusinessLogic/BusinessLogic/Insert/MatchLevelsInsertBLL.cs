using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class MatchLevelsInsertBLL : Transaction
    {
        private Common.Match _match;
        public MatchLevelsInsertBLL()
        {
        }
        public void Invoke()
        {
            MatchLevelsInsertDAL insertData = new MatchLevelsInsertDAL();
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
