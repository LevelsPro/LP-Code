using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class PostsViewBLL: Transaction
    {
        private DataSet _resultSet;
        private Common.Posts _post;
        public PostsViewBLL()
        {
        }
        public void Invoke()
        {

            PostsView2DAL selectData = new PostsView2DAL();
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
