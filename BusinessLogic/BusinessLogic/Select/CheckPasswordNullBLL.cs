using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class CheckPasswordNullBLL : Transaction
    {
        private Common.User _user;
        private DataSet _resultSet;

        public CheckPasswordNullBLL()
        {
        }
        public void Invoke()
        {
            CheckPasswordNullDAL viewData = new CheckPasswordNullDAL();
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
