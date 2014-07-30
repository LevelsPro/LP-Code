using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class UserUpdateAdminDAL : DataAccessBase
    {
        private Common.User _user;
        private UserUpdateAdminDataParameters _insertParameters;

        public UserUpdateAdminDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateUser_Admin.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserUpdateAdminDataParameters(User);
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
    public class UserUpdateAdminDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserUpdateAdminDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                           new MySqlParameter("?p_UserID",User.UserID),
                                           //new MySqlParameter("?p_U_Name",User.UserName),
                                           new MySqlParameter("?p_U_FirstName",User.FirstName),
                                            new MySqlParameter("?p_U_LastName",User.UserLastName),
                                          new MySqlParameter("?p_U_NickName",User.UserNickName),
                                           new MySqlParameter("?p_U_Password",User.UserPassword),
                                           new MySqlParameter("?p_U_Email",User.UserEmail),
                                           new MySqlParameter("?p_U_SiteID",User.SiteID),
                                           new MySqlParameter("?p_U_SysRole",User.UserRoles),
                                           new MySqlParameter("?p_U_RolesID",User.RoleID),
                                           new MySqlParameter("?p_Active",User.Active), 
                                          new MySqlParameter("?p_ActiveUpdateStatus",User.ActiveUpdateStatus),  
                                           new MySqlParameter("?p_ManagerID",User.ManagerID) ,
                                           new MySqlParameter("?p_CurrentLevel",User.CurrentLevel),
                                          new MySqlParameter("?p_NextLevel",User.NextLevel),
                                           new MySqlParameter("?p_LastLevel",User.LastLevel),
                                           new MySqlParameter("?p_LevelAchieved",User.LevelAchieved),                                           
                                           new MySqlParameter("?p_previousLevel",User.PreviousLevel),
                                            new MySqlParameter("?p_Points",User.Score),
                                            new MySqlParameter("?p_Hours",User.Hours)
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
