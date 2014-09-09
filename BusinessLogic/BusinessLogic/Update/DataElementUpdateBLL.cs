using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class DataElementUpdateBLL : Transaction
    {
         private Common.Match _match;
         public DataElementUpdateBLL()
        {
        }
        public void Invoke()
        {
            DataElementUpdateDAL updateData = new DataElementUpdateDAL();
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
