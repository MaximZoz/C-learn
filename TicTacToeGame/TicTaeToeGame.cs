namespace ConsoleApp1
{
    public enum Winner
    {
        Crosses,
        Zeroes,
        Draw,
        GameIsUnfinished
    }

    public enum State
    {
        Cross,
        Zero,
        Unset
    }

    public class TicTacToeGame
    {
        private readonly State[] _board = new State[9];

        public int MovesCounter { get; private set; }

        public TicTacToeGame()
        {
            for (var i = 0; i < _board.Length; i++)
            {
                _board[i] = State.Unset;
            }
        }

        public void MakeMove(int index)
        {
            _board[index - 1] = MovesCounter % 2 == 0 ? State.Cross : State.Zero;
            MovesCounter++;
        }

        public State GetState(int index)
        {
            return _board[index - 1];
        }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 5, 9, 3, 5, 7);
        }

        private Winner GetWinner(params int[] indexes)
        {
            for (var i = 0; i < indexes.Length; i += 3)
            {
                var same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
                if (!same) continue;
                var state = GetState(indexes[i]);
                if (state != State.Unset)
                {
                    return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                }
            }

            return MovesCounter < 9 ? Winner.GameIsUnfinished : Winner.Draw;
        }

        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }
}