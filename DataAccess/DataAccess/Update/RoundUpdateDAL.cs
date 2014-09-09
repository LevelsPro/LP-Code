using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class RoundUpdateDAL : DataAccessBase
    {
        private Common.Match _match;
        private RoundUpdateDataParameters _insertParameters;

        public RoundUpdateDAL() 
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateRound.ToString();
        }
        public void Update() 
        {
            _insertParameters = new RoundUpdateDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Match Match
        {
            get { return _match; }
            set { _match = value; }
        }
    }
    public class RoundUpdateDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public RoundUpdateDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID", Match.MatchID),
                                              new MySqlParameter("?p_RoundID", Match.RoundID),
                                              new MySqlParameter("?p_RoundNumber", Match.NoRound),
                                              new MySqlParameter("?p_RoundName", Match.RoundName),
                                              new MySqlParameter("?p_NoOfDataSets", Match.NoDataSetPerRound),
                                              new MySqlParameter("?p_TimePerRound", Match.TimePerRound),
                                              new MySqlParameter("?p_PointsPerRound", Match.PointsPerRound),
                                              new MySqlParameter("?p_ShowHint", Match.ShowHint)
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
