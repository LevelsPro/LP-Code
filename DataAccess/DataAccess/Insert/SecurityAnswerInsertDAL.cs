using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace DataAccess.Insert
{
    public class SecurityAnswerInsertDAL : DataAccessBase
    {
        private Common.User _user;
        private SecurityAnswerDataParameters _insertParameters;

        public SecurityAnswerInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertSecurityAnswersTemp.ToString();
        }
        public void Insert()
        {

            _insertParameters = new SecurityAnswerDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            int retu=dbHelper.Run(User.sqlTransaction, base.ConnectionString, _insertParameters.Parameters);          
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
    public class SecurityAnswerDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public SecurityAnswerDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                           new MySqlParameter("?p_UserID",User.UserID),
                                            new MySqlParameter("?p_Question",User.QuestionID),
                                            new MySqlParameter("?p_Answer",User.Answer),                                           
                                            new MySqlParameter("?p_Email",User.UserEmail),
                                            new MySqlParameter("?p_Password",User.UserPassword),
                                            new MySqlParameter("?p_SecurityType",User.Securitytype)
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
        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
