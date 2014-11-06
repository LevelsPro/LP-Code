using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class UserUpdateDAL : DataAccessBase
    {
      private Common.User _user;
        private UserUpdateDataParameters _insertParameters;

        public UserUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateUser_Admin.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserUpdateDataParameters(User);
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
    public class UserUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserUpdateDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),
                                            
                                            new MySqlParameter("?p_RoleID",User.RoleID),
                                            new MySqlParameter("?p_UserLastName",User.UserPassword),
                                            new MySqlParameter("?p_UserNickName",User.UserEmail),
                                            new MySqlParameter("?p_UserLocation",User.SiteID),
                                            new MySqlParameter("?p_FbUserID",User.UserFbID),
                                            new MySqlParameter("?p_FbPassword",User.UserFbPassword),
                                            new MySqlParameter("?p_TwUserID",User.UserTwID),
                                            new MySqlParameter("?p_TwPassword",User.UserTwPassword),
                                            new MySqlParameter("?p_UserName",User.FirstName),                                            
                                            new MySqlParameter("?p_UserLastName",User.UserLastName),
                                            new MySqlParameter("?p_UserNickName",User.UserNickName),
                                            new MySqlParameter("?p_Status",User.Active)
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
