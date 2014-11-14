using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Duplicate
{
    public class ContestPositionInsertDAL : DataAccessBase
    {
         private Common.Contest _contestposition;
         private ContestPositionInsertDataParameters _insertParameters;

         public ContestPositionInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertContestPosition.ToString();
        }
        public void Add()
        {

            _insertParameters = new ContestPositionInsertDataParameters(ContestPosition);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class ContestPositionInsertDataParameters
    {
        private Common.Contest _contestposition;
        private MySqlParameter[] _parameters;

        public ContestPositionInsertDataParameters(Common.Contest contestposition)
        {
            ContestPosition = contestposition;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ContestID",ContestPosition.ContestID),                                          
                                          new MySqlParameter("?p_Award_ID",ContestPosition.AwardID),
                                          new MySqlParameter("?p_Position",ContestPosition.Position),
                                          new MySqlParameter("?p_Points",ContestPosition.Points)};
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
