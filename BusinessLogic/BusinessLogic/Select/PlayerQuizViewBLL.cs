using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{ 
    public class PlayerQuizViewBLL
    {
        private DataSet _resultSet;
        public PlayerQuizViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerQuizViewDAL selectData = new PlayerQuizViewDAL();
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
