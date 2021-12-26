using System;

namespace C_learn
{
    public enum GuessingPlayers
    {
        Human,
        Machine
    }
    public class GuessNumberGame
    {
        private readonly int _max;
        private readonly int _maxTries;
        private readonly GuessingPlayers _guessingPlayer;

        public GuessNumberGame(int max = 100, int maxTries = 5, GuessingPlayers guessingPlayer = GuessingPlayers.Human)
        {
            this._max = max;
            this._maxTries = maxTries;
            this._guessingPlayer = guessingPlayer;
        }

        public void Start()
        {
            if (_guessingPlayer == GuessingPlayers.Human)
            {
                HumanGuesses();
            }
            else
            {
                MachineGuesses();
            }
        }

        private void HumanGuesses()
        {
            var random = new Random();
            var guessedNumber = random.Next(0, _max);
            var lastGuess = -1;
            var tries = 0;
            while (lastGuess != guessedNumber && tries < _maxTries)
            {
                Console.WriteLine("Guess the number!");
                lastGuess = int.Parse(Console.ReadLine() ?? string.Empty);
                if (lastGuess < guessedNumber)
                {
                    Console.WriteLine("My Number is greater");
                }
                else if (lastGuess > guessedNumber)
                {
                    Console.WriteLine("My Number is less");
                }
                else
                {
                    Console.WriteLine("Congrats! You guest the number!");
                }

                tries++;
                if (tries == _maxTries)
                {
                    Console.WriteLine("Your lost!");
                }
            }
        }

        private void MachineGuesses()
        {
            Console.WriteLine("Enter a number that's going to be guessed by a computer.");
            int guessedNumber = -1;
            while (guessedNumber == -1)
            {
                var parsedNumber = int.Parse(Console.ReadLine()
                    ?? string.Empty);
                if (parsedNumber >= 0 && parsedNumber <= this._max)
                {
                    guessedNumber = parsedNumber;
                }
            }

            var lastGuess = -1;
            var min = 0;
            var i = this._max;
            var tries = 0;

            while (lastGuess != guessedNumber && tries < _maxTries)
            {
                lastGuess = (i + min) / 2;
                Console.WriteLine($"did you guess this number - {lastGuess} ?");
                Console.WriteLine("if yes, enter 'y', if you number is greater - enter 'g', if less - 'l' ");
                var answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Console.WriteLine("Super! I guessed your number, men!");
                        break;
                    case "g":
                        min = lastGuess;
                        break;
                    default:
                        i = lastGuess;
                        break;
                }

                if (lastGuess == guessedNumber)
                {
                    Console.WriteLine("Don't cheat, man!");
                }

                tries++;
                if (tries == _maxTries)
                {
                    Console.WriteLine("No tries anymore =( a lose");
                }
            }
        }
    }
}