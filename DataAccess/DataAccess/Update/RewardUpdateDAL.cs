using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{
    public class RewardUpdateDAL : DataAccessBase
    {
        private Common.Reward _reward;
        private RewardUpdateDataParameters _insertParameters;

        public RewardUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateReward.ToString();
        }
        public void Update()
        {

            _insertParameters = new RewardUpdateDataParameters(Reward);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

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
    public class RewardUpdateDataParameters
    {
        private Common.Reward _reward;
        private MySqlParameter[] _parameters;

        public RewardUpdateDataParameters(Common.Reward reward)
        {
            Reward = reward;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_RewardID", Reward.RewardID), 
                                            new MySqlParameter("?p_RewardName", Reward.RewardName),
                                            new MySqlParameter("?p_Active", Reward.Active),
                                            new MySqlParameter("?p_RewardType", Reward.RewardType),
                                            new MySqlParameter("?p_RewardPoints", Reward.RewardPoints),
                                            new MySqlParameter("?p_RewardDescp", Reward.RewardDescp),
                                            new MySqlParameter("?p_CurrentImage", Reward.CurrentImage),
                                            new MySqlParameter("?p_ID", Reward.ID)
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
