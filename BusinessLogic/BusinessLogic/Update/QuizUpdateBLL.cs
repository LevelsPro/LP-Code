using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class QuizUpdateBLL : Transaction
    {
         private Common.Quiz _quiz;
        public QuizUpdateBLL()
        {
        }
        public void Invoke()
        {
            QuizUpdateDAL updateData = new QuizUpdateDAL();
            updateData.Quiz = this.Quiz;
            updateData.Update();
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
