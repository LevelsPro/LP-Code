using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class ContestPerformanceInsertDAL : DataAccessBase
    {
        private Common.Contest _contest;
        private ContestPerformanceInsertDataParameters _insertParameters;

        public ContestPerformanceInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertContestPerformance.ToString();
        }
        public void Add()
        {

            _insertParameters = new ContestPerformanceInsertDataParameters(Contest);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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

    public class ContestPerformanceInsertDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestPerformanceInsertDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_contestid",Contest.ContestID),
                                           new MySqlParameter("?p_userid",Contest.UserID),
                                           new MySqlParameter("?p_kpiid",Contest.KPIID),
                                           new MySqlParameter("?p_score",Contest.Points),
                                           new MySqlParameter("?p_importdate",Contest.EntryDate)
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
