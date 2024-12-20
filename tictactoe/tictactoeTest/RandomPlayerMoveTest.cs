﻿using FluentAssertions;
using tictactoe.Players;
using TicTacToe.Players;

namespace tictactoeTest;

public class RandomPlayerMoveTest
{
    [Fact]
    public async void TestRandomPlayer()
    {
        var player = new RandomPlayer(PlayerConstants.PlayerOneIcon);
        CancellationTokenSource cancellationTokenSource = new();
        var move = await player.GetNextMove(cancellationTokenSource);

        move.IsSuccess.Should().BeTrue();
        move.Value.Row.Should().BeInRange(1, 3);
        move.Value.Column.Should().BeInRange(1, 3);
    }
}