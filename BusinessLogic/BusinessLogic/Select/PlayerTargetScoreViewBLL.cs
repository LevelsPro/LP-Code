using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   

    public class PlayerTargetScoreViewBLL : Transaction
    {

        private Common.User _user;
        private DataSet _resultSet;

        public PlayerTargetScoreViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerTargetScoreViewDAL updateData = new PlayerTargetScoreViewDAL();
            updateData.User = this.User;
            ResultSet = updateData.Update();
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
