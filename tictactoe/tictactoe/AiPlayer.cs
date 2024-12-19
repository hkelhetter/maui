using CSharpFunctionalExtensions;

namespace TicTacToe;

public class AiPlayer : IPlayer
{
    public AiPlayer(char icon)
    {
        this.icon = icon;
    }

    public char icon { get; init; }

    public Result<PlayerMoves> GetNextMove()
    {
        var random = new Random();
        var targetRow = random.Next(1, 4);
        var targetColumn = random.Next(1, 4);

        return Result.Success(new PlayerMoves(targetRow, targetColumn));
    }
}