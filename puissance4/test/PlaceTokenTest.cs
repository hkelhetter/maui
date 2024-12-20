using puissance4.board;

namespace test;

public class PlaceTokenTest
{
    [Fact]
    public void PlaceTokenSuccessTest()
    {
        Board board = new Board();
        
        bool actualResult = board.PlaceToken(1, 'X');
        
        Assert.True(actualResult);
    }
    
    [Fact]
    public void PlaceTokenOutOfBoundTest()
    {
        Board board = new Board();
        
        bool actualResultWhenNegative = board.PlaceToken(-1, 'X');
        bool actualResultWhenTooBig = board.PlaceToken(100, 'X');
        
        Assert.False(actualResultWhenNegative);
        Assert.False(actualResultWhenTooBig);
    }
    
    [Fact]
    public void PlaceTokenFullColumnTest()
    {
        Board board = new Board();
        
        for (int i = 0; i < 6; i++)
        {
            board.PlaceToken(1, 'X');
        }
        
        bool actualResult = board.PlaceToken(1, 'X');
        
        Assert.False(actualResult);
    }

    [Fact]
    public void PlaceTokenSuccessVerifyValue()
    {
        Board board = new Board();
        
        board.PlaceToken(1, 'X');
        
        board.Cells[1][board.ColumnLenght - 1].Value = 'X';
    }
}