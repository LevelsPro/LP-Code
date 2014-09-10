using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Contest
    {
        #region Private Members
        SqlInt32 _contestid;
        SqlString _contestname;
        SqlInt32 _contestdur;
        SqlInt32? _roleid;
        SqlInt32 _siteid;
        SqlInt32 _kpiid;
        SqlInt16 _active;
        byte[] _contestgraphic;
        SqlString _contestgraphicext;
        SqlString _conteststartdate;
        SqlString _contestenddate;

        #endregion

        public Contest()
        {
        }

        #region Properties
        public SqlInt32 ContestID
        {
            get { return _contestid; }
            set { _contestid = value; }
        }
        public SqlString ContestName
        {
            get { return _contestname; }
            set { _contestname = value; }
        }
        public SqlInt32 ContestDUR
        {
            get { return _contestdur; }
            set { _contestdur = value; }
        }
        public SqlInt32? RoleID
        {
            get { return _roleid; }
            set { _roleid = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public byte[] ContestGraphics
        {
            get { return _contestgraphic; }
            set { _contestgraphic = value; }
        }
        public SqlString ContestGraphicsExt
        {
            get { return _contestgraphicext; }
            set { _contestgraphicext = value; }
        }
        public SqlString ContestStartDate
        {
            get { return _conteststartdate; }
            set { _conteststartdate = value; }
        }
        public SqlString ContestEndDate
        {
            get { return _contestenddate; }
            set { _contestenddate = value; }
        }

        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }

        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }
        #endregion
    }
}
