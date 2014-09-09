using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class RoundInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private RoundInsertDataParameters _insertParameters;

        public RoundInsertDAL() 
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertRound.ToString();
        }
        public void Add() 
        {
            _insertParameters = new RoundInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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

    public class RoundInsertDataParameters 
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public RoundInsertDataParameters(Common.Match match) 
        {
            Match = match;
            Build();
        }
        public void Build() 
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID", Match.MatchID),
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
