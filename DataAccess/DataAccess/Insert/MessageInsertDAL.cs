using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   
    public class MessageInsertDAL : DataAccessBase
    {
        private Messages _messages;
        private MessagesInsertDataParameters _insertParameters;

        public MessageInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertMessage.ToString();
        }
        public void Add()
        {

            _insertParameters = new MessagesInsertDataParameters(messages);
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

    public class MessagesInsertDataParameters
    {
        private Messages _messages;
        private MySqlParameter[] _parameters;

        public MessagesInsertDataParameters(Messages Message)
        {
            messages = Message;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_FromUserID", _messages.FromUserID),
                                            new MySqlParameter("?p_ToUserID", _messages.ToUserID),
                                            new MySqlParameter("?p_MessageSubject", _messages.MessageSubject),
                                            new MySqlParameter("?p_MessageText",_messages.MessageText)
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
