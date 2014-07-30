using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
    
    public class MessageReplyInsertDAL : DataAccessBase
    {
        private Messages _messages;
        private MessagesReplyInsertDataParameters _insertParameters;

        public MessageReplyInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMessageReply.ToString();
        }
        public void Add()
        {

            _insertParameters = new MessagesReplyInsertDataParameters(messages);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Messages messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
            }
        }
    }

    public class MessagesReplyInsertDataParameters
    {
        private Messages _messages;
        private MySqlParameter[] _parameters;

        public MessagesReplyInsertDataParameters(Messages Message)
        {
            messages = Message;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_FromUserID", _messages.FromUserID),
                                            new MySqlParameter("?p_ToUserID", _messages.ToUserID),
                                            new MySqlParameter("?p_MessageSubject", _messages.MessageSubject),
                                            new MySqlParameter("?p_MessageText",_messages.MessageText),
                                             new MySqlParameter("?p_RepliedMessageID",_messages.MessageID)
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

        public Messages messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
            }
        }
    }
}
