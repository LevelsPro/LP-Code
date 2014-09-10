using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class DataElementInsertDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataElementInsertDataParameters _insertParameters;

        public DataElementInsertDAL() 
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertDataElement.ToString();
        }
        public void Add() 
        {
            _insertParameters = new DataElementInsertDataParameters(Match);
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

    public class DataElementInsertDataParameters 
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataElementInsertDataParameters(Common.Match match) 
        {
            Match = match;
            Build();
        }
        public void Build() 
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID", Match.MatchID),
                                              new MySqlParameter("?p_ElementName", Match.ElementName),
                                              new MySqlParameter("?p_IsPicture", Match.IsPicture)
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
