using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class QuizScoreInsertDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuizInsertDataParameters _insertParameters;

        public QuizScoreInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuizScore.ToString();
        }
        public void Add()
        {

            _insertParameters = new QuizInsertDataParameters(Quiz);
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
    public class QuizInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",Quiz.UserID),
                                              new MySqlParameter("?p_QuizID",Quiz.QuizID),
                                              new MySqlParameter("?p_QuestionID",Quiz.QuestionID),
                                              new MySqlParameter("?p_Points",Quiz.AchievedPoints),
                                              new MySqlParameter("?p_ElapsedTime",Quiz.Elapsed),
                                              new MySqlParameter("?p_IsCorrect",Quiz.IsCorrect)
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
