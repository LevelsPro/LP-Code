using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetMatchPlayLogBLL
    {
        private DataSet _resultSet;
        public GetMatchPlayLogBLL()
        {
        }
        public void Invoke()
        {
            GetMatchPlayLogDAL selectData = new GetMatchPlayLogDAL();
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
