using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{ 
    public class PlayerGamesViewBLL
    {
        private Common.Match _match;
        private DataSet _resultSet;

        public PlayerGamesViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerGamesViewDAL selectData = new PlayerGamesViewDAL();
            selectData.Match = this.Match;
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
