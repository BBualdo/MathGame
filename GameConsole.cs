namespace MathGame.BBualdo
{
  internal class GameConsole
  {
    public static void ShowTitle()
    {
      Console.WriteLine("------ Math Game ------");
    }

    public static void ShowMenu()
    {
      Console.WriteLine(@"Welcome! Select one of the options from below:

        V - View History
        A - Play Addition
        S - Play Subtraction
        M - Play Multiplication
        D - Play Division
        R - Plan with Random Operations
        Q - Quit Game
");
    }

    public static void ShowError(string message)
    {
      Console.WriteLine(message);
    }
  }
}
