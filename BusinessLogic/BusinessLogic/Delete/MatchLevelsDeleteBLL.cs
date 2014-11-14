using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
   public class MatchLevelsDeleteBLL : Transaction
    {
        private Common.Match _match;
        public MatchLevelsDeleteBLL()
        {
        }
    public void Invoke()
        {
            MatchLevelsDeleteDAL derleteData = new MatchLevelsDeleteDAL();
            derleteData.Match = this.Match;
            derleteData.Delete();
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
