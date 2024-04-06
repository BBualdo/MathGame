﻿using MathGame.BBualdo.enums;
using MathGame.BBualdo.Models;

namespace MathGame.BBualdo
{
  internal class GameEngine
  {
    public Game CurrentGame { get; set; } = new Game();

    public void SelectMode()
    {
      GameConsole.ShowMenu();

      string? userInput = Console.ReadLine();

      while (string.IsNullOrEmpty(userInput))
      {
        GameConsole.ShowError("Type letter coresponding to one of the options");
        userInput = Console.ReadLine();
      }

      switch (userInput.Trim().ToLower())
      {
        case "v":
          // View History
          break;
        case "a":
          CurrentGame.GameType = GameTypes.Addition;
          break;
        case "s":
          CurrentGame.GameType = GameTypes.Subtraction;
          break;
        case "m":
          CurrentGame.GameType = GameTypes.Multiplication;
          break;
        case "d":
          CurrentGame.GameType = GameTypes.Division;
          break;
        case "r":
          CurrentGame.GameType = GameTypes.Random;
          break;
        case "q":
          GameConsole.ShowMessage("Goodbye!");
          Environment.Exit(0);
          break;
        default:
          GameConsole.ShowError("Wrong input!");
          Environment.Exit(1);
          break;
      }
    }

    public void SelectDifficulty()
    {
      GameConsole.ShowDifficulties();

      string? userInput = Console.ReadLine();

      while (string.IsNullOrEmpty(userInput))
      {
        GameConsole.ShowError("Please select one of the difficulty levels.");
        userInput = Console.ReadLine();
      }

      switch (userInput.Trim().ToLower())
      {
        case "e":
          CurrentGame.DifficultyLevel = DifficultyLevels.Easy; break;
        case "m":
          CurrentGame.DifficultyLevel = DifficultyLevels.Medium; break;
        case "h":
          CurrentGame.DifficultyLevel = DifficultyLevels.Hard; break;
        default:
          GameConsole.ShowError("Wrong input!");
          Environment.Exit(1);
          break;
      }
    }

    public void SelectNumberOfQuestions()
    {
      GameConsole.ShowMessage("How much questions you want to be asked?");

      int numberOfQuestions;
      string? userInput = Console.ReadLine();

      while (!int.TryParse(userInput, out _))
      {
        GameConsole.ShowError("Please provide correct number");
        userInput = Console.ReadLine();
      }

      numberOfQuestions = int.Parse(userInput);

      if (numberOfQuestions < 1 || numberOfQuestions > 10)
      {
        GameConsole.ShowError("Number of questions must be between 1 and 10");
      }

      CurrentGame.NumberOfQuestions = numberOfQuestions;
    }
  }
}
