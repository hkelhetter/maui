using puissance4.board;
using puissance4.player;

namespace test;

public class PlayRandomPlayer
{
    [Fact]
    public void PutTokenInRandomColumnSuccessTest()
    {
        RandomPlayer randomPlayer = new RandomPlayer('X');
        Board board = new Board();

        int nextMove = randomPlayer.GetNextMove();
        
        Assert.InRange(nextMove, 0, board.RowLenght - 1);
    }
}