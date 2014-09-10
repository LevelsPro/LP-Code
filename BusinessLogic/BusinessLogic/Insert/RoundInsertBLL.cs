using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class RoundInsertBLL : Transaction
    {

        private Common.Match _match;
        public RoundInsertBLL()
        {
        }
        public void Invoke()
        {
            RoundInsertDAL insertData = new RoundInsertDAL();
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
