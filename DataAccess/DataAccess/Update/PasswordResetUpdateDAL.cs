using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
  public  class PasswordResetUpdateDAL : DataAccessBase
    {
       private Common.User _user;
         private ResetUpdateDataParameters _insertParameters;

         public PasswordResetUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_PasswordRequest.ToString();
        }
        public void Update()
        {

            _insertParameters = new ResetUpdateDataParameters(User);
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
    public class ResetUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public ResetUpdateDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserNameID", User.UserName) };
            
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
