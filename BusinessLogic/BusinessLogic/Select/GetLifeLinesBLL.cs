using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetLifeLinesBLL
    {
        private DataSet _resultSet;
        
        public GetLifeLinesBLL()
        {
        }

        public void Invoke()
        {
            GetLifeLineDAL selectData = new GetLifeLineDAL();
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
