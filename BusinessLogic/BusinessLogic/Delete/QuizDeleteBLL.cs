using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class QuizDeleteBLL
    {
        private Common.Quiz _quiz;
        public QuizDeleteBLL()
        {
        }
        public object Invoke()
        {
            QuizDeleteDAL derleteData = new QuizDeleteDAL();
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
