using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{   
    public class QuestionLevelsViewDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        public QuestionLevelsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetQuestionLevels.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            QuestionLevelsViewDataParameters _viewParameters = new QuestionLevelsViewDataParameters(Quiz);
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

    public class QuestionLevelsViewDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionLevelsViewDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_QuestionID",Quiz.QuestionID),
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
