using CSharpFunctionalExtensions;

namespace puissance4.player;

public interface IPlayer
{
    public char Icon { get; }
    public int GetNextMove();
}

public abstract class Player : IPlayer
{
    public abstract char Icon { get; }

    public abstract int GetNextMove();

    public override string ToString()
    {
        return $"{Icon}";
    }
}