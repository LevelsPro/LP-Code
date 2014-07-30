using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class ManagerDropDownBLL :Transaction
    {

        private DataSet _resultSet;
        public ManagerDropDownBLL()
        {
        }
        public void Invoke()
        {

            Manager_DropDownDAL selectData = new Manager_DropDownDAL();
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
