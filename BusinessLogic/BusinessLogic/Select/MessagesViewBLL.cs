using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{

    public class MessagesViewBLL : Transaction
    {
        private DataSet _resultSet;
        public MessagesViewBLL()
        {
        }
        public void Invoke()
        {
            MessagesViewDAL selectData = new MessagesViewDAL();
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
    }
}
