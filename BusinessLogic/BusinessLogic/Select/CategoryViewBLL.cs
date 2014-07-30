using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   public class CategoryViewBLL : Transaction
    {
       private DataSet _resultSet;
       public CategoryViewBLL()
        {
        }
        public void Invoke()
        {
            CategoryViewDAL selectData = new CategoryViewDAL();
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
