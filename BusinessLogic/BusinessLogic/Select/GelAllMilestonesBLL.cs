using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GelAllMilestonesBLL: Transaction
    {
        private DataSet _resultSet;
       private Common.Award _award;
       public GelAllMilestonesBLL()
       {
       }
       public void Invoke()
       {
           GetAllMilestonesDAL selectData = new GetAllMilestonesDAL();
           selectData.Award = this.Award;      
           ResultSet = selectData.View();
       }

       public Common.Award Award
       {
           get
           {
               return _award;
           }
           set
           {
               _award = value;
           }
       }

       public DataSet ResultSet
       {
           get
           {
               return _resultSet;
           }
           set
           {
               _resultSet = value;
           }
       }
    }
}
