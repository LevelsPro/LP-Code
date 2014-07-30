using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;

namespace BusinessLogic.Insert
{
    public class SiteInsertBLL : Transaction
    {
         private Common.Site _site;
         public SiteInsertBLL()
        {
        }
        public void Invoke()
        {
            SiteInsertDAL insertData = new SiteInsertDAL();
            insertData.Site = this.Site;
            insertData.Add();
        }

        public Common.Site Site
        {
            get
            {
                return _site;
            }
            set
            {
                _site = value;
            }
        }
    }
}
