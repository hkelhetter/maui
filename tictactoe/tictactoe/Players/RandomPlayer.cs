using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace tictactoe.Players;

public class RandomPlayer : Player
{
    public RandomPlayer(char icon)
    {
        Icon = icon;
    }

    public override char Icon { get; }

    public override async Task<Result<RandomPlayerMove>> GetNextMove(CancellationTokenSource cancellationTokenSource)
    {
        Thread.Sleep(500);
        await cancellationTokenSource.CancelAsync();
        return RandomPlayerMove.Random;
    }
}