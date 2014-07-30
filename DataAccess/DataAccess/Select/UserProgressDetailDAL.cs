using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class UserProgressDetailDAL : DataAccessBase
    {

        private Common.User _userid;
        private UserProgressDetailParameters _viewParameters;
        public UserProgressDetailDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetUserProgressDetail.ToString();
        }
        public Common.User UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new UserProgressDetailParameters(UserID);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
        }
    }

    public class UserProgressDetailParameters
    {
        private Common.User _userid;
        private MySqlParameter[] _parameters;

        public UserProgressDetailParameters(Common.User userid)
        {
            _userid = userid;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",_userid.UserID)
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
        public Common.User UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }
    }
}
