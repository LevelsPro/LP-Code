using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class PostRepliedLikeInsertDAL:DataAccessBase
    {
        private Common.PostRepliedLike _post;
        private PostRepliedLikeInsertDataParameters _insertParameters;

        public PostRepliedLikeInsertDAL()
        {
           StoredProcedureName = StoredProcedure.Insert.sp_instertRepliedLike.ToString();
        }
        public void Add()
        {

            _insertParameters = new PostRepliedLikeInsertDataParameters(Post);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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
        public class PostRepliedLikeInsertDataParameters
        {
            private Common.PostRepliedLike _post;
            private MySqlParameter[] _parameters;

            public PostRepliedLikeInsertDataParameters(Common.PostRepliedLike post)
            {
                Post = post;
                Build();
            }
            public void Build()
            {
                MySqlParameter[] parameters = {new MySqlParameter("?p_LikedBy",Post.LikedBy),
                                         new MySqlParameter("?p_LikeID",Post.LikeID),
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
}
