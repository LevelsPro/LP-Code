using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
   public class LevelGameInsertBLL
    {
        private Common.LevelGame _game;
        public LevelGameInsertBLL()
        {
        }
        public void Invoke()
        {
            LevelGameInsertDAL insertData = new LevelGameInsertDAL();
            insertData.LevelGame = this.LevelGame;
            insertData.Add();
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
