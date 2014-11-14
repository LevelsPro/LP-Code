using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Duplicate
{
    public class ContestDuplicateDAL : DataAccessBase
    {
         private Common.Contest _contest;
         private ContestDuplicateDataParameters _insertParameters;

         public ContestDuplicateDAL()
        {
            StoredProcedureName = StoredProcedure.Duplicate.sp_DuplicateContest.ToString();
        }
        public void Add()
        {

            _insertParameters = new ContestDuplicateDataParameters(Contest);
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
    public class ContestDuplicateDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestDuplicateDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ContestID",Contest.ContestID)};
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
