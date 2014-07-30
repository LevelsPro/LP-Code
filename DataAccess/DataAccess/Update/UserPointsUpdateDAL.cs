using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class UserPointsUpdateDAL : DataAccessBase
    {

        private Common.User _user;
        private UserPointsUpdateDataParameters _insertParameters;

        public UserPointsUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdatePoints.ToString();
        }
        public void Update()
        {

            _insertParameters = new UserPointsUpdateDataParameters(User);
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


    public class UserPointsUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public UserPointsUpdateDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",User.UserID),                                       

                                           new MySqlParameter("?p_Points",User.Score)
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
