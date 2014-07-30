using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class CheckUserNameBLL : Transaction
    {
        private Common.User _user;
        private DataSet _resultSet;

        public CheckUserNameBLL()
        {
        }
        public void Invoke()
        {
            CheckUserNameDAL viewData = new CheckUserNameDAL();
            viewData.User = this.User;

            ResultSet = viewData.View();
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
