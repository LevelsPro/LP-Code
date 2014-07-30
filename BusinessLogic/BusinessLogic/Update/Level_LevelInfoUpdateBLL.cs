using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
  
    public class Level_LevelInfoUpdateBLL
    {
        private Common.Levels _levels;

        public Level_LevelInfoUpdateBLL()
        {
        }
        public void Invoke()
        {
            Level_LevelInfoUpdateDAL updateData = new Level_LevelInfoUpdateDAL();
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
