using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class RolesViewBLL:Transaction 
    {
         private DataSet _resultSet;         
         public RolesViewBLL()
        {
        }
        public void Invoke()
        {
            RolesViewDAL selectData = new RolesViewDAL();
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
