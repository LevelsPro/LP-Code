using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Duplicate;

namespace BusinessLogic.Duplicate
{
    public class ContestDuplicateBLL : Transaction
    {

        private Common.Contest _contest;
        public ContestDuplicateBLL()
        {
        }
        public void Invoke()
        {
            ContestDuplicateDAL duplicateData = new ContestDuplicateDAL();
            duplicateData.Contest = this.Contest;
            duplicateData.Add();
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
