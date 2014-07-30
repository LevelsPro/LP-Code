using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class QuestionLevelsViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Quiz _quiz;
        public QuestionLevelsViewBLL()
        {
        }
        public void Invoke()
        {
            QuestionLevelsViewDAL selectData = new QuestionLevelsViewDAL();
            selectData.Quiz = Quiz;
            ResultSet = selectData.View();
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
