using FluentAssertions;
using TicTacToe;
using TicTacToe.Display;
using tictactoe.Players;
using TicTacToe.Players;

namespace tictactoeTest;

public class GameResultTest
{
    [Fact]
    public void TestGameResult()
    {
        var display = new DebugDisplay();
        var player = new RandomPlayer(PlayerConstants.PlayerOneIcon);
        var player2 = new RandomPlayer(PlayerConstants.PlayerTwoIcon);
        var game = new Game(display, player, player2);

        var res = game.Play().Result;

        res.Should().BeOneOf(null, player, player2);
    }
}