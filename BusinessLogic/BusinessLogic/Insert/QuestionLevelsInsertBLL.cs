using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class QuestionLevelsInsertBLL : Transaction
    {
        private Common.Quiz _quiz;
        public QuestionLevelsInsertBLL()
        {
        }
        public void Invoke()
        {
            QuestionLevelsInsertDAL insertData = new QuestionLevelsInsertDAL();
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
