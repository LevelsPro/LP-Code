using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class RewardInsertDAL : DataAccessBase
    {
        private Common.Reward _reward;
        private RewardInsertDataParameters _insertParameters;

        public RewardInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertReward.ToString();
        }
        public int Add()
        {

            _insertParameters = new RewardInsertDataParameters(Reward);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            return Convert.ToInt32(((MySqlParameter)_insertParameters.Parameters[6]).Value);
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
    public class RewardInsertDataParameters
    {
        private Common.Reward _reward;
        private MySqlParameter[] _parameters;

        public RewardInsertDataParameters(Common.Reward reward)
        {
            Reward = reward;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_RewardName",Reward.RewardName),
                                          new MySqlParameter("?p_RewardType", Reward.RewardType),
                                          new MySqlParameter("?p_RewardPoints", Reward.RewardPoints),
                                          new MySqlParameter("?p_RewardDesc", Reward.RewardDescp),
                                          new MySqlParameter("?p_RewardImage", Reward.RewardImage),
                                          new MySqlParameter("?p_RewardThumbnail", Reward.RewardThumbnail),
                                           new MySqlParameter("?p_RewardID",MySqlDbType.Int32,4,System.Data.ParameterDirection.Output,true,0,0,"Reward_ID",System.Data.DataRowVersion.Current,Reward.RewardID)};
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
