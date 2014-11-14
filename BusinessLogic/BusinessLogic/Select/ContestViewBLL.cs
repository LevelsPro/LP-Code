using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ContestViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Contest _contest;
        public ContestViewBLL()
        {
        }
        public void Invoke()
        {
            ContestViewDAL selectData = new ContestViewDAL();
            selectData.Contest = Contest;
            ResultSet = selectData.View();
        }
        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
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
