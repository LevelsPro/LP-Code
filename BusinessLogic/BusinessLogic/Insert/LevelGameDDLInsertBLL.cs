using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
  public  class LevelGameDDLInsertBLL
    {
       private Common.LevelGame _game;
       public LevelGameDDLInsertBLL()
        {
        }
       public void Invoke()
        {
            LevelGameDDLInsertDAL insertData = new LevelGameDDLInsertDAL();
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
