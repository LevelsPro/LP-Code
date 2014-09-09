using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class DataSetsInsertBLL : Transaction
    {

       private Common.Match _match;
       public DataSetsInsertBLL()
        {
        }
        public void Invoke()
        {
            DataSetsInsertDAL insertData = new DataSetsInsertDAL();
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
