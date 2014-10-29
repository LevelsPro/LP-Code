using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Award
    {
        #region Private Members
        SqlInt32 _awardid;
        SqlInt32 _userid;
        SqlString _where;
        SqlString _awardname;
        SqlString _awarddesc;
        SqlInt32 _awardmanual;
        
        SqlInt32 _kpiid;
        SqlInt32 _targetid;
        SqlInt16 _active;
        SqlInt32 _siteid;
        SqlString _awardimage;
        SqlString _awardthumbnail;
        SqlInt32 _currentimage;
        SqlInt32 _id;
        SqlInt32 _awardcategoryid;

        #endregion

        public Award()
        {
        }

        #region Properties
        public SqlInt32 AwardID
        {
            get { return _awardid; }
            set { _awardid = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }
        public SqlString AwardName
        {
            get { return _awardname; }
            set { _awardname = value; }
        }
        public SqlString AwardDesc
        {
            get { return _awarddesc; }
            set { _awarddesc = value; }
        }
        public SqlInt32 AwardManual
        {
            get { return _awardmanual; }
            set { _awardmanual = value; }
        }
        
        public SqlInt32 KPIID
        {
            get { return _kpiid; }
            set { _kpiid = value; }
        }
        public SqlInt32 TargetID
        {
            get { return _targetid; }
            set { _targetid = value; }
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
        public SqlString AwardImage
        {
            get { return _awardimage; }
            set { _awardimage = value; }
        }

        public SqlString AwardThumbnail
        {
            get { return _awardthumbnail; }
            set { _awardthumbnail = value; }
        }

        public SqlInt32 CurrentImage
        {
            get { return _currentimage; }
            set { _currentimage = value; }
        }
        public SqlInt32 ID
        {
            get { return _id; }
            set { _id = value; }
        
        }

        public SqlInt32 AwardCategoryID
        {
            get { return _awardcategoryid; }
            set { _awardcategoryid = value; }
        }

        #endregion
    }
}
