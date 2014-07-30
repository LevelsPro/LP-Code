using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
  public  class AwardImageDeleteBLL
    {
       private Common.Award _award;
       public AwardImageDeleteBLL()
        {
        }
       public object Invoke()
        {
            AwardImageDeleteDAL derleteData = new AwardImageDeleteDAL();
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
