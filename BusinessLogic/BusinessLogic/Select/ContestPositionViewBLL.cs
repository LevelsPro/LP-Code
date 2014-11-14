using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ContestPositionViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Contest _contestposition;
        public ContestPositionViewBLL()
        {
        }
        public void Invoke()
        {
            ContestPositionViewDAL selectData = new ContestPositionViewDAL();
            selectData.ContestPosition = ContestPosition;
            ResultSet = selectData.View();
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
        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
            }
        }
    }
}
