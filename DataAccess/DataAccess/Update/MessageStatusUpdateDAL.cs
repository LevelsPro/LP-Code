using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Update
{

    public class MessageStatusUpdateDAL : DataAccessBase
    {
        private Common.Messages _messages;
        private MessageStatusUpdateDataParameters _insertParameters;

        public MessageStatusUpdateDAL()
        {
            StoredProcedureName = StoredProcedure.Update.sp_UpdateMessageStatus.ToString();
        }
        public void Update()
        {

            _insertParameters = new MessageStatusUpdateDataParameters(Messages);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);

        }

        public Common.Messages Messages
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
    public class MessageStatusUpdateDataParameters
    {
        private Common.Messages _messages;
        private MySqlParameter[] _parameters;

        public MessageStatusUpdateDataParameters(Common.Messages messages)
        {
            Messages = messages;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = { new MySqlParameter("?p_MessageID", Messages.MessageID), 
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
        public Common.Messages Messages
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
