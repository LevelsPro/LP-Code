using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Reports
{
   public class UserPointsReportDAL : DataAccessBase
    {
        private Common.Points _points;
        private UserPointsReportDataParameters _insertParameters;

        public UserPointsReportDAL()
        {
            StoredProcedureName = StoredProcedure.Report.sp_ReportSumPoints.ToString();
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
            MySqlParameter[] parameters = { new MySqlParameter("?p_UserID",Points.UserID), 
                                          new MySqlParameter("?p_Points",Points.RedeemPoints)};
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
