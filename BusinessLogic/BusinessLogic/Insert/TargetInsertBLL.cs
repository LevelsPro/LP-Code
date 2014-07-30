using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class TargetInsertBLL : Transaction
    {
       private Common.Target _target;
       public TargetInsertBLL()
        {
        }
        public void Invoke()
        {
            TargetInsertDAL insertData = new TargetInsertDAL();
            insertData.Target = this.Target;
            insertData.Add();
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
