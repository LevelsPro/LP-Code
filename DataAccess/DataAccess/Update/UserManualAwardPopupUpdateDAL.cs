 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
   
    public class UserManualAwardPopupUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private UserManualAwardPopupDataParameters _insertParameters;

        public UserManualAwardPopupUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateUserManualAward_Popup.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserManualAwardPopupDataParameters(User);
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

    public class UserManualAwardPopupDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserManualAwardPopupDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                          
                                            new MySqlParameter("?p_AwardID",User.AwardID)                                          
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
