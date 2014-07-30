using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    
    public class UpdateLevelPositionBLL
    {
        private Common.Levels _levels;

        public UpdateLevelPositionBLL()
        {
        }
        public void Invoke()
        {
            UpdateLevelPositionDAL updateData = new UpdateLevelPositionDAL();
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
