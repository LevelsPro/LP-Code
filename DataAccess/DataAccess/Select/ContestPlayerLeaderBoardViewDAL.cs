using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class ContestPlayerLeaderBoardViewDAL : DataAccessBase
    {
        private Common.Contest _contestleaderboard;
        public ContestPlayerLeaderBoardViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContestPlayerLeaderBoard.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            ContestPlayerLeaderBoardViewDataParameters _viewParameters = new ContestPlayerLeaderBoardViewDataParameters(ContestLeaderBoard);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);

            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
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
    }

    public class ContestPlayerLeaderBoardViewDataParameters
    {
        private Common.Contest _contestleaderboard;
        private MySqlParameter[] _parameters;

        public ContestPlayerLeaderBoardViewDataParameters(Common.Contest contestleaderboard)
        {
            ContestLeaderBoard = contestleaderboard;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ContestID", ContestLeaderBoard.ContestID),
                                            new MySqlParameter("?p_UserID", ContestLeaderBoard.UserID)
                                          };
            Parameters = parameters;
        }
        public MySqlParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
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
    }
}
