using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class QuizDeleteDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuizDeleteDataParameters _deleteParameters;

        public QuizDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteQuiz.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new QuizDeleteDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
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

    public class QuizDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizDeleteDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_QuizID", Quiz.QuizID) };
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
