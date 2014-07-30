using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
   public class AssignAwardDeleteBLL
    {
       private Common.Award _award;
       public AssignAwardDeleteBLL()
        {
        }
        public object Invoke()
        {
            AssignAwardDeleteDAL derleteData = new AssignAwardDeleteDAL();
            derleteData.Award = this.Award;
            return derleteData.Delete();
        }

        public Common.Award Award
        {
            get
            {
                return _award;
            }
            set
            {
                _award = value;
            }
        }
    }
}
