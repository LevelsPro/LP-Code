using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using System.IO;
using System.Data;

namespace LevelsPro.Util
{
    public class SpreadsheetReader
    {
        public static DataTable loadDataTable(string filePath)
        {
            DataTable table = null;
            FileInfo info = new FileInfo(filePath);
            using (ExcelPackage excel = new ExcelPackage(info))
            {
                ExcelWorksheets sheets = excel.Workbook.Worksheets;
                table = SpreadsheetReader.loadDataTable(sheets.First());
            }

            return table;
        }

        private static DataTable loadDataTable(ExcelWorksheet sheet)
        {
            DataTable table = new DataTable(sheet.Name);
            int totalCols = sheet.Dimension.End.Column;
            int totalRows = sheet.Dimension.End.Row;
            int startRow = 2;
            ExcelRange wsRow;
            DataRow dr;
            foreach (var firstRowCell in sheet.Cells[1, 1, 1, totalCols])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (int rowNum = startRow; rowNum <= totalRows; rowNum++)
            {
                wsRow = sheet.Cells[rowNum, 1, rowNum, totalCols];
                dr = table.NewRow();
                foreach (var cell in wsRow)
                {
                    dr[cell.Start.Column - 1] = cell.Text;
                }

                table.Rows.Add(dr);
            }

            return table;
        }

    }
}