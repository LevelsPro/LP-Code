using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ContestViewBLL : Transaction
    {
        private DataSet _resultSet;
        public ContestViewBLL()
        {
        }
        public void Invoke()
        {
            ContestViewDAL selectData = new ContestViewDAL();
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

    public class PlayerContestViewBLL : Transaction
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
