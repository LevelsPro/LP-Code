using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class AwardUpdateBLL : Transaction
    {
        private Common.Award _award;

        public AwardUpdateBLL()
        {
        }
        public void Invoke()
        {
            AwardUpdateDAL updateData = new AwardUpdateDAL();
            updateData.Award = this.Award;
            updateData.Update();
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
