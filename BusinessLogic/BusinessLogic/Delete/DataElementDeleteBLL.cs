using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class DataElementDeleteBLL
    {
        private Common.Match _match;
        public DataElementDeleteBLL()
        {
        }
        public object Invoke()
        {
            DataElementDeleteDAL deleteData = new DataElementDeleteDAL();
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
