using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Duplicate;

namespace BusinessLogic.Insert
{
    public class ContestPositionInsertBLL : Transaction
    {

        private Common.Contest _contestposition;
        public ContestPositionInsertBLL()
        {
        }
        public void Invoke()
        {
            ContestPositionInsertDAL insertData = new ContestPositionInsertDAL();
            insertData.ContestPosition = this.ContestPosition;
            insertData.Add();
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
