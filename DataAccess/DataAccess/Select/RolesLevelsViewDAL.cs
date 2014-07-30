using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class RolesLevelsViewDAL: DataAccessBase
    {
        private Common.Quiz _quiz;

        public RolesLevelsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_RolesLevels.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            QuestionRolesLevelsViewDataParameters _viewParameters = new QuestionRolesLevelsViewDataParameters(Quiz);
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
    public class QuestionRolesLevelsViewDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public QuestionRolesLevelsViewDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_QuestionID",Quiz.QuestionID)
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
