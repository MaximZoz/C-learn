using System;

namespace ConsoleApp1
{
    public class StickGame
    {
        private readonly Random _randomizer;
        private int InitialStickNumber { get; }
        private Player Turn { get; set; }
        private int RemainingSticks { get; set; }
        private GameStatus GameStatus { get; set; }

        public event Action<int> MachinePlayed;
        public event EventHandler<int> HumanTurnToMakeMove;
        public event Action<Player> EndOfGame;

        public StickGame(int initialStickNumber, Player whoMakesFirstMove)
        {
            if (initialStickNumber < 7 || initialStickNumber > 30)
                throw new Exception("от 7 до 30");
            _randomizer = new Random();

            GameStatus = GameStatus.NotStarted;
            RemainingSticks = initialStickNumber;
            InitialStickNumber = initialStickNumber;
            Turn = whoMakesFirstMove;
        }

        public void HumanTakes(int sticks)
        {
            if (sticks < 1 || sticks > 3)
                throw new ArgumentException("от 1 до 3");
            if (sticks > RemainingSticks)
            {
                throw new ArgumentException($"вы хотите взять больше, чем осталось. Осталось: {RemainingSticks}");
            }

            TakeSticks(sticks);
        }

        public void Start()
        {
            RemainingSticks = GameStatus switch
            {
                GameStatus.GameIsOver => InitialStickNumber,
                GameStatus.InProgress => throw new InvalidOperationException(
                    "Невозможно вызвать Start, когда игра уже запущена"),
                _ => RemainingSticks
            };
            GameStatus = GameStatus.InProgress;
            while (GameStatus == GameStatus.InProgress)
            {
                if (Turn == Player.Computer)
                    CompMakesMove();
                else
                {
                    HumanMakesMove();
                }

                FireEndOfGameIfRequired();
                Turn = Turn == Player.Computer ? Player.Human : Player.Computer;
            }
        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks != 0) return;
            GameStatus = GameStatus.GameIsOver;
            EndOfGame?.Invoke(Turn == Player.Computer ? Player.Human : Player.Computer);
        }

        private void HumanMakesMove()
        {
            HumanTurnToMakeMove?.Invoke(this, RemainingSticks);
        }

        private void CompMakesMove()
        {
            var maxNumber = RemainingSticks >= 3 ? 3 : RemainingSticks;
            var sticks = _randomizer.Next(1, maxNumber);
            TakeSticks(sticks);
            MachinePlayed?.Invoke(sticks);
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}