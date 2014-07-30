using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select 
{
   public class AwardViewBLL : Transaction
    {
        private DataSet _resultSet;
        //private Common.Award _award;
        public AwardViewBLL()
        {
        }
        public void Invoke()
        {
            AwardViewDAL selectData = new AwardViewDAL();
           // selectData.Award = Award;
            ResultSet = selectData.View();
        }

        //public Common.Award Award
        //{
        //    get
        //    {
        //        return _award;
        //    }
        //    set
        //    {
        //        _award = value;
        //    }
        //}
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


   public class PlayerAwardViewBLL : Transaction
   {
       private DataSet _resultSet;
       private Common.Points _points;
       public PlayerAwardViewBLL()
       {
       }
       public void Invoke()
       {
           DataAccess.Select.AwardViewDAL.PlayerAwardViewDAL selectData = new DataAccess.Select.AwardViewDAL.PlayerAwardViewDAL();
           selectData.Points = this.Points;      
           ResultSet = selectData.View();
       }

       public Common.Points Points
       {
           get
           {
               return _points;
           }
           set
           {
               _points = value;
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

   public class AwardViewDetailBLL : Transaction
   {
       private DataSet _resultSet;
       private Common.Award _award;
       public AwardViewDetailBLL()
       {
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

       public void Invoke()
       {
           DataAccess.Select.AwardViewDAL.AwardViewDetailsDAL selectData = new DataAccess.Select.AwardViewDAL.AwardViewDetailsDAL();
           selectData.Award = this.Award;           
           ResultSet = selectData.View();
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
