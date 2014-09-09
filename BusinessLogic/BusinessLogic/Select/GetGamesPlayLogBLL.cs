using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetGamesPlayLogBLL
    {
        private DataSet _resultSet;
        public GetGamesPlayLogBLL()
        {
        }
        public void Invoke()
        {
            GetGamesPlayLogDAL selectData = new GetGamesPlayLogDAL();
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
