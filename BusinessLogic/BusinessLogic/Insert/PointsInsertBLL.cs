using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class PointsInsertBLL : Transaction
    {
        private Common.Points _points;
        public PointsInsertBLL()
        {
        }
        public void Invoke()
        {
            PointsInsertDAL insertData = new PointsInsertDAL();
            insertData.Points = this.Points;
            insertData.Add();
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
    }
}
