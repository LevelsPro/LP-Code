using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class DataElementUpdateDAL : DataAccessBase
    {
        private Common.Match _match;
        private DataElementUpdateDataParameters _insertParameters;

        public DataElementUpdateDAL() 
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateDataElement.ToString();
        }
        public void Update() 
        {
            _insertParameters = new DataElementUpdateDataParameters(Match);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Match Match
        {
            get { return _match; }
            set { _match = value; }
        }
    }
    public class DataElementUpdateDataParameters
    {
        private Common.Match _match;
        private MySqlParameter[] _parameters;

        public DataElementUpdateDataParameters(Common.Match match)
        {
            Match = match;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_MatchID", Match.MatchID),
                                              new MySqlParameter("?p_ElementID", Match.ElementID),
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
