using puissance4.board;

namespace puissance4.game;

public class Game(Board board)
{
    public Board board { get; init; } = board;
    public char CurrentPlayer { get; private set; } = 'X';
    
    public void SwitchPlayer()
    {
        this.CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
    }
}