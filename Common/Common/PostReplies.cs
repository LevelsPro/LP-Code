using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class PostReplies
    {
        #region Private Members
        SqlString _replyMessage;
        SqlInt32 _repliedBy;
        SqlDateTime _replyDate;
        SqlInt32 _postId;
        #endregion

        #region Properties
        public SqlString ReplyMessage
        {
            get { return _replyMessage; }
            set { _replyMessage = value; }
        }
        public SqlInt32 RepliedBy
        {
            get { return _repliedBy; }
            set {_repliedBy = value; }
        }
        public SqlDateTime ReplyDate
        {
            get { return _replyDate; }
            set { _replyDate = value; }
        }
        public SqlInt32 PostID
        {
            get { return _postId; }
            set { _postId = value; }
        }
        #endregion
    }
}
