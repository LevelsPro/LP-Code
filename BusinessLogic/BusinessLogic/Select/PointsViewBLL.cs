using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   public class PointsViewBLL :Transaction
    {
        private DataSet _resultSet;
        public PointsViewBLL()
        {
        }
        public void Invoke()
        {
            PointsViewDAL selectData = new PointsViewDAL();
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
