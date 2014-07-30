using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class UserImageInsertBLL : Transaction
    {
       private Common.UserImage _userimage;
       public UserImageInsertBLL()
        {
        }
        public void Invoke()
        {
            UserImageInsertDAL insertData = new UserImageInsertDAL();
            insertData.UserImage = this.UserImage;
            insertData.Add();
        }

        public Common.UserImage UserImage
        {
            get
            {
                return _userimage;
            }
            set
            {
                _userimage = value;
            }
        }
    }
}
