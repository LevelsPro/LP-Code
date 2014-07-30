using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class QuizScoreInsertBLL : Transaction
    {
      
        private Common.Quiz _quiz;
        public QuizScoreInsertBLL()
        {
        }
        public void Invoke()
        {
            QuizScoreInsertDAL insertData = new QuizScoreInsertDAL();
            insertData.Quiz = this.Quiz;
            insertData.Add();
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
