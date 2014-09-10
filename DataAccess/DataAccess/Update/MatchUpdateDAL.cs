using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class MatchUpdateDAL : DataAccessBase
    {
        private Common.Match _match;
        private MatchUpdateDataParameters _insertParameters;

        public MatchUpdateDAL() 
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateMatch.ToString();
        }
        public void Update() 
        {
            _insertParameters = new MatchUpdateDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Match Match
        {
            get { return _match; }
            set { _match = value; }
        }
    }
    public class MatchUpdateDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchUpdateDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID", Match.MatchID),
                                              new MySqlParameter("?p_MatchName", Match.MatchName),
                                              new MySqlParameter("?p_PointsForCompletation", Match.PointsForCompletation),
                                              new MySqlParameter("?p_MaxPlaysPerDay", Match.MaxPlaysPerDay),
                                              new MySqlParameter("?p_NoOfDataSet", Match.NoOfDataSet),
                                              new MySqlParameter("?p_NoOfRounds", Match.NoOfRounds),
                                              new MySqlParameter("?p_PointsPerRound", Match.PointsPerRound),
                                              new MySqlParameter("?p_TimePerRound", Match.TimePerRound),
                                              new MySqlParameter("?p_MatchImage", Match.MatchImage),
                                              new MySqlParameter("?p_MatchImageThumbnail", Match.MatchImageThumbnail),
                                              new MySqlParameter("?p_KPIID",Match.KPIID)
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
