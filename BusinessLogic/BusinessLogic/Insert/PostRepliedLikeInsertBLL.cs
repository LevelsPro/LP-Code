using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class PostRepliedLikeInsertBLL : Transaction
    {
        private Common.PostRepliedLike _postRepliedLike;
        public PostRepliedLikeInsertBLL()
        {
        }
        public void Invoke()
        {
            PostRepliedLikeInsertDAL insertData = new PostRepliedLikeInsertDAL();
            insertData.Post = this.PostRepliedLike;
            insertData.Add();
        }

        public Common.PostRepliedLike PostRepliedLike
        {
            get
            {
                return _postRepliedLike;
            }
            set
            {
                _postRepliedLike = value;
            }
        }
    }
}
