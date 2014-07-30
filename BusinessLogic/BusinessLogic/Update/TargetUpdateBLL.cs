using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  public  class TargetUpdateBLL : Transaction
    {
      private Common.Target _target;
      public TargetUpdateBLL()
        {
        }
        public void Invoke()
        {
            TargetUpdateDAL updateData = new TargetUpdateDAL();
            updateData.Target = this.Target;
            updateData.Update();
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
