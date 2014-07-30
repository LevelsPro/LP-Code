using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class PostDetaislBLL:Transaction
    {
        private Common.Posts _post;
        private DataSet _resultSet;

        public PostDetaislBLL()
        {
        }
        public void Invoke()
        {
            PostDetailsDAL viewData = new PostDetailsDAL();
            viewData.Post = this.Post;

            ResultSet = viewData.View();
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
