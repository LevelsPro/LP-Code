using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{

    public class LevelPerformanceViewBLL : Transaction
    {
        private DataSet _resultSet;
        public LevelPerformanceViewBLL()
        {
        }
        public void Invoke()
        {
            LevelPerformanceViewDAL selectData = new LevelPerformanceViewDAL();
            ResultSet = selectData.View();
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
