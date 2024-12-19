using CSharpFunctionalExtensions;

namespace TicTacToe;

public interface IPlayer
{
    public char icon { get; init; }
    public Result<PlayerMoves> GetNextMove();
}