using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class QuizLevelsInsertBLL : Transaction
    {
        private Common.Quiz _quiz;
        public QuizLevelsInsertBLL()
        {
        }
        public void Invoke()
        {
            QuizLevelsInsertDAL insertData = new QuizLevelsInsertDAL();
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
