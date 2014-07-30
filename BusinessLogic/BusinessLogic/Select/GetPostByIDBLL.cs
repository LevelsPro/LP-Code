using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class GetPostByIDBLL:Transaction
    {
        private DataSet _resultSet;
        private int _postid;
       public GetPostByIDBLL()
       {
       }
       public void Invoke()
       {
           GetPostByIDDAL selectData = new GetPostByIDDAL();    
           ResultSet = selectData.View(PostID);
       }

       public Int32 PostID
       {
           get
           {
               return _postid;
           }
           set
           {
               _postid = value;
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
