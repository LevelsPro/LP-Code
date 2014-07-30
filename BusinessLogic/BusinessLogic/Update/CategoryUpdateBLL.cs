using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class CategoryUpdateBLL : Transaction
    {
       private Common.Quiz _quiz;

       public CategoryUpdateBLL()
        {
        }
        public void Invoke()
        {
            CategoryUpdateDAL updateData = new CategoryUpdateDAL();
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
