using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class PlayerContestViewBLL
    {
        private DataSet _resultSet;
        public PlayerContestViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerContestViewDAL selectData = new PlayerContestViewDAL();
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
