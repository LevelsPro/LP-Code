using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
  public  class MatchScoreDeleteBLL 
    {
      private Common.Match _match;
      public MatchScoreDeleteBLL()
        {
        }
        public object Invoke()
        {
            MatchScoreDeleteDAL deleteData = new MatchScoreDeleteDAL();
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
