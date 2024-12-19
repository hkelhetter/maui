namespace TicTacToe;

internal class Program
{
    private static void Main(string[] args)
    {
        IPlayer player1 = new Player('O');
        IPlayer player2;
        Console.WriteLine("tu veux jouer contre un ordinateur? [OUI/non]");
        var input = Console.ReadLine();
        if (input is "OUI")
            player2 = new AiPlayer('X');
        else
            player2 = new Player('X');
        var game = new Game(player1, player2, new Board());
        game.Init();
        game.Play();
    }
}