using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{ 
    public class PlayerMatchViewBLL
    {
        private DataSet _resultSet;
        public PlayerMatchViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerMatchViewDAL selectData = new PlayerMatchViewDAL();
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
