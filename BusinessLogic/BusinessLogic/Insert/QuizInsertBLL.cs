using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class QuizInsertBLL : Transaction
    {

        private Common.Quiz _quiz;
        public QuizInsertBLL()
        {
        }
        public void Invoke()
        {
            QuizInsertDAL insertData = new QuizInsertDAL();
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
