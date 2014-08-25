using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
   public class QuizLevelsDeleteBLL : Transaction
    {
        private Common.Quiz _quiz;
        public QuizLevelsDeleteBLL()
        {
        }
    public void Invoke()
        {
            QuizLevelsDeleteDAL derleteData = new QuizLevelsDeleteDAL();
            derleteData.Quiz = this.Quiz;
            derleteData.Delete();
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
