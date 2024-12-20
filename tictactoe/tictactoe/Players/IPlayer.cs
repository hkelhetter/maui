using CSharpFunctionalExtensions;
using TicTacToe.Boards;

namespace TicTacToe.Players;

public interface IPlayer
{
    public char Icon { get; }
    public Task<Result<RandomPlayerMove>> GetNextMove(CancellationTokenSource cancellationTokenSource);
}

public abstract class Player : IPlayer
{
    public abstract char Icon { get; }

    public abstract Task<Result<RandomPlayerMove>> GetNextMove(CancellationTokenSource cancellationTokenSource);

    public override string ToString()
    {
        return $"{Icon}";
    }
}