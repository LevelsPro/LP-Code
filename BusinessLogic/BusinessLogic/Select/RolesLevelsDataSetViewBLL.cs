using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class RolesLevelsDataSetViewBLL : Transaction 
    {
         private DataSet _resultSet;
         private Common.Match _match;
         public RolesLevelsDataSetViewBLL()
        {
        }
        public void Invoke()
        {
            RolesLevelsDataSetViewDAL selectData = new RolesLevelsDataSetViewDAL();
            selectData.Match = this.Match;
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
        public Common.Match Match
        {
            get
            {
                return _match;
            }
            set
            {
                _match = value;
            }
        }
    }
}
