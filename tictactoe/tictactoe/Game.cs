namespace TicTacToe;

internal class Game
{
    public static readonly char PlayerOneIcon = 'O';
    public static readonly char PlayerTwoIcon = 'X';

    private readonly Board board;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public Game(IPlayer player1, IPlayer player2, Board board)
    {
        this.board = board;
        this.player1 = player1;
        this.player2 = player2;
    }

    public IPlayer currentPlayer { get; private set; }

    public void Init()
    {
        board.Init();
        currentPlayer = player1;
    }

    public void Play()
    {
        board.DisplayGameBoardAndHeader();

        while (true)
        {
            var playerMoves = currentPlayer.GetNextMove();
            if (playerMoves.IsFailure)
            {
                Console.WriteLine(playerMoves.Error);
                continue;
            }

            var movePlayedSuccessfully = board.PlayMoveOnBoard(playerMoves.Value, currentPlayer.icon);
            if (movePlayedSuccessfully is false)
            {
                Console.WriteLine("Invalid move");
                continue;
            }

            board.DisplayGameBoardAndHeader();

            var gameResult = board.IsGameOver(currentPlayer);
            if (gameResult.HasValue)
            {
                Console.WriteLine(gameResult.Value);
                break;
            }

            SwitchPlayer();
        }
    }

    private void SwitchPlayer()
    {
        if (currentPlayer == player1)
            currentPlayer = player2;
        else
            currentPlayer = player1;
    }
}