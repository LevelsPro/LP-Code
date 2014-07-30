using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Delete;

namespace BusinessLogic.Delete
{

    public class level_TargetDeleteBLL
    {
        private Common.Target _target;
        public level_TargetDeleteBLL()
        {
        }
        public object Invoke()
        {
            level_TargetDeleteDAL derleteData = new level_TargetDeleteDAL();
            derleteData.Target = this._target;
            return derleteData.Delete();
        }

        public Common.Target Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
    }
}
