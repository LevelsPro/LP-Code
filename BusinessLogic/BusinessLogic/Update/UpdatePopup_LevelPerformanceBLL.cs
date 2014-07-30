using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class UpdatePopup_LevelPerformanceBLL:Transaction
    {
        private Common.User _user;

        public UpdatePopup_LevelPerformanceBLL()
        {
        }
        public void Invoke()
        {
            UpdatePopup_LevelPerformanceDAL updateData = new UpdatePopup_LevelPerformanceDAL();
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
