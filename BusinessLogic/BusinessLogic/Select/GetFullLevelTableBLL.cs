using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class GetFullLevelTableBLL
    {
        private DataSet _resultSet;

        public GetFullLevelTableBLL()
        {
        }

        public void Invoke()
        {
            GetFullLevelTableDAL selectData = new GetFullLevelTableDAL();
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
