using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class GetAllMilestonesDAL : DataAccessBase
    {
        private Common.Award _award;
        private MilestoneDetailViewDataParameters _viewParameters;

        public GetAllMilestonesDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GelMilestonesDetail.ToString();
        }

        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new MilestoneDetailViewDataParameters(Award);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;             
        }
    }

    public class MilestoneDetailViewDataParameters
    {
        private Common.Award _award;
        private MySqlParameter[] _parameters;

        public MilestoneDetailViewDataParameters(Common.Award award)
        {
            Award = award;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_AwardID",Award.AwardID)
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
        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
