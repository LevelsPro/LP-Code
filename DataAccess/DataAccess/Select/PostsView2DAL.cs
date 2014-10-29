using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class PostsView2DAL : DataAccessBase
    {
        private Common.Posts _post;
        public PostsView2DAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetPosts.ToString();
        }

        public DataSet View()
        {
            DataSet ds;
            PostViewDataParameters _viewParameters = new PostViewDataParameters(Post);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            
            ds = dbHelper.Run(base.ConnectionString, _viewParameters.Parameters);
            return ds;

            
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

    public class PostViewDataParameters
    {
        private Common.Posts _post;
        private MySqlParameter[] _parameters;

        public PostViewDataParameters(Common.Posts post)
        {
            Post = post;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_Where",Post.Where)
                                          };
            Parameters = parameters;
        }
        public MySqlParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
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
