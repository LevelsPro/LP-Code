using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class LifeLineInsertDAL:DataAccessBase
    {
        private Common.LifeLine _lifeline; // should be changed
        private LifeLineInsertDataParameters _insertParameters;

        public LifeLineInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertLifeLine.ToString();
        }

        public void Add()
        {

            _insertParameters = new LifeLineInsertDataParameters(Lifeline); //should be changed
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.LifeLine Lifeline //should be changed
        {
            get
            {
                return _lifeline;
            }
            set
            {
                _lifeline = value;
            }
        }
    }

    public class LifeLineInsertDataParameters
    {
        private Common.LifeLine _lifeline; // should be changed
        private MySqlParameter[] _parameters;

        public LifeLineInsertDataParameters(Common.LifeLine lifeline)
        {
            LifeLine = lifeline; //changed
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?UserID",LifeLine.UserID),
                                           new MySqlParameter("?QuizID",LifeLine.QuizID),
                                           new MySqlParameter("?DateUsed",LifeLine.DateUsed),
                                           new MySqlParameter("?ReduceChoices_LifeLine",LifeLine.ReduceChoices),
                                           new MySqlParameter("?ReplaceQuestion_LifeLine",LifeLine.ReplaceQuestion),
                                           new MySqlParameter("?AddCounter_LifeLine",LifeLine.AddCounter),
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
        public Common.LifeLine LifeLine
        {
            get
            {
                return _lifeline;
            }
            set
            {
                _lifeline = value;
            }
        }
    }
}
