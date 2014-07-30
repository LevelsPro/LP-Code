using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class PlayerRewardViewBLL
    {
        private DataSet _resultSet;
        public PlayerRewardViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerRewardViewDAL selectData = new PlayerRewardViewDAL();
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
    }
}
