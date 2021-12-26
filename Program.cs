using System;
using System.Text;

namespace ConsoleApp1
{
    public static class Program
    {
        private static TicTacToeGame G = new TicTacToeGame();

        private static void Main()
        {
            Console.WriteLine(GetPrintableState());
            while (G.GetWinner() == Winner.GameIsUnfinished)
            {
                var index = int.Parse(Console.ReadLine() ?? string.Empty);
                G.MakeMove(index);
                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result: {G.GetWinner()}");
        }

        private static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     |")
                    .AppendLine($"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  |")
                    .AppendLine("_____|_____|_____|");
            }

            return sb.ToString();
        }

        private static string GetPrintableChar(int index)
        {
            var state = G.GetState(index);
            if (state == State.Unset)
            {
                return index.ToString();
            }

            return state == State.Cross ? "X" : "O";
        }
    }
}