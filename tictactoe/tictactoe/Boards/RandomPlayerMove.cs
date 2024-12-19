namespace TicTacToe.Boards;

public record RandomPlayerMove(int Row, int Column)
{
    public static RandomPlayerMove Random => new(System.Random.Shared.Next(1, 4), System.Random.Shared.Next(1, 4));
}