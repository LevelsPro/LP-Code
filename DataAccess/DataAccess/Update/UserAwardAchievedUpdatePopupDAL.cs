using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class UserAwardAchievedUpdatePopupDAL : DataAccessBase
    {
       private Common.User _user;
        private UserAwardAchievedDataParametersPopup _insertParameters;

        public UserAwardAchievedUpdatePopupDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_Update_UserAwardAchievedpopup.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserAwardAchievedDataParametersPopup(User);
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

    public class UserAwardAchievedDataParametersPopup
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserAwardAchievedDataParametersPopup(Common.User user)
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
