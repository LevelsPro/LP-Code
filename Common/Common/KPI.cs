using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class KPI
    {
        #region Private Members
        SqlInt32 _kpiid;
        SqlString _kpiname;
        SqlString _kpimeasure;
        SqlString _kpitype;
        SqlInt16 _active;
        SqlInt32 _siteid;
        SqlString _kpicategory;
        SqlString _kpidesc;


        #endregion

        public KPI()
        {
        }

        #region Properties
        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }
        public SqlString KPIName
        {
            get { return _kpiname; }
            set { _kpiname = value; }
        }
        public SqlString KPIMeasure
        {
            get { return _kpimeasure; }
            set { _kpimeasure = value; }
        }
        public SqlString KPIType
        {
            get { return _kpitype; }
            set { _kpitype = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }

        public SqlString KPICategory
        {
            get { return _kpicategory; }
            set { _kpicategory = value; }
        }
        public SqlString KPIDescription
        {
            get { return _kpidesc; }
            set { _kpidesc = value; }
        }
        #endregion
    }
}
