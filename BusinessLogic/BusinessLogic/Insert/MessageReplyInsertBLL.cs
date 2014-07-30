using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{

    public class MessageReplyInsertBLL : Transaction
    {
        private Messages _messages;
        public MessageReplyInsertBLL()
        {
        }
        public void Invoke()
        {
            MessageReplyInsertDAL insertData = new MessageReplyInsertDAL();
            insertData.messages = this.messages;
            insertData.Add();
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
