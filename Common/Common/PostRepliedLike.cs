using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class PostRepliedLike 
    {
        #region Private Members

        SqlInt32 _likedby;
        SqlInt32 _likeid;
        SqlInt32 _postid;

        #endregion

        #region Properties

        public SqlInt32 LikedBy
        {
            get { return _likedby; }
            set { _likedby = value; }
        }

        public SqlInt32 LikeID
        {
            get { return _likeid; }
            set { _likeid = value; }
        }


        public SqlInt32 PostID
        {
            get { return _postid; }
            set { _postid = value; }
        }
        #endregion
    }
}
