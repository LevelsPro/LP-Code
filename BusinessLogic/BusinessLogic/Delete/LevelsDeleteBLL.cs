using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{
  public  class LevelsDeleteBLL
    {
       private Common.Levels _level;
       public LevelsDeleteBLL()
        {
        }
        public object Invoke()
        {
            LevelsDeleteDAL derleteData = new LevelsDeleteDAL();
            derleteData.Levels = this._level;
            return derleteData.Delete();
        }

        public Common.Levels Levels
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }
    }
}
