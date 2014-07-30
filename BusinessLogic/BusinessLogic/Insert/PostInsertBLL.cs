using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class PostInsertBLL: Transaction
    {
        private Common.Posts _post;
        public PostInsertBLL()
        {
        }
        public void Invoke()
        {
            PostInsertDAL insertData = new PostInsertDAL();
            insertData.Post = this.Post;
            insertData.Add();
        }

        public Common.Posts Post
        {
            get
            {
                return _post;
            }
            set
            {
                _post = value;
            }
        }
    }
}
