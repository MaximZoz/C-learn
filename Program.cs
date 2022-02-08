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

            // Еще какие есть методы в Link
            Console.WriteLine($"первый: {list.First()?.FirstName}"); // первый метод в link или исключение если нет 
            Console.WriteLine(
                $"последний: {list.Last()?.FirstName}"); // последний метод в link или исключение если нет 

            Console.WriteLine(
                $"первый по условию: {list.First(player => player.Country == "USA")?.FirstName}"); // первый метод в link или исключение если нет
            var firstFromDefault = list.FirstOrDefault()?.FirstName; // не выбрасывает исключение (первый или null)
            Console.WriteLine(firstFromDefault);
            // Console.WriteLine(
            //     $" если расчитываем получить иcключение :{list.Single(player => player.Country == "FRF")?.FirstName}");
            Console.WriteLine(
                $" выбрасывает исключение если более одного совпадения :{list.SingleOrDefault(player => player.Country == "USA")?.FirstName}");
        }
    }
}