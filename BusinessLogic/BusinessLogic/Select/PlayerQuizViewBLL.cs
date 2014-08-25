using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{ 
    public class PlayerQuizViewBLL : Transaction
    {
       private Common.Quiz _quiz;
        private DataSet _resultSet;

        public PlayerQuizViewBLL()
        {
        }
        public void Invoke()
        {
            PlayerQuizViewDAL updateData = new PlayerQuizViewDAL();
            updateData.Quiz = this.Quiz;
            ResultSet = updateData.Update();
        }

        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
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
