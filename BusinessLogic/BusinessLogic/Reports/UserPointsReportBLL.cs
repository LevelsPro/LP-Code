using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Reports;
using System.Data;

namespace BusinessLogic.Reports
{
   public class UserPointsReportBLL : Transaction
    {
        private Common.Points _points;
        private DataSet _sum;
        
        public UserPointsReportBLL()
        {
        }
        public void Invoke()
        {
            UserPointsReportDAL reportData = new UserPointsReportDAL();
            reportData.Points = this.Points;
           Sum =reportData.Add();
        }

        public Common.Points Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }

        public DataSet Sum
        {
            get
            {
                return _sum;
            }
            set
            {
                _sum = value;
            }
        }
    }
}
