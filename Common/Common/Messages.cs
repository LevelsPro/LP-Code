using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace Common
{
    public class Messages
    {
        #region Private Members

        SqlInt32 _fromuserid;
        SqlInt32 _touserid;
        SqlString _messagesubject;
        SqlString _messagetext;
        SqlInt32 _messageid;

        #endregion
        public Messages()
        {
        }
        #region Properties

        public SqlInt32 FromUserID
        {
            get { return _fromuserid; }
            set { _fromuserid = value; }
        }

        public SqlInt32 ToUserID
        {
            get { return _touserid; }
            set { _touserid = value; }
        }


        public SqlString MessageSubject
        {
            get { return _messagesubject; }
            set { _messagesubject = value; }
        }

        public SqlString MessageText
        {
            get { return _messagetext; }
            set { _messagetext = value; }
        }

        public SqlInt32 MessageID
        {
            get { return _messageid; }
            set { _messageid = value; }
        }

        #endregion
    }
}
