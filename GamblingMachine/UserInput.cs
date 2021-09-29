using System;
using GamblingMachine.Exceptions;

namespace GamblingMachine
{
  public class UserInput
  {
    public UserInput()
    {
    }
    public UserInput(string startingBalance, string bet, string numberOfSpins)
    {
      StartingBalance = Convert.ToUInt32(startingBalance
                                         ?? throw new ValidationException("Starting Balance conversion issue"));
      Bet = Convert.ToUInt32(bet
                             ?? throw new ValidationException("Bet conversion issue"));
      NumberOfSpins = Convert.ToUInt32(numberOfSpins
                                       ?? throw new ValidationException("Number of Spins conversion issue"));
    }
    public uint StartingBalance { get;}
    public uint Bet { get;}
    public uint NumberOfSpins { get;}
    public override string ToString()
    {
      return string.Concat("StartingBalance: ", StartingBalance, " Bet: ", Bet, " NumberOfSpins: ", NumberOfSpins);
    }
  }
}
