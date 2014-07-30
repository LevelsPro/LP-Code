using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{  

    public class PlayerQuizQuestionsViewDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private PlayerQuizQuestionsDataParameters _viewParameters;

        public PlayerQuizQuestionsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetQuizQuestion_Player.ToString();
        }
        public DataSet Update()
        {
            DataSet ds;
            _viewParameters = new PlayerQuizQuestionsDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

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
    public class PlayerQuizQuestionsDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public PlayerQuizQuestionsDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_QuizID",Quiz.QuizID), 
                                              new MySqlParameter("?p_LevelID",Quiz.LevelID),
                                                  new MySqlParameter("?p_RoleID",Quiz.RoleID)
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
