using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
   public class QuestionLevelDeleteBLL 
    {
       private Common.Quiz _quiz;
       public QuestionLevelDeleteBLL()
        {
        }
    public void Invoke()
        {
            QuestionLevelDeleteDAL derleteData = new QuestionLevelDeleteDAL();
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
