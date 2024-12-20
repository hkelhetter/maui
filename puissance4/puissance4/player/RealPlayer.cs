using CSharpFunctionalExtensions;

namespace puissance4.player;

public class RealPlayer(char icon): IPlayer
{
    public char Icon { get; init; }
    public int GetNextMove()
    {
        if (int.TryParse(Console.ReadLine(), out var position))
        {
            return position;
        }
        else
        {
            throw new FormatException("Invalid input. Please enter a valid integer.");
        }
    }
}
