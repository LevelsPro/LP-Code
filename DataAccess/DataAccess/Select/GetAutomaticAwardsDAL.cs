using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class GetAutomaticAwardsDAL : DataAccessBase
    {
        private Common.User _user;
        private AutomaticAwardsViewDataParameters _viewParameters;

        public GetAutomaticAwardsDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetAutomaticAwards.ToString();
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

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new AutomaticAwardsViewDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;             
        }
    }


    public class AutomaticAwardsViewDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public AutomaticAwardsViewDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",User.UserID)
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
