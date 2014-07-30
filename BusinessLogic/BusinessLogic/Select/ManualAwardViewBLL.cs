using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ManualAwardViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.UserAwards _userawards;
        public ManualAwardViewBLL()
        {
        }
        public void Invoke()
        {
            ManualAwardViewDAL selectData = new ManualAwardViewDAL();
            selectData.UserAwards = UserAwards;
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

        public Common.UserAwards UserAwards
        {
            get
            {
                return _userawards;
            }
            set
            {
                _userawards = value;
            }
        }
    }
}
