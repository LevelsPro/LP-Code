using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
  public  class QuizLevelsBLL : Transaction
    {
      private DataSet _resultSet;
         private Common.Quiz _quiz;
         public QuizLevelsBLL()
        {
        }
        public void Invoke()
        {
            QuizLevelsDAL selectData = new QuizLevelsDAL();
            selectData.Quiz = this.Quiz;
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
    }
}
