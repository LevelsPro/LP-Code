using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class UserEditUpdateDAL : DataAccessBase
    {
      private Common.User _user;
      private UserUpdateEditDataParameters _insertParameters;

        public UserEditUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateUser.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserUpdateEditDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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
  public class UserUpdateEditDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserUpdateEditDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                         
                                          new MySqlParameter("?p_UserID",User.UserID),
                                           new MySqlParameter("?p_UserName",User.FirstName),                                            
                                          new MySqlParameter("?p_UserLastName",User.UserLastName),
                                           new MySqlParameter("?p_UserNickName",User.UserNickName),
                                           new MySqlParameter("?p_DisplayName",User.DisplayName)
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
