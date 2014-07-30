using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class GetPopupShowed_LevelPerformanceBLL
    {
        private DataSet _resultSet;

        public GetPopupShowed_LevelPerformanceBLL()
        {
        }

        public void Invoke()
        {
            GetPopupShowed_LevelPerformanceDAL selectData = new GetPopupShowed_LevelPerformanceDAL();
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
