﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class TeamPerformanceBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.User _user;
        public TeamPerformanceBLL()
        {
        }
        public void Invoke()
        {
            TeamPerformanceDAL selectData = new TeamPerformanceDAL();
            selectData.User = User;
            ResultSet = selectData.View();
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
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
