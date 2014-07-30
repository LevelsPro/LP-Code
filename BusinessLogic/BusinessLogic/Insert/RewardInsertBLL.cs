using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class RewardInsertBLL 
    {
         private Common.Reward _reward;
         public RewardInsertBLL()
        {
        }
        public int Invoke()
        {
            RewardInsertDAL insertData = new RewardInsertDAL();
            insertData.Reward = this.Reward;
            return insertData.Add();
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
