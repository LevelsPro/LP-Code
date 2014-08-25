using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class KPIInsertDAL : DataAccessBase
    {
         private Common.KPI _kpi;
         private KPIInsertDataParameters _insertParameters;

        public KPIInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertKPI.ToString();
        }
        public void Add()
        {

            _insertParameters = new KPIInsertDataParameters(KPI);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
    public class KPIInsertDataParameters
    {
        private Common.KPI _kpi;
        private MySqlParameter[] _parameters;

        public KPIInsertDataParameters(Common.KPI kpi)
        {
            KPI = kpi;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_KpiName",KPI.KPIName),
                                           new MySqlParameter("?p_KpiMeasure",KPI.KPIMeasure),
                                           new MySqlParameter("?p_KpiType",KPI.KPIType),
                                           new MySqlParameter("?p_KpiCategory",KPI.KPICategory),
                                           new MySqlParameter("?p_Descp",KPI.KPIDescription),
                                           new MySqlParameter("?p_KpiTipsDESC",KPI.KPITipsDESC),
                                           new MySqlParameter("?p_KpiTipsLINK",KPI.KPITipsLINK)};
                                            
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
