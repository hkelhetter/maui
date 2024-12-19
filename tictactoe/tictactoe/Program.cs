using TicTacToe.Display;
using tictactoe.Players;
using TicTacToe.Players;

namespace TicTacToe;

public class Program
{
    public enum SelectPlayerChoices
    {
        HumanVsHuman = 1,
        HumanVsRandom = 2,
        RandomVsRandom = 3
    }

    private static void Main(string[] args)
    {
        IDisplay display = new ConsoleDisplay();

        (IPlayer, IPlayer) players = SelectPlayers();

        var game = new Game(display, players.Item1, players.Item2);

        game.Play();
    }

    private static (IPlayer, IPlayer) SelectPlayers()
    {
        Console.WriteLine("Choose game type:");
        Console.WriteLine("1. Human vs Human (default)");
        Console.WriteLine("2. Human vs Random");
        Console.WriteLine("3. Random vs Random");

        var choice = SelectPlayerChoices.HumanVsHuman;
        try
        {
            choice = (SelectPlayerChoices)int.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
        }

        return choice switch
        {
            SelectPlayerChoices.HumanVsHuman => (new HumanPlayer(PlayerConstants.PlayerOneIcon),
                new HumanPlayer(PlayerConstants.PlayerTwoIcon)),
            SelectPlayerChoices.HumanVsRandom => (new HumanPlayer(PlayerConstants.PlayerOneIcon),
                new RandomPlayer(PlayerConstants.PlayerTwoIcon)),
            SelectPlayerChoices.RandomVsRandom => (new RandomPlayer(PlayerConstants.PlayerOneIcon),
                new RandomPlayer(PlayerConstants.PlayerTwoIcon)),
            _ => (new HumanPlayer(PlayerConstants.PlayerOneIcon), new HumanPlayer(PlayerConstants.PlayerTwoIcon))
        };
    }
}