using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  public  class PlayerPointsViewBLL
    {
       private Common.Points _points;
      
        private DataSet _sum;
      
        public PlayerPointsViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerPointsViewDAL reportData = new PlayerPointsViewDAL();
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
