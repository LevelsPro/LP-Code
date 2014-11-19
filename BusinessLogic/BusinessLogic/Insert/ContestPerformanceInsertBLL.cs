using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class ContestPerformanceInsertBLL
    {
        private Common.Contest _contest;
        public ContestPerformanceInsertBLL()
        {
        }
        public void Invoke()
        {
            ContestPerformanceInsertDAL insertData = new ContestPerformanceInsertDAL();
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
