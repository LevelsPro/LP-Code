using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class LevelsViewBLL : Transaction 
    {
         private DataSet _resultSet;
         private Common.Roles _role;
         public LevelsViewBLL()
        {
        }
        public void Invoke()
        {
            LevelsViewDAL selectData = new LevelsViewDAL();
            selectData.Role = this.Role;
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
        public Common.Roles Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }
    }
}
