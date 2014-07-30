using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class CheckPasswordDAL : DataAccessBase
    {
        private Common.User _user;
        private CheckPasswordDataParameters _viewParameters;

        public CheckPasswordDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_CheckPassword.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new CheckPasswordDataParameters(User);
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

    public class CheckPasswordDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public CheckPasswordDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),
                                            new MySqlParameter("?p_Password",User.UserPassword)
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
