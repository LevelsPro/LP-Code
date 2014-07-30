using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{   
    public class MessageStatusUpdateBLL
    {
        private Common.Messages _messages;

        public MessageStatusUpdateBLL()
        {
        }
        public void Invoke()
        {
            MessageStatusUpdateDAL updateData = new MessageStatusUpdateDAL();
            updateData.Messages = this._messages;
            updateData.Update();
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
