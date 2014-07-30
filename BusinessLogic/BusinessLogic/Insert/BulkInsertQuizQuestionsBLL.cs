using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;
using System.Data;
using System.IO;

namespace BusinessLogic.Insert
{
    public class BulkInsertQuizQuestionsBLL
    {
        public String BulkResult = "";

        public BulkInsertQuizQuestionsBLL()
        {
        }

        
        public void Invoke(DataSet bulkData, String FilePath)
        {
            DataAccess.Insert.BulkInsertQuizQuestionsDAL Bulk = new BulkInsertQuizQuestionsDAL();

            BulkResult = Bulk.BulkInsert(bulkData.Tables[0], FilePath);
        }
    }
}
