using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class PopupShowedUpdateDAL : DataAccessBase
    {
        private Common.User _user;
        private PopupShowedDataParameters _insertParameters;

        public PopupShowedUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateLevelperformance.ToString();
        }
        public void Update()
        {

            _insertParameters = new PopupShowedDataParameters(User);
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

    public class PopupShowedDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public PopupShowedDataParameters(Common.User user)
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
