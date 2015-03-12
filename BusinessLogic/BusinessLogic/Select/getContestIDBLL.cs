using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class getContestIDBLL : Transaction
    {
         private DataSet _resultSet;
         private Common.KPI _kpi;

         public getContestIDBLL()
        {
        }
        public void Invoke()
        {
            getContestIDDAL selectData = new getContestIDDAL();
            selectData.KPI = this.KPI;
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
        public Common.KPI KPI
        {
            get
            {
                return _kpi;
            }
            set
            {
                _kpi = value;
            }
        }
    }
}
