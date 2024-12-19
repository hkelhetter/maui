using CSharpFunctionalExtensions;
using TicTacToe.Boards;

namespace TicTacToe.Players;

public interface IPlayer
{
    public char Icon { get; }
    public Result<RandomPlayerMove> GetNextMove();
}

public abstract class Player : IPlayer
{
    public abstract char Icon { get; }

    public abstract Result<RandomPlayerMove> GetNextMove();

    public override string ToString()
    {
        return $"{Icon}";
    }
}