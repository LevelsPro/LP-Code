using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class ContestInsertBLL : Transaction
    {

        private Common.Contest _contest;
        public ContestInsertBLL()
        {
        }
        public void Invoke()
        {
            ContestInsertDAL insertData = new ContestInsertDAL();
            insertData.Contest = this.Contest;
            insertData.Add();
        }

        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }
    }
}
