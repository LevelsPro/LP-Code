using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{
    public class SiteUpdateBLL : Transaction
    {
        private Common.Site _site;

        public SiteUpdateBLL()
        {
        }
        public void Invoke()
        {
            SiteUpdateDAL updateData = new SiteUpdateDAL();
            updateData.Site = this.Site;
            updateData.Update();
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
