using CSharpFunctionalExtensions;
using TicTacToe.Boards;

namespace TicTacToe.Players;

public class HumanPlayer : Player
{
    public HumanPlayer(char icon)
    {
        Icon = icon;
    }

    public override char Icon { get; }

    public override async Task<Result<RandomPlayerMove>> GetNextMove(CancellationTokenSource cancellationTokenSource)
    {
        Console.WriteLine($"Player {Icon} - Enter row (1-3) and column (1-3), separated by a space");
        var input = Console.ReadLine();

        var splittedInput = input?.Split(' ');

        if (int.TryParse(splittedInput?[0], out var targetRow) is false ||
            targetRow < 1 || targetRow > 3)
            return Result.Failure<RandomPlayerMove>("Invalid target cell row must be betwen 1 and 3");

        if (int.TryParse(splittedInput?[1], out var targetColumn) is false ||
            targetColumn < 1 || targetColumn > 3)
            return Result.Failure<RandomPlayerMove>("Invalid target cell column must be betwen 1 and 3");

        return Result.Success(new RandomPlayerMove(targetRow, targetColumn));
    }
}