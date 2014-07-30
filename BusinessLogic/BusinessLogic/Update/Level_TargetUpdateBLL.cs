using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   
    public class Level_TargetUpdateBLL : Transaction
    {
        private Common.Target _target;
        public Level_TargetUpdateBLL()
        {
        }
        public void Invoke()
        {
            Level_TargetUpdateDAL updateData = new Level_TargetUpdateDAL();
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
