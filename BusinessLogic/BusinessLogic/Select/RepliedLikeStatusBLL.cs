using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class RepliedLikeStatusBLL
    {
         private DataSet _resultSet;
         private Common.PostRepliedLike _post;
         public RepliedLikeStatusBLL()
        {
        }
        public void Invoke()
        {
            RepliedLikeStatusDAL selectData = new RepliedLikeStatusDAL();
            selectData.Post = Post;
            ResultSet = selectData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
            }
        }
        public Common.PostRepliedLike Post
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
