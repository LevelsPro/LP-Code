using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{

    public class TargetDesciptionViewBLL : Transaction
    {
        private DataSet _resultSet;
        public TargetDesciptionViewBLL()
        {
        }
        public void Invoke()
        {
            TargetDescriptionVeiwDAL selectData = new TargetDescriptionVeiwDAL();
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
