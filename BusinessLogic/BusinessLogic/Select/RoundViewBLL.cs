using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class RoundViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Match _match;
        public RoundViewBLL()
        {
        }
        public void Invoke()
        {
            RoundViewDAL selectData = new RoundViewDAL();
            selectData.Match = Match;
            ResultSet = selectData.View();
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
