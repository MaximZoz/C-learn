using System;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace ConsoleApp1
{
    public static class Program
    {
        private static void Main()
        {
            MinMaxSumAvarage(
                @"../../../112 Top100ChessPlayers.xlsx");
        }

        static void MinMaxSumAvarage(string file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excel = new ExcelPackage(new FileInfo(file));
            const string newFile = @"../../../Top10_Chess_Players.xlsx";
            var newExcel = new ExcelPackage(new FileInfo(newFile));
            newExcel.Workbook.Properties.Author = "Zozulya";
            newExcel.Workbook.Properties.Title = "Top10_Chess_Players";
            newExcel.Workbook.Properties.Created = DateTime.Now;
            var newWorksheet = newExcel.Workbook.Worksheets.Add("Top10");


            var worksheet = excel.Workbook.Worksheets[0];
            var colCount = worksheet.Dimension.End.Column;
            var rowCount = worksheet.Dimension.End.Row;
            var arr = new string[rowCount];
            for (var row = 1; row <= rowCount; row++)
            {
                var value = "";

                for (var col = 1; col <= colCount; col++)
                {
                    //показывает все значения по  row и column

                    // Console.WriteLine(" Row:" + row + " column:" + col + " Value:" +
                    //                   worksheet.Cells[row, col].Value?.ToString()?.Trim());

                    value += worksheet.Cells[row, col].Value?.ToString()?.Trim();
                }

                arr[row - 1] = value;
            }


            var list = arr
                .Skip(2)
                .Select(ChessPlayer.ParseFideCsv)
                .Where(player => player.BirthYear > 1988)
                .OrderByDescending(player => player.Rating)
                .Take(10)
                .ToList();
            Console.WriteLine($"The lowest rating in top 10: {list.Min(x => x.Rating)}");
            Console.WriteLine($"The hightest rating in top 10: {list.Max(x => x.Rating)}");
            Console.WriteLine($"The average rating in top 10: {list.Average(x => x.Rating)}");

            newWorksheet.Cells["A1"].LoadFromCollection(list, true);

            newExcel.Save();
        }
    }
}