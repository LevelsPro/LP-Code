using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class ContestDeleteDAL : DataAccessBase
    {
        private Common.Contest _contest;
        private ContestDeleteDataParameters _deleteParameters;

        public ContestDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteContest.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new ContestDeleteDataParameters(Contest);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
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

    public class ContestDeleteDataParameters
    {
        private Common.Contest _contest;
        private MySqlParameter[] _parameters;

        public ContestDeleteDataParameters(Common.Contest contest)
        {
            Contest = contest;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ContestID", Contest.ContestID) };
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
