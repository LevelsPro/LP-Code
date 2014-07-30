using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class QuestionsUpdateBLL : Transaction
    {

        private Common.Quiz _quiz;
        public QuestionsUpdateBLL()
        {
        }
        public void Invoke()
        {
            QuestionsUpdateDAL updateData = new QuestionsUpdateDAL();
            updateData.Quiz = this.Quiz;
            updateData.Update();
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
