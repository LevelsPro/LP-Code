using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
   public class DataSetLevelDeleteBLL 
    {
       private Common.Match _match;
       public DataSetLevelDeleteBLL()
        {
        }
    public void Invoke()
        {
            DataSetLevelDeleteDAL deleteData = new DataSetLevelDeleteDAL();
            deleteData.Match = this.Match;
            deleteData.Delete();
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
