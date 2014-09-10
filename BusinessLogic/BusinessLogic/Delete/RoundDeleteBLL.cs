using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class RoundDeleteBLL
    {
        private Common.Match _match;
        public RoundDeleteBLL()
        {
        }
        public object Invoke()
        {
            RoundDeleteDAL deleteData = new RoundDeleteDAL();
            deleteData.Match = this.Match;
            return deleteData.Delete();
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
