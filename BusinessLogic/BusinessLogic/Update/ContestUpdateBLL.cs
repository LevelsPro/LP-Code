using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class ContestUpdateBLL : Transaction
    {
        private Common.Contest _contest;

        public ContestUpdateBLL()
        {
        }
        public void Invoke()
        {
            ContestUpdateDAL updateData = new ContestUpdateDAL();
            updateData.Contest = this.Contest;
            updateData.Update();
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

