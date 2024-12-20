using CSharpFunctionalExtensions;
using FluentAssertions;
using TicTacToe;
using TicTacToe.Boards;
using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToeTest;

public class GameTest
{
    [Fact]
    public void Play_TwoFakePlayerTargettingACol_ReturnsPlayerOneWon()
    {
        // Arrange
        var fakePlayer1 = new FakePlayer(
            PlayerConstants.PlayerOneIcon,
            CreateMovesInColumn(1));
        var fakePlayer2 = new FakePlayer(
            PlayerConstants.PlayerTwoIcon,
            CreateMovesInColumn(2));

        var game = new Game(new DebugDisplay(), fakePlayer1, fakePlayer2);

        // Act
        var expectedWinner = game.Play().Result;
        //GameResult actualGameResult = game.Play();

        // Assert
        expectedWinner
            .Should()
            .Be(fakePlayer1);
    }

    private static Queue<RandomPlayerMove> CreateMovesInColumn(int column)
    {
        Queue<RandomPlayerMove> firstColumnMoves = new();
        firstColumnMoves.Enqueue(new RandomPlayerMove(1, column));
        firstColumnMoves.Enqueue(new RandomPlayerMove(2, column));
        firstColumnMoves.Enqueue(new RandomPlayerMove(3, column));
        return firstColumnMoves;
    }
}

public class FakePlayer : Player
{
    private readonly Queue<RandomPlayerMove> moves;

    public FakePlayer(char icon, Queue<RandomPlayerMove> moves)
    {
        Icon = icon;
        this.moves = moves;
    }

    public override char Icon { get; }

    public override async Task<Result<RandomPlayerMove>> GetNextMove(CancellationTokenSource cancellationTokenSource)
    {
        return moves.Dequeue();
    }
}