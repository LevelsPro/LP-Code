using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class Site_DropDownBLL :Transaction
    {

         private DataSet _resultSet;
         public Site_DropDownBLL()
        {
        }
        public void Invoke()
        {

            Site_DropDownDAL selectData = new Site_DropDownDAL();
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
