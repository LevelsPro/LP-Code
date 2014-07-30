using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class PostInsertDAL : DataAccessBase
    {
        private Common.Posts _post;
        private PostInsertDataParameters _insertParameters;

        public PostInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertPost.ToString();
        }
        public void Add()
        {

            _insertParameters = new PostInsertDataParameters(Post);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
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

    public class PostInsertDataParameters
    {
        private Common.Posts _post;
        private MySqlParameter[] _parameters;

        public PostInsertDataParameters(Common.Posts post)
        {
            Post = post;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_PostTitle",Post.PostTitle),
                                         new MySqlParameter("?p_PostMessage",Post.PostMessage),
                                           new MySqlParameter("?p_CreateDate",Post.CreateDate),
                                           new MySqlParameter("?p_CreatedBy",Post.CreatedBy),
                                            new MySqlParameter("?p_PostTypeID",Post.PostTypeId),
                                           new MySqlParameter("?p_RoleID",Post.RoleId)
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
