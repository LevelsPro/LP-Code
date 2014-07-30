using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class CheckPasswordNullDAL : DataAccessBase
    {
         private Common.User _user;
         private CheckPasswordNullDataParameters _viewParameters;

        public CheckPasswordNullDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_CheckPasswordNull.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new CheckPasswordNullDataParameters(User);
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

    public class CheckPasswordNullDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public CheckPasswordNullDataParameters(Common.User user)
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
