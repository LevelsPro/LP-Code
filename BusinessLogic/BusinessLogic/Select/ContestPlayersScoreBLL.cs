using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{   

    public class ContestPlayersScoreBLL : Transaction
    {
        private DataSet _resultSet;
        public ContestPlayersScoreBLL()
        {
        }

        public void Invoke()
        {
            ContestPlayersScoreDAL selectData = new ContestPlayersScoreDAL();
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
        private Common.Contest _contestid;
        public Common.Contest Contest
        {
            get
            {
                return _contestid;
            }
            set
            {
                _contestid = value;
            }
        }
    }
}
