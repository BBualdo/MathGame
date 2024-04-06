using MathGame.BBualdo.enums;

namespace MathGame.BBualdo.Models
{
  internal class Game
  {
    public GameTypes GameType { get; set; }
    public DateTime Date { get; set; }
    public DifficultyLevels DifficultyLevel { get; set; }
    public int Score { get; set; } = 0;
    public int NumberOfQuestions { get; set; }

    public Game(GameTypes gameType, DifficultyLevels difficulty, int numberOfQuestions)
    {
      GameType = gameType;
      Date = DateTime.Now;
      DifficultyLevel = difficulty;
      NumberOfQuestions = numberOfQuestions;
    }

    public void Run()
    {
      char? currentOperator = GameEngine.CheckOperators(GameType);

      for (int i = 0; i < NumberOfQuestions; i++)
      {
        if (GameType == GameTypes.Random)
        {
          // Generating new operator for each question
          currentOperator = GameEngine.CheckOperators(GameType);
        }

        Random random = new Random();
        int num1 = random.Next(1, 10);
        int num2 = random.Next(1, 10);

        Console.WriteLine($"{num1} {currentOperator} {num2} ?");

        string? userAnswer = Console.ReadLine();

        if (string.IsNullOrEmpty(userAnswer))
        {
          Console.WriteLine("Wrong answer!");
        }

        bool isCorrect = false;

        if (int.TryParse(userAnswer, out int result))
        {
          switch (currentOperator)
          {
            case '+':
              isCorrect = result == num1 + num2; break;
            case '-':
              isCorrect = result == num1 - num2; break;
            case '*':
              isCorrect = result == num1 * num2; break;
            case '/':
              if (num2 != 0)
              {
                isCorrect = result == num1 / num2;
              }
              break;
            default:
              GameConsole.ShowError("Invalid operator");
              break;
          }
        }
        else
        {
          GameConsole.ShowError("Wrong answer! Only numbers can be correct answer!");
        }

        if (isCorrect)
        {
          Console.WriteLine("Correct answer!");
          Score++;
        }
        else
        {
          Console.WriteLine("Wrong answer!");
        }
      }

      Console.WriteLine($"Game over! You answered correctly for {Score} out of {NumberOfQuestions} questions.");
      // Add game to games history
    }
  }
}
