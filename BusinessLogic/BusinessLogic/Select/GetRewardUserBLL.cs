using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   public class GetRewardUserBLL : Transaction
    {
         private DataSet _resultSet;
        private Common.Reward _userreward;
        public GetRewardUserBLL()
        {
        }
        public void Invoke()
        {
            GetRewardUserDAL selectData = new GetRewardUserDAL();
            selectData.UserRewards = UserRewards;
            ResultSet = selectData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
            }
        }

        public Common.Reward UserRewards
        {
            get
            {
                return _userreward;
            }
            set
            {
                _userreward = value;
            }
        }
    }
}
