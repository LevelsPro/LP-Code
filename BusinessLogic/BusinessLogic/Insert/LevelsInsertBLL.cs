using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class LevelsInsertBLL
    {
        private Common.Levels _levels;
        public LevelsInsertBLL()
        {
        }
        public int Invoke()
        {
            LevelsInsertDAL insertData = new LevelsInsertDAL();
            insertData.Levels = this.Levels;
            return insertData.Add();
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
