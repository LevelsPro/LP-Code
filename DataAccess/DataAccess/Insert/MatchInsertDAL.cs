﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Insert
{
    public class MatchInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private MatchInsertDataParameters _insertParameters;

        public MatchInsertDAL() 
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMatch.ToString();
        }
        public void Add() 
        {

            _insertParameters = new MatchInsertDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            
            Match.MatchID = Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[8]).Value);
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
    public class MatchInsertDataParameters 
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public MatchInsertDataParameters(Common.Match match) 
        {
            Match = match;
            Build();
        }
        public void Build() 
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchName", Match.MatchName),
                                              new MySqlParameter("?p_PointsForCompletation", Match.PointsForCompletation),
                                              new MySqlParameter("?p_MaxPlaysPerDay", Match.MaxPlaysPerDay),
                                              new MySqlParameter("?p_NoOfDataSet", Match.NoOfDataSet),
                                              new MySqlParameter("?p_NoOfRounds", Match.NoOfRounds),
                                              new MySqlParameter("?p_MatchImage", Match.MatchImage),
                                              new MySqlParameter("?p_MatchImageThumbnail", Match.MatchImageThumbnail),
                                              new MySqlParameter("?p_KPIID",Match.KPIID),
                                              new MySqlParameter("?p_Mid", MySqlDbType.Int16, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, Match.MatchID)
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
