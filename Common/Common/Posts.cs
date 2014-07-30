using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Posts
    {
        #region Private Members
        SqlInt32 _postid;
        SqlString _postTitle;
        SqlString _postMessage;
        SqlDateTime _createDate;
        SqlInt32 _createdBy;
        SqlInt32 _postTypeid;
        SqlInt32 _roleId;

        SqlString _where;

        #endregion

        #region Properties


        public SqlInt32 PostID
        {
            get { return _postid; }
            set { _postid = value; }
        }
        public SqlString PostTitle
        {
            get { return _postTitle; }
            set { _postTitle = value; }
        }
        public SqlString PostMessage
        {
            get { return _postMessage; }
            set { _postMessage = value; }
        }
        public SqlDateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public SqlInt32 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public SqlInt32 PostTypeId
        {
            get { return _postTypeid; }
            set { _postTypeid = value; }
        }
        public SqlInt32 RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        public SqlString Where
        {
            get { return _where; }
            set { _where = value; }
        }
        #endregion
    }
}
