using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class LifeLineInsertBLL
    {
        private Common.LifeLine _lifeline;
        public LifeLineInsertBLL()
        {
        }
        public void Invoke()
        {
            LifeLineInsertDAL insertData = new LifeLineInsertDAL();
            insertData.Lifeline = this.Lifeline;
            insertData.Add();
        }

        public Common.LifeLine Lifeline
        {
            get
            {
                return _lifeline;
            }
            set
            {
                _lifeline = value;
            }
        }
    }
}
