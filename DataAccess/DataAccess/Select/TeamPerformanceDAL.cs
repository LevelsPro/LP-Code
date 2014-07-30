using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class TeamPerformanceDAL : DataAccessBase
    {
        private Common.User _user;
        public TeamPerformanceDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_TeamPerformance.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            TeamDataParameters _viewParameters = new TeamDataParameters(User);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);           
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;
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

    public class TeamDataParameters
    {
        private Common.User _user;
        private MySqlParameter[] _parameters;

        public TeamDataParameters(Common.User user)
        {
            User = user;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ManagerID",User.ManagerID)
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
