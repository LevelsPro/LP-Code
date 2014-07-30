using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class CategoryInsertBLL : Transaction
    {
       private Common.Quiz _quiz;
       public CategoryInsertBLL()
        {
        }
        public void Invoke()
        {
            CategoryInsertDAL insertData = new CategoryInsertDAL();
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
