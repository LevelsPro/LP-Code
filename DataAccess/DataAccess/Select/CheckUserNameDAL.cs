using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class CheckUserNameDAL : DataAccessBase
    {
        private Common.User _user;
        private CheckUserNameDataParameters _viewParameters;

        public CheckUserNameDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_CheckUserName.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new CheckUserNameDataParameters(User);
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

    public class CheckUserNameDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public CheckUserNameDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_U_Name",User.UserName)
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
