using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class KPIUpdateBLL : Transaction
    {
        private Common.KPI _kpi;

        public KPIUpdateBLL()
        {
        }
        public void Invoke()
        {
            KPIUpdateDAL updateData = new KPIUpdateDAL();
            updateData.KPI = this.KPI;
            updateData.Update();
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
