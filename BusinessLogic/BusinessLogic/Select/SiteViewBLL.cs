using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class SiteViewBLL : Transaction
    {
        private DataSet _resultSet;
        public SiteViewBLL()
        {
        }
        public void Invoke()
        {
            SiteViewDAL selectData = new SiteViewDAL();
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
