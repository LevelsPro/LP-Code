using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{  

    public class RewardImageInsertDAL : DataAccessBase
    {
        private Common.Reward _reward;
        private RewardImageInsertDataParameters _insertParameters;

        public RewardImageInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertRewardImage.ToString();
        }
        public void Add()
        {

            _insertParameters = new RewardImageInsertDataParameters(Reward);
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
    public class RewardImageInsertDataParameters
    {
        private Common.Reward _reward;
        private MySqlParameter[] _parameters;

        public RewardImageInsertDataParameters(Common.Reward reward)
        {
            Reward = reward;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {
                                          new MySqlParameter("?p_RewardImage", Reward.RewardImage),
                                          new MySqlParameter("?p_RewardThumbnail", Reward.RewardThumbnail),
                                          new MySqlParameter("?p_RewardID", Reward.RewardID),
                                          new MySqlParameter("?p_CurrentImage",Reward.CurrentImage)};
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
