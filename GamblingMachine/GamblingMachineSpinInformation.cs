using System;

namespace GamblingMachine
{
  public class GamblingMachineSpinInformation
  {
    public GamblingMachineSpinInformation()
    {
    }
    public GamblingMachineSpinInformation(string leftSymbol, string middleSymbol, string rightSymbol,
    uint bet, uint balance, uint spinWin, int spinCount)
    {
      LeftSymbol = leftSymbol;
      RightSymbol = rightSymbol;
      MiddleSymbol = middleSymbol;
      Bet = bet;
      SpinWin = spinWin;
      Balance = balance;
      SpinCount = spinCount;
    }
    private string LeftSymbol { get; }
    private string MiddleSymbol { get; }
    private string RightSymbol { get; }
    private uint Bet { get; }
    private uint SpinWin { get; }
    private uint Balance { get; }
    public int SpinCount { get; }

    public void ReportSymbols()
    {
      Console.WriteLine("----------------");
      Console.WriteLine($"||{LeftSymbol}||{MiddleSymbol}||{RightSymbol}");
    }

    public void ReportResults()
    {
      Console.WriteLine("----------------");
      Console.WriteLine($"Spin #{SpinCount}: Bet({Bet}) Win({SpinWin}) Balance({Balance})");
    }

  }
}
