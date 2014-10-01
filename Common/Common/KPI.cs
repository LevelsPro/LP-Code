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
        SqlString _kpiTipsDESC;
        SqlString _kpiTipsLink;
        SqlString _typeaward;
        SqlString _typecontest;
        SqlString _typelevel;

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
        public SqlString KPITipsDESC
        {
            get { return _kpiTipsDESC; }
            set { _kpiTipsDESC = value; }
        }
        public SqlString KPITipsLINK
        {
            get { return _kpiTipsLink; }
            set { _kpiTipsLink = value; }
        }
        public SqlString TypeAward
        {
            get { return _typeaward; }
            set { _typeaward = value; }
        }
        public SqlString TypeContest
        {
            get { return _typecontest; }
            set { _typecontest = value; }
        }
        public SqlString TypeLevel
        {
            get { return _typelevel; }
            set { _typelevel = value; }
        }
        #endregion
    }
}
