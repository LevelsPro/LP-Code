using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
    public class RewardImageDeleteBLL
    {
        private Common.Reward _reward;
        public RewardImageDeleteBLL()
        {
        }
        public object Invoke()
        {
            RewardImageDeleteDAL derleteData = new RewardImageDeleteDAL();
            derleteData.Reward = this._reward;
            return derleteData.Delete();
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
