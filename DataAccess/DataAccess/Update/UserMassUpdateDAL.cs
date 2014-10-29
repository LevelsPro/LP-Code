using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   public class UserMassUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private UserUpdateMassDataParameters _insertParameters;

        public UserMassUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateUserMass.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserUpdateMassDataParameters(User);
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
    public class UserUpdateMassDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserUpdateMassDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { 
                                           new MySqlParameter("?p_UserID",User.UserID),
                                           new MySqlParameter("?p_CurrentLevel",User.CurrentLevel),
                                           new MySqlParameter("?p_NextLevel",User.NextLevel),
                                           new MySqlParameter("?p_SiteID",User.SiteID),
                                           new MySqlParameter("?p_SysRole",User.UserRoles),
                                           new MySqlParameter("?p_RolesID",User.RoleID),
                                           new MySqlParameter("?p_Active",User.Active),  
                                           new MySqlParameter("?p_ManagerID",User.ManagerID)  
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
