using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class ScoreManualUpdateBLL : Transaction
    {
        private Common.User _user;

        public ScoreManualUpdateBLL()
        {
        }
        public void Invoke()
        {
            ScoreManualUpdateDAL updateData = new ScoreManualUpdateDAL();
            updateData.User = this.User;
            updateData.Update();
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
