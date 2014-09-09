using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{  

    public class PlayerMatchDataSetsViewDAL : DataAccessBase
    {
        private Common.Match _match;
        private PlayerMatchDataSetsDataParameters _viewParameters;

        public PlayerMatchDataSetsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetMatchDataSet_Player.ToString();
        }
        public DataSet Update()
        {
            DataSet ds;
            _viewParameters = new PlayerMatchDataSetsDataParameters(Match);
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
    public class PlayerMatchDataSetsDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public PlayerMatchDataSetsDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                              new MySqlParameter("?p_MatchID",Match.MatchID),
                                              new MySqlParameter("?p_LevelID",Match.LevelID),
                                              new MySqlParameter("?p_RoleID",Match.RoleID),
                                              new MySqlParameter("?p_RoundNumber",Match.NoRound),
                                              new MySqlParameter("?p_NoDataSets",Match.NoDataSetPerRound),
                                              new MySqlParameter("?p_DataElements", Match.NoOfDataSet)
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
