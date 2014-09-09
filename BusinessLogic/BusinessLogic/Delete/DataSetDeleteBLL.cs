using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{    
    public class DataSetDeleteBLL
    {
        private Common.Match _match;
        public DataSetDeleteBLL()
        {
        }
        public object Invoke()
        {
            DataSetDeleteDAL deleteData = new DataSetDeleteDAL();
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
