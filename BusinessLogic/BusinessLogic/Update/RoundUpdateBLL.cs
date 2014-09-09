using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class RoundUpdateBLL : Transaction
    {
         private Common.Match _match;
         public RoundUpdateBLL()
        {
        }
        public void Invoke()
        {
            RoundUpdateDAL updateData = new RoundUpdateDAL();
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
