using CSharpFunctionalExtensions;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace tictactoe.Players;

public class RandomPlayer : Player
{
    public RandomPlayer(char icon)
    {
        Icon = icon;
    }

    public override char Icon { get; }

    public override Result<RandomPlayerMove> GetNextMove()
    {
        return RandomPlayerMove.Random;
    }
}