using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;


namespace DataAccess.Insert
{
    public class BulkInsertMatchDataSetsDAL : DataAccessBase
    {
        public BulkInsertMatchDataSetsDAL()
        {
        }

        public static void CreateCSVfile(DataTable dtable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            int icolcount = dtable.Columns.Count;
            foreach (DataRow drow in dtable.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }
                    if (i < icolcount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            sw.Dispose();
        }


        public String BulkInsert(DataTable bulkTable, String FilePath)
        {
            String connection = base.ConnectionString;
            string strFile = FilePath + @"\tblMatchDataSets_" + DateTime.Now.Ticks.ToString() + ".csv";

            //If file does not exist then create it and right data into it..
            if (!File.Exists(strFile))
            {
                FileStream fs = new FileStream(strFile, FileMode.Create, FileAccess.Write);
                fs.Close();
                fs.Dispose();
            }

            //Generate csv file from where data read
            CreateCSVfile(bulkTable, strFile);


            using (MySqlConnection cn1 = new MySqlConnection(connection))
            {
                    cn1.Open();
                    MySqlBulkLoader bcp1 = new MySqlBulkLoader(cn1);
                    bcp1.TableName = "tblMatchDataSets";
                    bcp1.FieldTerminator = ",";
 
                    bcp1.LineTerminator = "\r\n";
                    bcp1.FileName = strFile;
                    bcp1.NumberOfLinesToSkip = 0;
                    bcp1.Load();
 
                    //Once data write into db then delete file..
                    try
                    {
                        File.Delete(strFile);
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
            }

            return "Successfull";
        }
    }
}
