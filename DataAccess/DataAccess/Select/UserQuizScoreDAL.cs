using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class UserQuizScoreDAL : DataAccessBase
    {
        private Common.Quiz _quiz;
        public UserQuizScoreDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_UserQuizScore.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            UserQuizScoreParameters _viewParameters = new UserQuizScoreParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
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

    public class UserQuizScoreParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public UserQuizScoreParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
            
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?UserID",Quiz.RoleID)
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
