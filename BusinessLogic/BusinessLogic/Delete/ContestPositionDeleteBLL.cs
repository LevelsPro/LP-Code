using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class ContestPositionDeleteBLL
    {
        private Common.Contest _contestposition;
        public ContestPositionDeleteBLL()
        {
        }
        public object Invoke()
        {
            ContestPositionDeleteDAL deleteData = new ContestPositionDeleteDAL();
            deleteData.ContestPosition = this.ContestPosition;
            return deleteData.Delete();
        }

        public Common.Contest ContestPosition
        {
            get
            {
                return _contestposition;
            }
            set
            {
                _contestposition = value;
            }
        }
    }
}
