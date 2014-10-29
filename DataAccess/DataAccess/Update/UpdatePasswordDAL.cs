using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class UpdatePasswordDAL : DataAccessBase
    {
        private Common.User _user;
        private UpdatePasswordDataParameters _updateParameters;

        public UpdatePasswordDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdatePassword.ToString();
        }
        public void Update()
        {

            _updateParameters = new UpdatePasswordDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            int retu = dbHelper.Run(User.sqlTransaction, base.ConnectionString, _updateParameters.Parameters); 

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

    public class UpdatePasswordDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UpdatePasswordDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                         
                                          new MySqlParameter("?p_NewPassword",User.UserPassword)                                          
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
