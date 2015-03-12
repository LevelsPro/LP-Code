using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class getContestIDDAL: DataAccessBase
    {
        private Common.KPI _kpi;
        private KPIByRoleParameters _viewParameters;
        public getContestIDDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetContestID.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new KPIByRoleParameters(KPI);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

        }
        public Common.KPI KPI
        {
            get
            {
                return _kpi;
            }
            set
            {
                _kpi = value;
            }
        }

    }

    public class KPIByRoleParameters
    {
        private Common.KPI _kpi;
        private MySqlParameter[] _parameters;

        public KPIByRoleParameters(Common.KPI kpi)
        {
            KPI = kpi;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_kpiID",KPI.KPIID)
                                            
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
        public Common.KPI KPI
        {
            get
            {
                return _kpi;
            }
            set
            {
                _kpi = value;
            }
        }
    }
}
