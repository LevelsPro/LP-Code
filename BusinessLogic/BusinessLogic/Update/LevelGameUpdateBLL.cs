using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
   public class LevelGameUpdateBLL
    {
        private Common.LevelGame _game;

        public LevelGameUpdateBLL()
        {
        }
        public void Invoke()
        {
            LevelGameUpdateDAL updateData = new LevelGameUpdateDAL();
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
