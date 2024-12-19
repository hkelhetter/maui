using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToe;

public class Game
{
    private readonly Board board;
    private readonly IDisplay display;
    private readonly IPlayer player1;
    private readonly IPlayer player2;

    public Game(IDisplay display, IPlayer player1, IPlayer player2)
    {
        board = new Board(display);

        this.player1 = player1;
        this.player2 = player2;

        currentPlayer = this.player1;
        this.display = display;
    }

    public IPlayer currentPlayer { get; private set; }

    public IPlayer Play()
    {
        board.DisplayGameBoard();

        while (true)
        {
            var playerMoves = currentPlayer.GetNextMove();
            if (playerMoves.IsFailure)
            {
                display.WriteLine(playerMoves.Error);
                continue;
            }

            var movePlayedSuccessfully = board.PlayMoveOnBoard(playerMoves.Value, currentPlayer.Icon);
            if (movePlayedSuccessfully is false)
            {
                display.WriteLine("Invalid move");
                continue;
            }

            board.DisplayGameBoard();

            var gameResult = board.IsGameOver();
            if (gameResult == GameResult.WIN || gameResult == GameResult.DRAW) return currentPlayer;
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