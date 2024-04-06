using MathGame.BBualdo.enums;
using MathGame.BBualdo.Helpers;

namespace MathGame.BBualdo.Models
{
  internal class Game
  {
    public GameTypes GameType { get; set; }
    public DateTime Date { get; set; }
    public DifficultyLevels DifficultyLevel { get; set; }
    public int Score { get; set; } = 0;
    public int NumberOfQuestions { get; set; }

    public Game()
    {
      Date = DateTime.Now;
    }

    public void Run()
    {
      char? currentOperator = OperatorChecker.CheckOperators(GameType);

      for (int i = 0; i < NumberOfQuestions; i++)
      {
        if (GameType == GameTypes.Random)
        {
          // Generating new operator for each question
          currentOperator = OperatorChecker.CheckOperators(GameType);
        }

        int num1;
        int num2;

        if (currentOperator == '/')
        {
          int[] nums = DivisionNumbers.GetDivisionNumbers(DifficultyLevel);
          num1 = nums[0];
          num2 = nums[1];
        }
        else
        {
          Random random = new Random();
          num1 = random.Next(1, 10);
          num2 = random.Next(1, 10);
        }

        GameConsole.ShowMessage($"{num1} {currentOperator} {num2} ?");

        string? userAnswer = Console.ReadLine();

        if (string.IsNullOrEmpty(userAnswer))
        {
          GameConsole.ShowError("Wrong answer!");
          continue;
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
          GameConsole.ShowMessage("Correct answer!");
          Score++;
        }
        else
        {
          GameConsole.ShowError("Wrong answer!");
        }
      }

      GameConsole.ShowMessage($"Game over! You answered correctly for {Score} out of {NumberOfQuestions} questions.");
      // Add game to games history
    }
  }
}
