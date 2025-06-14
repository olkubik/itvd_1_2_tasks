
public class Program
{
    static void Main(string[] args)
    {
        ConsoleManager consoleManager = new ConsoleManager();
        Game game = new Game();
        game.Start(consoleManager);
    }
}

