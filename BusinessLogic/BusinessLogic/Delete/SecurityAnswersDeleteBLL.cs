using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
  public  class SecurityAnswersDeleteBLL
    {
      private Common.Quiz _quiz;
      public SecurityAnswersDeleteBLL()
        {
        }
        public object Invoke()
        {
            SecurityAnswersDeleteDAL derleteData = new SecurityAnswersDeleteDAL();
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
