using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public class QuestionLevelDeleteDAL : DataAccessBase
    {
      private Common.Quiz _quiz;
        private QuizLevelDeleteDataParameters _deleteParameters;

        public QuestionLevelDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteQuestionLevel.ToString();
        }
        public void Delete()
        {
            _deleteParameters = new QuizLevelDeleteDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            int retu = dbHelper.Run(Quiz.sqlTransaction, base.ConnectionString, _deleteParameters.Parameters);
          
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

    public class QuizLevelDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizLevelDeleteDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_QuestionID", Quiz.QuestionID) };
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
