using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Delete
{

    public class RewardImageDeleteDAL : DataAccessBase
    {
        private Common.Reward _reward;
        private RewardImageDeleteDataParameters _deleteParameters;

        public RewardImageDeleteDAL()
        {
            StoredProcedureName = StoredProcedure.Delete.sp_DeleteRewardImage.ToString();
        }
        public object Delete()
        {

            _deleteParameters = new RewardImageDeleteDataParameters(Reward);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            //dbHelper.RunScalar(base.ConnectionString, _deleteParameters.Parameters);
            return dbHelper.Run(base.ConnectionString, _deleteParameters.Parameters);
        }

        public Common.Reward Reward
        {
            get
            {
                return _reward;
            }
            set
            {
                _reward = value;
            }
        }
    }

    public class RewardImageDeleteDataParameters
    {
        private Common.Reward _reward;
        private MySqlParameter[] _parameters;

        public RewardImageDeleteDataParameters(Common.Reward reward)
        {
            Reward = reward;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_ID", Reward.ID) };
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
        public Common.Reward Reward
        {
            get
            {
                return _reward;
            }
            set
            {
                _reward = value;
            }
        }
    }
}
