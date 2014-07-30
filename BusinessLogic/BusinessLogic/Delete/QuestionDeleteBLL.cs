using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{    
    public class QuestionDeleteBLL
    {
        private Common.Quiz _quiz;
        public QuestionDeleteBLL()
        {
        }
        public object Invoke()
        {
            QuestionDeleteDAL derleteData = new QuestionDeleteDAL();
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
