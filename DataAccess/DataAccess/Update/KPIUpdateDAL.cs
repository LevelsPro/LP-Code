using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;


namespace DataAccess.Update
{
    public class KPIUpdateDAL : DataAccessBase
    {
        private Common.KPI _kpi;
        private KPIUpdateDataParameters _insertParameters;

        public KPIUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateKPI.ToString();
        }
        public void Update()
        {

            _insertParameters = new KPIUpdateDataParameters(KPI);
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
    public class KPIUpdateDataParameters
    {
        private Common.KPI _kpi;
        private MySqlParameter[] _parameters;

        public KPIUpdateDataParameters(Common.KPI kpi)
        {
            KPI = kpi;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_KpiID",KPI.KPIID), 
                                            new MySqlParameter("?p_KpiName",KPI.KPIName),
                                            new MySqlParameter("?p_KpiMeasure",KPI.KPIMeasure),
                                            new MySqlParameter("?p_KpiType",KPI.KPIType),
                                            new MySqlParameter("?p_Active", KPI.Active),
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
