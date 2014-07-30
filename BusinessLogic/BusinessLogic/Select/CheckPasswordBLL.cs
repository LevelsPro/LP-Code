using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class CheckPasswordBLL : Transaction
    {
         private Common.User _user;
        private DataSet _resultSet;

        public CheckPasswordBLL()
        {
        }
        public void Invoke()
        {
            CheckPasswordDAL viewData = new CheckPasswordDAL();
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
