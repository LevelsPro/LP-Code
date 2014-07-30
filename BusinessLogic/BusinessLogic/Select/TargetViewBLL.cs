using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class TargetViewBLL : Transaction
    {
        private DataSet _resultSet;
        public TargetViewBLL()
        {
        }
        public void Invoke()
        {
            TargetViewDAL selectData = new TargetViewDAL();
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
