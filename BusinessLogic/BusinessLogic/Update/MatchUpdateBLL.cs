using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class MatchUpdateBLL : Transaction
    {
         private Common.Match _match;
        public MatchUpdateBLL()
        {
        }
        public void Invoke()
        {
            MatchUpdateDAL updateData = new MatchUpdateDAL();
            updateData.Match = this.Match;
            updateData.Update();
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
