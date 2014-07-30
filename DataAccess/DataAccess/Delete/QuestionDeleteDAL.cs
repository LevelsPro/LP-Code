using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
    public class QuestionDeleteDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        private QuestionDeleteDataParameters _deleteParameters;

        public QuestionDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteQuestion.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new QuestionDeleteDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
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

    public class QuestionDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionDeleteDataParameters(Common.Quiz quiz)
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
