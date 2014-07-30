using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class AwardImageInsertBLL : Transaction
    {
          private Common.Award _award;
        public AwardImageInsertBLL()
        {
        }
        public void Invoke()
        {
            AwardImageInsertDAL insertData = new AwardImageInsertDAL();
            insertData.Award = this.Award;
            insertData.Add();
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
