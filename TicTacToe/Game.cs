
namespace TicTacToe
{
    class Game
    {
        public static readonly ushort[] WinConditions = new ushort[] {
            (1 << 0) | (1 << 1) | (1 << 2),
            (1 << 3) | (1 << 4) | (1 << 5),
            (1 << 6) | (1 << 7) | (1 << 8),
            (1 << 0) | (1 << 3) | (1 << 6),
            (1 << 1) | (1 << 4) | (1 << 7),
            (1 << 2) | (1 << 5) | (1 << 8),
            (1 << 0) | (1 << 4) | (1 << 8),
            (1 << 2) | (1 << 4) | (1 << 6)
        };

        public static event _Func OnStart;
        public static event _Func OnOver;

        public delegate void _Func();
        public static bool IsGameStart { get; private set; }


        public static void Start()
        {
            if (IsGameStart)
                return;

            IsGameStart = true;
            OnStart?.Invoke();
        }

        public static void Over()
        {
            if (!IsGameStart)
                return;

            IsGameStart = false;
            OnOver?.Invoke();
        }

        public static bool IsWinner(Player player)
        {
            foreach (ushort flag in WinConditions)
            {
                if ((flag & player.selectedTarget) == flag)
                    return true;
            }

            return false;
        }
    }
}
