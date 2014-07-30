using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class AwardInsertBLL
    {
        private Common.Award _award;
        public AwardInsertBLL()
        {
        }
        public int Invoke()
        {
            AwardInsertDAL insertData = new AwardInsertDAL();
            insertData.Award = this.Award;
            return insertData.Add();
        }

        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
