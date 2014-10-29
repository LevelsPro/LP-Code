using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class QuizLevelsInsertDAL : DataAccessBase
    {
         private Common.Quiz _quiz;
         private QuizLevelsInsertDataParameters _insertParameters;

        public QuizLevelsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuizLevels.ToString();
        }
        public void Add()
        {

            _insertParameters = new QuizLevelsInsertDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            int retu = dbHelper.Run(Quiz.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);
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
    public class QuizLevelsInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuizLevelsInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_QuizID",Quiz.QuizID),
                                              new MySqlParameter("?p_RoleID",Quiz.RoleID),
                                              new MySqlParameter("?p_LevelID",Quiz.LevelID)
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
