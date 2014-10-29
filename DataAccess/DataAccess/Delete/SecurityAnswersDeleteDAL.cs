using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{
  public  class SecurityAnswersDeleteDAL : DataAccessBase
    {
      private Common.Quiz _quiz;
        private SecurityAnswersDeleteDataParameters _deleteParameters;

        public SecurityAnswersDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteSecurityAnswers.ToString();
        }
        public object Delete()
        {
            _deleteParameters = new SecurityAnswersDeleteDataParameters(Quiz);
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

    public class SecurityAnswersDeleteDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public SecurityAnswersDeleteDataParameters(Common.Quiz quiz)
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
