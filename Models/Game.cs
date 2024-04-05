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
  }
}
