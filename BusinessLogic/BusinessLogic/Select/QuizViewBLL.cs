using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class QuizViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Quiz _quiz;
        public QuizViewBLL()
        {
        }
        public void Invoke()
        {
            QuizViewDAL selectData = new QuizViewDAL();
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
