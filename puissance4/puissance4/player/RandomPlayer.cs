using CSharpFunctionalExtensions;

namespace puissance4.player;

public class RandomPlayer(char icon): IPlayer
{
    public char Icon { get;init; }
    public int GetNextMove()
    {
        return new Random().Next(0, 6);
    }
}