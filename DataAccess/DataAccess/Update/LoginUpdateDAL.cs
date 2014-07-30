using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public class LoginUpdateDAL : DataAccessBase
    {
       private Common.User _user;
        private LoginUpdateDataParameters _insertParameters;

        public LoginUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLoginTime.ToString();
        }
        public void Update()
        {

            _insertParameters = new LoginUpdateDataParameters(Users);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

        }

         public Common.User Users
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
    public class LoginUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public LoginUpdateDataParameters(Common.User users)
        {
            Users = users;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_userid", Users.UserID) };
            
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
       public Common.User Users
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
