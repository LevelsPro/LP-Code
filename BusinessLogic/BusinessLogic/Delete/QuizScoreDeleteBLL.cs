using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
  public  class QuizScoreDeleteBLL 
    {
      private Common.Quiz _quiz;
      public QuizScoreDeleteBLL()
        {
        }
        public object Invoke()
        {
            QuizScoreDeleteDAL derleteData = new QuizScoreDeleteDAL();
            derleteData.Quiz = this.Quiz;
            return derleteData.Delete();
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
