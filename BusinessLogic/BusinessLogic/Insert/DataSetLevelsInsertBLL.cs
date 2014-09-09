using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class DataSetLevelsInsertBLL : Transaction
    {
        private Common.Match _match;
        public DataSetLevelsInsertBLL()
        {
        }
        public void Invoke()
        {
            DataSetLevelsInsertDAL insertData = new DataSetLevelsInsertDAL();
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
