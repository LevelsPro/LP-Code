using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ContestPositionListViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Contest _contestpositionlist;
        public ContestPositionListViewBLL()
        {
        }
        public void Invoke()
        {
            ContestPositionListViewDAL selectData = new ContestPositionListViewDAL();
            selectData.ContestPositionList = ContestPositionList;
            ResultSet = selectData.View();
        }
        public Common.Contest ContestPositionList
        {
            get
            {
                return _contestpositionlist;
            }
            set
            {
                _contestpositionlist = value;
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
