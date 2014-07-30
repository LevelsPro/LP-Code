using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
  public  class PlayerPointsViewDAL : DataAccessBase
    {
     private Common.Points _points;
        private UserPointsReportDataParameters _insertParameters;

        public PlayerPointsViewDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetPoints.ToString();
        }
        public DataSet Add()
        {

            _insertParameters = new UserPointsReportDataParameters(Points);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
           DataSet usersum=dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
            return usersum;
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
    public class UserPointsReportDataParameters
    {
        private Common.Points _points;
        private MySqlParameter[] _parameters;

        public UserPointsReportDataParameters(Common.Points points)
        {
            Points = points;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",Points.UserID)};
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
