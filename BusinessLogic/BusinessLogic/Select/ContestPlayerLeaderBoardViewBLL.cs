using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ContestPlayerLeaderBoardViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Contest _contestleaderboard;
        public ContestPlayerLeaderBoardViewBLL()
        {
        }
        public void Invoke()
        {
            ContestPlayerLeaderBoardViewDAL selectData = new ContestPlayerLeaderBoardViewDAL();
            selectData.ContestLeaderBoard = ContestLeaderBoard;
            ResultSet = selectData.View();
        }
        public Common.Contest ContestLeaderBoard
        {
            get
            {
                return _contestleaderboard;
            }
            set
            {
                _contestleaderboard = value;
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
