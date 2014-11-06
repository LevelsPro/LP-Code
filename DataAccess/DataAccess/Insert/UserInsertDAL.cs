using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class UserInsertDAL : DataAccessBase
    {
        private Common.User _user;
        private UserInsertDataParameters _insertParameters;

        public UserInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertUser.ToString();
        }
        public void Insert()
        {

            _insertParameters = new UserInsertDataParameters(User);
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
    public class UserInsertDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserInsertDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                            new MySqlParameter("?p_U_EmpID",User.EmployeeID),
                                            new MySqlParameter("?p_U_Name",User.UserName),
                                            new MySqlParameter("?p_U_FirstName",User.FirstName),
                                            new MySqlParameter("?p_U_LastName",User.UserLastName),
                                            new MySqlParameter("?p_U_NickName",User.UserNickName),
                                            new MySqlParameter("?p_U_Password",User.UserPassword),
                                            new MySqlParameter("?p_U_Email",User.UserEmail),
                                            new MySqlParameter("?p_U_SiteID",User.SiteID),
                                            new MySqlParameter("?p_U_SysRole",User.UserRoles),
                                            new MySqlParameter("?p_U_RolesID",User.RoleID),
                                            new MySqlParameter("?p_Active",User.Active),
                                            new MySqlParameter("?p_ManagerID",User.ManagerID) , 
                                           
                                            new MySqlParameter("?p_CurrentLevel",User.CurrentLevel),
                                            new MySqlParameter("?p_NextLevel",User.NextLevel),
                                            new MySqlParameter("?p_LastLevel",User.LastLevel),
                                            new MySqlParameter("?p_LevelAchieved",User.LevelAchieved)
                                           
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
