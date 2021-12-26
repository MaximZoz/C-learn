using C_learn;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GuessNumberGame(20, 5, GuessingPlayers.Machine);
            game.Start();
        }
    }
}
