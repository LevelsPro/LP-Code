using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class MatchPlayLogBLL
    {
        private Common.Match _match;
        public MatchPlayLogBLL()
        {
        }
        public void Invoke()
        {
            MatchPlayLogDAL insertData = new MatchPlayLogDAL();
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
