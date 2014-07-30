using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic
{
    public class CheckSecurityAnswersBLL : Transaction
    {
        private Common.User _user;
        private DataSet _resultSet;

        public CheckSecurityAnswersBLL()
        {
        }
        public void Invoke()
        {
            CheckSecurityAnswersDAL viewData = new CheckSecurityAnswersDAL();
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
