using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
    public class MessageDeleteBLL
    {
        private Common.Messages _msg;
         public MessageDeleteBLL()
        {
        }
        public object Invoke()
        {
            MessageDeleteDAL derleteData = new MessageDeleteDAL();
            derleteData.Message = this.Message;
            return derleteData.Delete();
        }

        public Common.Messages Message
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
            }
        }
    }
}
