using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  public  class MatchLevelsBLL : Transaction
    {
      private DataSet _resultSet;
         private Common.Match _match;
         public MatchLevelsBLL()
        {
        }
        public void Invoke()
        {
            MatchLevelsDAL selectData = new MatchLevelsDAL();
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
