using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class UpdatePopup_LevelPerformanceDAL:DataAccessBase
    {
        private Common.User _user;
        private UpdatePopupDataParameters _insertParameters;

        public UpdatePopup_LevelPerformanceDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevelperformance_PopupShowed.ToString();
        }
        public void Update()
        {

            _insertParameters = new UpdatePopupDataParameters(User);
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

    public class UpdatePopupDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UpdatePopupDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                          
                                            new MySqlParameter("?p_LevelID",User.CurrentLevel)                                          
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
