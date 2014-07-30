using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    public class PostReplyInsertDAL : DataAccessBase
    {
        private Common.PostReplies _postReplies;
        private PostReplyInsertDataParameters _insertParameters;
        public PostReplyInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_insertPostReply.ToString();
        }
        public void Add()
        {

            _insertParameters = new PostReplyInsertDataParameters(PostReplies);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }
        public Common.PostReplies PostReplies
        {
            get
            {
                return _postReplies;
            }
            set
            {
                _postReplies = value;
            }
        }
    }
    public class PostReplyInsertDataParameters
    {
        private Common.PostReplies _postReplies;
        private MySqlParameter[] _parameters;

        public PostReplyInsertDataParameters(Common.PostReplies post)
        {
            PostReplies = post;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_ReplyMessage",PostReplies.ReplyMessage),
                                         new MySqlParameter("?p_RepliedBy",PostReplies.RepliedBy),
                                           new MySqlParameter("?p_ReplyDate",PostReplies.ReplyDate),
                                            new MySqlParameter("?p_PostID",PostReplies.PostID),
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
        public Common.PostReplies PostReplies
        {
            get
            {
                return _postReplies;
            }
            set
            {
                _postReplies = value;
            }
        }
    }
}
