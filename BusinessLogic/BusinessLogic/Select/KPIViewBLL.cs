using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  public  class KPIViewBLL : Transaction
    {
        private DataSet _resultSet;
        public KPIViewBLL()
        {
        }
        public void Invoke()
        {
            KPIViewDAL selectData = new KPIViewDAL();
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
