using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class ContestPlayersScoreDAL : DataAccessBase
    {
        private Common.Contest _contest;
        private ContestPlayersScoreParameters _viewParameters;

        public ContestPlayersScoreDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_Contest_PlayersScore.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new ContestPlayersScoreParameters(Contest);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;          
            
        }

        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }
    }

    public class ContestPlayersScoreParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestPlayersScoreParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ContestID",Contest.ContestID)
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
        public Common.Contest Contest
        {
            get
            {
                return _contest;
            }
            set
            {
                _contest = value;
            }
        }

    }
}
