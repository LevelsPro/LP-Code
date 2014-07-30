using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class QuestionsInsertBLL : Transaction
    {

       private Common.Quiz _quiz;
       public QuestionsInsertBLL()
        {
        }
        public void Invoke()
        {
            QuestionsInsertDAL insertData = new QuestionsInsertDAL();
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
