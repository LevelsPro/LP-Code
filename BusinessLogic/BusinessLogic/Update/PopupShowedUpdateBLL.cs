using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class PopupShowedUpdateBLL :Transaction
    {
         private Common.User _user;

         public PopupShowedUpdateBLL()
        {
        }
        public void Invoke()
        {
            PopupShowedUpdateDAL updateData = new PopupShowedUpdateDAL();
            updateData.User = this.User;
            updateData.Update();
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
