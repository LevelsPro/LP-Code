using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
 public   class QuizResultInsertDAL : DataAccessBase
    {
     private Common.Quiz _quiz;
         private QuizResultInsertDataParameters _insertParameters;

         public QuizResultInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuizResult.ToString();
        }
        public void Add()
        {

            _insertParameters = new QuizResultInsertDataParameters(Quiz);
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
    public class QuizResultInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizResultInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_userid",Quiz.UserID),
                                           new MySqlParameter("?p_quizid",Quiz.QuizID),
                                           new MySqlParameter("?p_total",Quiz.Total),
                                           new MySqlParameter("?p_KPI",Quiz.KPIID)
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
