using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
  public  class GetRewardUserDAL : DataAccessBase
    {
      private Common.Reward _userreward;
       public GetRewardUserDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetRewardUser.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            UserRewardgetparameters _viewParameters = new UserRewardgetparameters(UserRewards);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;           
        }

        public Common.Reward UserRewards
        {
            get
            {
                return _userreward;
            }
            set
            {
                _userreward = value;
            }
        }
    }

    public class UserRewardgetparameters
    {
        private Common.Reward _userreward;
        private MySqlParameter[] _parameters;

        public UserRewardgetparameters(Common.Reward userrewards)
        {
            UserRewards = userrewards;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_UserID",UserRewards.UserID)
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
        public Common.Reward UserRewards
        {
            get
            {
                return _userreward;
            }
            set
            {
                _userreward = value;
            }
        }
    }
}
