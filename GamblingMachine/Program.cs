using GamblingMachine.Exceptions;
using System;

namespace GamblingMachine
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Starting balance (in cents): ");
      string startingBalance = Console.ReadLine();
      Console.WriteLine("Bet (in cents):");
      string bet = Console.ReadLine();
      Console.WriteLine("Number of spins to emulate:");
      string numberOfSpins = Console.ReadLine();

      var userInput = new UserInput(startingBalance, bet, numberOfSpins);
      Validator(userInput);
      var screen = new GamblingMachineScreen();
      var game = new GamblingMachineGame(userInput.StartingBalance, userInput.Bet, userInput.NumberOfSpins);
      game.PlayGame(screen);

    }

    private static void Validator(UserInput userInput)
    {
      if (userInput.Bet <= 0)
      {
        throw new ValidationException("Bet can not be negative or zero value");
      }

      if (userInput.StartingBalance <= 0)
      {
        throw new ValidationException("No available balance");
      }

      if (userInput.NumberOfSpins <= 0)
      {
        throw new ValidationException("Number of spins can not be negative or zero value");
      }

      if (userInput.Bet > userInput.StartingBalance || userInput.Bet * userInput.NumberOfSpins > userInput.StartingBalance)
      {
        throw new ValidationException("Not enough money to make a bet");
      }

    }

  }
}
