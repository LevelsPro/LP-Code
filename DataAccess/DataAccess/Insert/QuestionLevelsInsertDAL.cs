using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{   
    public class QuestionLevelsInsertDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuestionLevelsInsertDataParameters _insertParameters;

        public QuestionLevelsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuestionLevels.ToString();
        }
        public void Add()
        {

            _insertParameters = new QuestionLevelsInsertDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class QuestionLevelsInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionLevelsInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {   new MySqlParameter("?p_QuestionID",Quiz.QuestionID),
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
