using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  public  class LevelGameViewBLL : Transaction
    {
         private DataSet _resultSet;
         public LevelGameViewBLL()
        {
        }
        public void Invoke()
        {
            LevelGameViewDAL selectData = new LevelGameViewDAL();
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
