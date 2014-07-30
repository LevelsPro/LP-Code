using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class RewardUpdateBLL : Transaction
    {
        private Common.Reward _reward;

        public RewardUpdateBLL()
        {
        }
        public void Invoke()
        {
            RewardUpdateDAL updateData = new RewardUpdateDAL();
            updateData.Reward = this.Reward;
            updateData.Update();
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
