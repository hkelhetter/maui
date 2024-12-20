using puissance4.board;
using puissance4.game;

namespace test;

public class SwitchPlayerTest
{
    [Fact]
    public void SwitchPlayerXToOTest()
    {
        Game game = new Game(new Board());
        
        game.SwitchPlayer();
        
        Assert.Equal('O', game.CurrentPlayer);
    }
}