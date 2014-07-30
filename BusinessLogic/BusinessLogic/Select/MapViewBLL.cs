using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
   
    public class MapViewBLL : Transaction
    {
        private DataSet _resultSet;
        public MapViewBLL()
        {
        }
        public void Invoke()
        {
            MapViewDAL selectData = new MapViewDAL();
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
