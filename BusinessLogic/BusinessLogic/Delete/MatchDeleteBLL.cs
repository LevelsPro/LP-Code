using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class MatchDeleteBLL
    {
        private Common.Match _match;
        public MatchDeleteBLL()
        {
        }
        public object Invoke()
        {
            MatchDeleteDAL deleteData = new MatchDeleteDAL();
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
