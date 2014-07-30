using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
    public class UserImageDeleteBLL
    {
        private Common.UserImage _user;
        public UserImageDeleteBLL()
        {
        }
        public object Invoke()
        {
            UserImageDeleteDAL derleteData = new UserImageDeleteDAL();
            derleteData.User = this.User;
            return derleteData.Delete();
        }

        public Common.UserImage User
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
