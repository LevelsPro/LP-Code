using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class QuizPlayLogDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuizPlayInsertDataParameters _insertParameters;

        public QuizPlayLogDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuizPlayLog.ToString();
        }

        public void Add()
        {

            _insertParameters = new QuizPlayInsertDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }

    public class QuizPlayInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizPlayInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?UserID",Quiz.UserID),
                                              new MySqlParameter("?QuizID",Quiz.QuizID),
                                               new MySqlParameter("?QuizTime",Quiz.QuizTime)
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
        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }
}
