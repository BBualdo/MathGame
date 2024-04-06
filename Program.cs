using MathGame.BBualdo;

GameEngine gameEngine = new GameEngine();

do
{
  Console.Clear();
  GameConsole.ShowTitle();
  gameEngine.SelectMode();
  gameEngine.SelectDifficulty();
  gameEngine.SelectNumberOfQuestions();
  gameEngine.CurrentGame.Run();
} while (!gameEngine.CurrentGame.IsGameOn);