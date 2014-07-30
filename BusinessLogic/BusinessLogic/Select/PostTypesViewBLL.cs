using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    public class PostTypesViewBLL:Transaction
    {
        private DataSet _resultSet;
        public PostTypesViewBLL()
        {
        }
        public void Invoke()
        {
            PostsViewDAL selectData = new PostsViewDAL();
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
