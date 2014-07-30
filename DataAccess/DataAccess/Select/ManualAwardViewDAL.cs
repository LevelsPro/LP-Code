using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class ManualAwardViewDAL : DataAccessBase
    {
        private Common.UserAwards _userawards;
        public ManualAwardViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetManualAssignedAwards.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            UserAwardsViewDataParameters _viewParameters = new UserAwardsViewDataParameters(UserAwards);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //ds = dbHelper.Run(ConnectionString);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;           
        }

        public Common.UserAwards UserAwards
        {
            get
            {
                return _userawards;
            }
            set
            {
                _userawards = value;
            }
        }
    }

    public class UserAwardsViewDataParameters
    {
        private Common.UserAwards _userawards;
        private MySqlParameter[] _parameters;

        public UserAwardsViewDataParameters(Common.UserAwards userawards)
        {
            UserAwards = userawards;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",UserAwards.User_Id)
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
        public Common.UserAwards UserAwards
        {
            get
            {
                return _userawards;
            }
            set
            {
                _userawards = value;
            }
        }
    }
}
