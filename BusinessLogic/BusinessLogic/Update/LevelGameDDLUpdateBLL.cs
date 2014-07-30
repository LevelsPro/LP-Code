using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class LevelGameDDLUpdateBLL
    {
         private Common.LevelGame _game;

         public LevelGameDDLUpdateBLL()
        {
        }
        public void Invoke()
        {
            LevelGameDDLUpdateDAL updateData = new LevelGameDDLUpdateDAL();
            updateData.LevelGame = this.LevelGame;
            updateData.Update();
        }

        public Common.LevelGame LevelGame
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
    }
}
