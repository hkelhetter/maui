using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Players;

namespace tictactoeTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        RandomPlayer player =new RandomPlayer(PlayerConstants.PlayerOneIcon);
        Result<PlayerMove> move = player.GetNextMove();
        move.IsSuccess.Should().BeTrue();
    }
}