using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class QuizScoreDeleteDAL : DataAccessBase
    {
       private Common.Quiz _quiz;
        private QuizScoreDeleteDataParameters _deleteParameters;

        public QuizScoreDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteUserScore.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new QuizScoreDeleteDataParameters(Quiz);
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

    public class QuizScoreDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizScoreDeleteDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID", Quiz.UserID) };
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
