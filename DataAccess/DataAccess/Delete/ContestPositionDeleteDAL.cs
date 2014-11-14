using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class ContestPositionDeleteDAL : DataAccessBase
    {
        private Common.Contest _contestposition;
        private ContestPositionDeleteDataParameters _deleteParameters;

        public ContestPositionDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteContestPosition.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new ContestPositionDeleteDataParameters(ContestPosition);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.Contest ContestPosition
        {
            get
            {
                return _contestposition;
            }
            set
            {
                _contestposition = value;
            }
        }
    }

    public class ContestPositionDeleteDataParameters
    {
        private Common.Contest _contestposition;
        private MySqlParameter[] _parameters;

        public ContestPositionDeleteDataParameters(Common.Contest contestposition)
        {
            ContestPosition = contestposition;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ContestID", ContestPosition.ContestID)};
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
        public Common.Contest ContestPosition
        {
            get
            {
                return _contestposition;
            }
            set
            {
                _contestposition = value;
            }
        }
    }
}
