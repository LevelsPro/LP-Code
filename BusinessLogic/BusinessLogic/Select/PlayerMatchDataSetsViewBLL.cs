using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{

    public class PlayerMatchDataSetsViewBLL : Transaction
    {

        private Common.Match _match;
        private DataSet _resultSet;

        public PlayerMatchDataSetsViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerMatchDataSetsViewDAL updateData = new PlayerMatchDataSetsViewDAL();
            updateData.Match = this.Match;
            ResultSet = updateData.Update();
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
