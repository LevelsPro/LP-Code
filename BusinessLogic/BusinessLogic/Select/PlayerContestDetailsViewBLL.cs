using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{

    public class PlayerContestViewDetailBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Contest _contest;
        public PlayerContestViewDetailBLL()
        {
        }

        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }

        public void Invoke()
        {
            PlayerContestDetailsViewDAL selectData = new PlayerContestDetailsViewDAL();
            selectData.Contest = this.Contest;
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

