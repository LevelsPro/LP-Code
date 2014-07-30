using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess.Select
{
    public class PostDetailsDAL : DataAccessBase
    {
        private Common.Posts _post;
        private GetPostDetailsParameters _viewParameters;
        public PostDetailsDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetPostDetails.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new GetPostDetailsParameters(Post);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString, _viewParameters.Parameters);
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

    public class GetPostDetailsParameters
    {
        private Common.Posts _post;
        private MySqlParameter[] _parameters;

        public GetPostDetailsParameters(Common.Posts post)
        {
            Post = post;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_PostID",Post.PostID)
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
