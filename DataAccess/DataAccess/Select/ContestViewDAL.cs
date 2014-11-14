using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{

    public class ContestViewDAL : DataAccessBase
    {
        private Common.Contest _contest;
        public ContestViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContest.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            ContestViewDataParameters _viewParameters = new ContestViewDataParameters(Contest);
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

    public class ContestViewDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestViewDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_Where", Contest.Where)
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
