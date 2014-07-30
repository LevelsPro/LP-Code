using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class PostReplyInsertBLL : Transaction
    {
        private Common.PostReplies _postReplies;
        public PostReplyInsertBLL()
        {
        }
        public void Invoke()
        {
            PostReplyInsertDAL insertData = new PostReplyInsertDAL();
            insertData.PostReplies = this.PostReplies;
            insertData.Add();
        }

        public Common.PostReplies PostReplies
        {
            get
            {
                return _postReplies;
            }
            set
            {
                _postReplies = value;
            }
        }
    }
}
