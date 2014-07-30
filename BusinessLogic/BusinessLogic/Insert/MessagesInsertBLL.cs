using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   
    public class MessagesInsertBLL : Transaction
    {
        private Messages _messages;
        public MessagesInsertBLL()
        {
        }
        public void Invoke()
        {
            MessageInsertDAL insertData = new MessageInsertDAL();
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
