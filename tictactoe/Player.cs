using CSharpFunctionalExtensions;

namespace TicTacToe;

internal class Player : IPlayer
{
    public Player(char icon)
    {
        this.icon = icon;
    }

    public char icon { get; init; }

    public Result<PlayerMoves> GetNextMove()
    {
        Console.WriteLine($"Player {icon} - Enter row (1-3) and column (1-3), separated by a space");
        var input = Console.ReadLine();

        var splittedInput = input?.Split(' ');

        if (int.TryParse(splittedInput?[0], out var targetRow) is false ||
            targetRow < 1 || targetRow > 3)
            return Result.Failure<PlayerMoves>("Invalid target cell row must be betwen 1 and 3");

        if (int.TryParse(splittedInput?[1], out var targetColumn) is false ||
            targetColumn < 1 || targetColumn > 3)
            return Result.Failure<PlayerMoves>("Invalid target cell column must be betwen 1 and 3");

        return Result.Success(new PlayerMoves(targetRow, targetColumn));
    }
}