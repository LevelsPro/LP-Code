using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class CheckSecurityAnswersDAL : DataAccessBase
    {
        private Common.User _user;
        private CheckSecurityAnswersDataParameters _viewParameters;

        public CheckSecurityAnswersDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_CheckSecurityAnswer.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new CheckSecurityAnswersDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
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

    public class CheckSecurityAnswersDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public CheckSecurityAnswersDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID)                                              
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
