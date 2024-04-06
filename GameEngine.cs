using MathGame.BBualdo.enums;
using MathGame.BBualdo.Models;

namespace MathGame.BBualdo
{
  internal class GameEngine
  {
    public static void MainMenu()
    {
      GameConsole.ShowMenu();

      string? userInput = Console.ReadLine();

      while (string.IsNullOrEmpty(userInput))
      {
        GameConsole.ShowError("Type letter coresponding to one of the options");
      }

      Game game = new Game(DifficultyLevels.Easy, 5);

      switch (userInput.Trim().ToLower())
      {
        case "v":
          // View History
          break;
        case "a":
          game.GameType = GameTypes.Addition;
          game.Run();
          break;
        case "s":
          game.GameType = GameTypes.Subtraction;
          game.Run();
          break;
        case "m":
          game.GameType = GameTypes.Multiplication;
          game.Run();
          break;
        case "d":
          game.GameType = GameTypes.Division;
          game.Run();
          break;
        case "r":
          game.GameType = GameTypes.Random;
          game.Run();
          break;
        default:
          GameConsole.ShowError("Wrong input!");
          Environment.Exit(1);
          break;
      }
    }
    public static char? CheckOperators(GameTypes gameType)
    {
      char[] operators = { '+', '-', '*', '/' };
      char? currentOperator = null;

      if (gameType == GameTypes.Addition)
        currentOperator = operators[0];
      if (gameType == GameTypes.Subtraction)
        currentOperator = operators[1];
      if (gameType == GameTypes.Multiplication)
        currentOperator = operators[2];
      if (gameType == GameTypes.Division)
        currentOperator = operators[3];
      if (gameType == GameTypes.Random)
      {
        Random random = new Random();
        int index = random.Next(0, 4);
        currentOperator = operators[index];
      }

      return currentOperator;
    }
  }
}
