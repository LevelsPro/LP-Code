using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   public class UserImageViewBLL :Transaction
    {
        private DataSet _resultSet;
        private Common.UserImage _userimage;
       public UserImageViewBLL()
        {
        }
        public void Invoke()
        {
            UserImageViewDAL selectData = new UserImageViewDAL();
            selectData.UserImages = UserImages;
            ResultSet = selectData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
            }
        }

        public Common.UserImage UserImages
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
