using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class QuizLevelsDeleteDAL : DataAccessBase
    {
       private Common.Quiz _quiz;
        private QuizLevelsDeleteDataParameters _deleteParameters;

        public QuizLevelsDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteQuizLevels.ToString();
        }
        public void Delete()
        {
            _deleteParameters = new QuizLevelsDeleteDataParameters(Quiz);
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

    public class QuizLevelsDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizLevelsDeleteDataParameters(Common.Quiz quiz)
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
