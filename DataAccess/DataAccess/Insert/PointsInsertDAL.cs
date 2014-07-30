using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class PointsInsertDAL : DataAccessBase
    {
       private Common.Points _points;
        private PointsInsertDataParameters _insertParameters;

        public PointsInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertRedeemPoints.ToString();
        }
        public void Add()
        {

            _insertParameters = new PointsInsertDataParameters(Points);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Points Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }
    }

    public class PointsInsertDataParameters
    {
        private Common.Points _points;
        private MySqlParameter[] _parameters;

        public PointsInsertDataParameters(Common.Points points)
        {
            Points = points;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID", Points.UserID),
                                          new MySqlParameter("?p_RewardID", Points.RewardID),
                                          new MySqlParameter("?p_Point", Points.RedeemPoints)};
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
        public Common.Points Points
        {
            get
            {
                return _points;
            }
            set
            {
                _points = value;
            }
        }
    }
}
