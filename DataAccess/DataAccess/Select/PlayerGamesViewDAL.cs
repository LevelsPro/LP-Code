using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
   
    public class PlayerGamesViewDAL : DataAccessBase
    {
        private Common.Match _match;
        private PlayersGamesQuestionsDataParameters _viewParameters;

        public PlayerGamesViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetGames_Player.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new PlayersGamesQuestionsDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

        }

        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
    public class PlayersGamesQuestionsDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public PlayersGamesQuestionsDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LevelID",Match.LevelID),
                                                  new MySqlParameter("?p_RoleID",Match.RoleID)
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
        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
}
