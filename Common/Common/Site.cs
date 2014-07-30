using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Site
    {
        #region Private Members
        SqlInt32 _siteid;
        SqlString _sitename;        
        SqlInt32 _sitetype;
        SqlString _sitetypename;  
        SqlInt16 _active;
        SqlString _siteaddress;        

        #endregion
        public Site()
        {
        }
        #region Properties
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }
        public SqlString SiteName
        {
            get { return _sitename; }
            set { _sitename = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public SqlInt32 SiteType
        {
            get { return _sitetype; }
            set { _sitetype = value; }
        }
        public SqlString SiteTypeName
        {
            get { return _sitetypename; }
            set { _sitetypename = value; }
        }
        public SqlString SiteAddress
        {
            get { return _siteaddress; }
            set { _siteaddress = value; }
        }        
        #endregion
    }
}
