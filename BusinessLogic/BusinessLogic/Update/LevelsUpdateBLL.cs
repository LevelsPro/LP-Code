using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class LevelsUpdateBLL
    {
        private Common.Levels _levels;

        public LevelsUpdateBLL()
        {
        }
        public void Invoke()
        {
            LevelsUpdateDAL updateData = new LevelsUpdateDAL();
            updateData.Levels = this.Levels;
            updateData.Update();
        }

        public Common.Levels Levels
        {
            get
            {
                return _levels;
            }
            set
            {
                _levels = value;
            }
        }
    }
}
