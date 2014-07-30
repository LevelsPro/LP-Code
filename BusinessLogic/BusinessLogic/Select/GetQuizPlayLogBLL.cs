using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetQuizPlayLogBLL
    {
        private DataSet _resultSet;
        public GetQuizPlayLogBLL()
        {
        }
        public void Invoke()
        {
            GetQuizPlayLogDAL selectData = new GetQuizPlayLogDAL();
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
