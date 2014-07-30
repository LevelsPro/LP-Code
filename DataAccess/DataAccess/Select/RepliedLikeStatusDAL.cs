using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataAccess.Select
{
    public class RepliedLikeStatusDAL : DataAccessBase
    {
       private Common.PostRepliedLike _post;
       private RepliedLikeStatusParameters _viewParameters;
        public RepliedLikeStatusDAL()
        {
            StoredProcedureName = StoredProcedure.Select.sp_GetRepliedLikeStatus.ToString();
        }
        public DataSet View()
        {
            DataSet ds;
            _viewParameters = new RepliedLikeStatusParameters(Post);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(ConnectionString, _viewParameters.Parameters);
            return ds;
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

    public class RepliedLikeStatusParameters
    {
        private Common.PostRepliedLike _post;
        private MySqlParameter[] _parameters;

        public RepliedLikeStatusParameters(Common.PostRepliedLike post)
        {
            Post = post;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_LikeID",Post.LikeID),
                                            new MySqlParameter("?p_LikedBy",Post.LikedBy),
                                            new MySqlParameter("?p_PostID",Post.PostID)
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
