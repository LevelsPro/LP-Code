using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class UserImageUpdateBLL : Transaction
    {
        private Common.UserImage _userimage;

        public UserImageUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserImageUpdateDAL updateData = new UserImageUpdateDAL();
            updateData.UserImage = this.UserImage;
            updateData.Update();
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
