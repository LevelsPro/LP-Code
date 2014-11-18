using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
  public  class QuizResultInsertBLL
    {
      private Common.Quiz _quiz;
       public QuizResultInsertBLL()
        {
        }
        public void Invoke()
        {
            QuizResultInsertDAL insertData = new QuizResultInsertDAL();
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
