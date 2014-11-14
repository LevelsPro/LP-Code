using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class ContestDeleteBLL
    {
        private Common.Contest _contest;
        public ContestDeleteBLL()
        {
        }
        public object Invoke()
        {
            ContestDeleteDAL deleteData = new ContestDeleteDAL();
            deleteData.Contest = this.Contest;
            return deleteData.Delete();
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
