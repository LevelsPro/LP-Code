using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class ContestLeaderBoardViewDAL : DataAccessBase
    {
        private Common.Contest _contestleaderboard;
        public ContestLeaderBoardViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContestLeaderBoard.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            ContestLeaderBoardViewDataParameters _viewParameters = new ContestLeaderBoardViewDataParameters(ContestLeaderBoard);
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

    public class ContestLeaderBoardViewDataParameters
    {
        private Common.Contest _contestleaderboard;
        private MySqlParameter[] _parameters;

        public ContestLeaderBoardViewDataParameters(Common.Contest contestleaderboard)
        {
            ContestLeaderBoard = contestleaderboard;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_Where", ContestLeaderBoard.Where)
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
