using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class HoursWorkedUpdateDAL:DataAccessBase
    {
        private Common.User _user;
        private HoursWorkedUpdateDataParameters _insertParameters;

        public HoursWorkedUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateWorkedHours.ToString();
        }
        public void Update()
        {

            _insertParameters = new HoursWorkedUpdateDataParameters(User);
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


    public class HoursWorkedUpdateDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public HoursWorkedUpdateDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_user",User.UserID),                                          
                                            new MySqlParameter("?p_hours",User.Hours)                                          
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
