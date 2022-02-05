using System;

namespace ConsoleApp1
{
    public static class Program
    {
        private static void Main()
        {
            var game = new StickGame(20, Player.Human);

            game.MachinePlayed += Game_MachinePlayed;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.EndOfGame += Game_EndOfGame;
            game.Start();
        }

        #region Methods

        private static void Game_HumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"осталось палок: {remainingSticks} ");
            Console.WriteLine("возьмите несколько палок");
            var takenCorrectly = false;
            while (!takenCorrectly)
            {
                if (!int.TryParse(Console.ReadLine(), out var takenSticks)) continue;
                var game = (StickGame)sender;
                try
                {
                    game.HumanTakes(takenSticks);
                    takenCorrectly = true;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        private static void Game_MachinePlayed(int takenSticks)
        {
            Console.WriteLine($"Машина взяла {takenSticks}");
        }


        private static void Game_EndOfGame(Player player)
        {
            Console.WriteLine($"победил: {player}");
        }

        #endregion
    }
}
