using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetProgressDetailBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.User _userid;
        public GetProgressDetailBLL()
        {
        }

        public Common.User UserID
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public void Invoke()
        {
            UserProgressDetailDAL selectData = new UserProgressDetailDAL();
            selectData.UserID = this.UserID;
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
