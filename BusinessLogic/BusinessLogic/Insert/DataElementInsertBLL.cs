using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class DataElementInsertBLL : Transaction
    {

        private Common.Match _match;
        public DataElementInsertBLL()
        {
        }
        public void Invoke()
        {
            DataElementInsertDAL insertData = new DataElementInsertDAL();
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
