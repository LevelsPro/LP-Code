using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   
    public class RewardImageInsertBLL : Transaction
    {
        private Common.Reward _reward;
        public RewardImageInsertBLL()
        {
        }
        public void Invoke()
        {
            RewardImageInsertDAL insertData = new RewardImageInsertDAL();
            insertData.Reward = this.Reward;
            insertData.Add();
        }

        public Common.Reward Reward
        {
            get
            {
                return _reward;
            }
            set
            {
                _reward = value;
            }
        }
    }
}
