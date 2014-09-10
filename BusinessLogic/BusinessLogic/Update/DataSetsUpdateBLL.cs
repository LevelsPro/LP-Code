using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class DataSetUpdateBLL : Transaction
    {

        private Common.Match _match;
        public DataSetUpdateBLL()
        {
        }
        public void Invoke()
        {
            DataSetUpdateDAL updateData = new DataSetUpdateDAL();
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
