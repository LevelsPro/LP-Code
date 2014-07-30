using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Select;
using System.Data;

namespace BusinessLogic.Select
{
    
    public class QuizQuestionsViewBLL : Transaction
    {
        private DataSet _resultSet;
        private Common.Quiz _quiz;
        public QuizQuestionsViewBLL()
        {
        }
        public void Invoke()
        {
            QuizQuestionsViewDAL selectData = new QuizQuestionsViewDAL();
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
