using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Target
    {
        #region Private Members
        SqlInt32 _targetid;
        SqlInt32 _targetvalue;
        SqlInt32 _kpiid;
        SqlInt32 _levelid;
        SqlInt32 _roleid;
        SqlInt16 _active;
        SqlInt32 _siteid;
        SqlString _description;
        SqlInt32 _points;
        SqlInt32 _targetOrder;

        

        #endregion

        public Target()
        {
        }

        #region Properties
        public SqlInt32 TargetID
        {
            get { return _targetid; }
            set { _targetid = value; }
        }
        
        public SqlInt32 TargetValue
        {
            get { return _targetvalue; }
            set { _targetvalue = value; }
        }

        public SqlInt32 TargetOrder
        {
            get { return _targetOrder; }
            set { _targetOrder = value; }
        }

        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }
        public SqlInt32 LevelID
        {
            get { return _levelid; }
            set { _levelid = value; }
        }
        public SqlInt32 RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
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
        public SqlString Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public SqlInt32 Points
        {
            get { return _points; }
            set { _points = value; }
        }
        #endregion
    }
}
