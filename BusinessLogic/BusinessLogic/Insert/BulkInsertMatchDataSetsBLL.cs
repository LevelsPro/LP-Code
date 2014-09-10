using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Insert;
using System.Data;
using System.IO;

namespace BusinessLogic.Insert
{
    public class BulkInsertMatchDataSetsBLL
    {
        public String BulkResult = "";

        public BulkInsertMatchDataSetsBLL()
        {
        }
        
        public void Invoke(DataSet bulkData, String FilePath)
        {
            DataAccess.Insert.BulkInsertMatchDataSetsDAL Bulk = new BulkInsertMatchDataSetsDAL();

            BulkResult = Bulk.BulkInsert(bulkData.Tables[0], FilePath);
        }
    }
}
