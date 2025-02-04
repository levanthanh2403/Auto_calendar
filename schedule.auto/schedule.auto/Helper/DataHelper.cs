using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using schedule.auto.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.auto.Helper
{
    public class DataHelper
    {
        public List<backup_model> LoadDataFromExcel()
        {
            List<backup_model> data = new List<backup_model>();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            Log.Information("Database path: {0}", filePath);
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    for (int row = 0; row <= sheet.LastRowNum; row++)
                    {
                        if (row == 0) continue;
                        backup_model item = new backup_model();
                        IRow rowData = sheet.GetRow(row);
                        if (rowData != null)
                        {
                            item.rowIndex = row;
                            for (int col = 0; col < rowData.LastCellNum; col++)
                            {
                                ICell cell = rowData.GetCell(col);
                                if (cell != null)
                                {
                                    //Console.WriteLine($"Value at [{row + 1},{col + 1}] = {cell.ToString()}");
                                    if (col == 0) item.jobId = cell.ToString();
                                    if (col == 1) item.jobName = cell.ToString();
                                    if (col == 2) item.ipSource = cell.ToString();
                                    if (col == 3) item.pathSource = cell.ToString();
                                    if (col == 4) item.ipDestination = cell.ToString();
                                    if (col == 5) item.pathDestination = cell.ToString();
                                    if (col == 6) item.status = cell.ToString();
                                    if (col == 7) item.frequency = cell.ToString();
                                    if (col == 8) item.dateExec = cell.ToString();
                                    if (col == 9) item.timeExec = cell.ToString();
                                }
                            }
                            data.Add(item);
                        }
                    }
                    workbook.Close();
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
            return data;
        }
        public void InsertDataToExcel(List<backup_model> data)
        {
            var currentData = LoadDataFromExcel();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "database.xlsx");
            Log.Information("Database path: {0}", filePath);
            if (File.Exists(filePath))
            {
                // Mở file Excel
                IWorkbook workbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(file);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                int rowIndex = 1;
                if (currentData.Count == 0) rowIndex = sheet.LastRowNum + 1;
                foreach (var item in data)
                {
                    IRow row = sheet.GetRow(rowIndex);
                    var checkData = currentData.Where(o => o.jobId == item.jobId).FirstOrDefault();
                    if (checkData == null) row = sheet.CreateRow(rowIndex);
                    else row = sheet.GetRow(checkData.rowIndex);
                    if (checkData == null)
                    {
                        row.CreateCell(0).SetCellValue(item.jobId);
                        row.CreateCell(1).SetCellValue(item.jobName);
                        row.CreateCell(2).SetCellValue(item.ipSource);
                        row.CreateCell(3).SetCellValue(item.pathSource);
                        row.CreateCell(4).SetCellValue(item.ipDestination);
                        row.CreateCell(5).SetCellValue(item.pathDestination);
                        row.CreateCell(6).SetCellValue(item.status);
                        row.CreateCell(7).SetCellValue(item.frequency);
                        row.CreateCell(8).SetCellValue(item.dateExec);
                        row.CreateCell(9).SetCellValue(item.timeExec);
                    }
                    else
                    {

                        row.GetCell(0).SetCellValue(item.jobId);
                        row.GetCell(1).SetCellValue(item.jobName);
                        row.GetCell(2).SetCellValue(item.ipSource);
                        row.GetCell(3).SetCellValue(item.pathSource);
                        row.GetCell(4).SetCellValue(item.ipDestination);
                        row.GetCell(5).SetCellValue(item.pathDestination);
                        row.GetCell(6).SetCellValue(item.status);
                        row.GetCell(7).SetCellValue(item.frequency);
                        row.GetCell(8).SetCellValue(item.dateExec);
                        row.GetCell(9).SetCellValue(item.timeExec);
                    }
                    rowIndex++;
                }
                // Lưu lại file Excel
                using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(file);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
