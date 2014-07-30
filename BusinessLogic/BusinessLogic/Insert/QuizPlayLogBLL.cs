using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class QuizPlayLogBLL
    {
        private Common.Quiz _quiz;
        public QuizPlayLogBLL()
        {
        }
        public void Invoke()
        {
            QuizPlayLogDAL insertData = new QuizPlayLogDAL();
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
