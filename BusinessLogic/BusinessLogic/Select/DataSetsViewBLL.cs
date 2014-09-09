using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    
    public class DataSetViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Match _match;
        public DataSetViewBLL()
        {
        }
        public void Invoke()
        {
            DataSetViewDAL selectData = new DataSetViewDAL();
            selectData.Match = Match;
            ResultSet = selectData.View();
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
