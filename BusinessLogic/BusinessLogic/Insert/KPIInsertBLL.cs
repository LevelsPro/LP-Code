using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class KPIInsertBLL : Transaction
    {
        private Common.KPI _kpi;
        public KPIInsertBLL()
        {
        }
        public void Invoke()
        {
            KPIInsertDAL insertData = new KPIInsertDAL();
            insertData.KPI = this.KPI;
            insertData.Add();
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
