using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Reward
    {
        #region Private Members
        SqlInt32 _rewardid;
        SqlString _rewardname;
        
        SqlInt32 _rewardpoints;
        SqlInt16 _active;
        SqlString _rewarddescp;
        SqlInt32 _siteid;
        SqlString _rewardimage;
        SqlString _rewardthumbnail;
        SqlInt32 _currentimage;
        SqlInt32 _id;
        SqlInt32 _userid;
        SqlString _where;
        SqlInt32 _rewardtype;

        #endregion
        public Reward()
        {
        }
        #region Properties
        public SqlInt32 RewardID
        {
            get { return _rewardid; }
            set { _rewardid = value; }
        }
        public SqlInt32 UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public SqlInt32 RewardType
        {
            get { return _rewardtype; }
            set { _rewardtype = value; }
        }
        public SqlString RewardName
        {
            get { return _rewardname; }
            set { _rewardname = value; }
        }
        public SqlInt16 Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public SqlInt32 RewardPoints
        {
            get { return _rewardpoints; }
            set { _rewardpoints = value; }
        }
        public SqlString RewardDescp
        {
            get { return _rewarddescp; }
            set { _rewarddescp = value; }
        }
      
        public SqlInt32 SiteID
        {
            get { return _siteid; }
            set { _siteid = value; }
        }

        public SqlString RewardImage
        {
            get { return _rewardimage; }
            set { _rewardimage = value; }
        }

        public SqlString RewardThumbnail
        {
            get { return _rewardthumbnail; }
            set { _rewardthumbnail = value; }
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

        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }
        #endregion
    }
}
