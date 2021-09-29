using System;
using System.Collections.Generic;
using System.Linq;

namespace GamblingMachine
{
  public class GamblingMachineGame
  {
    public GamblingMachineGame()
    {
    }

    public GamblingMachineGame(uint startingBalance, uint bet, uint numberOfSpins)
    {
      Balance = startingBalance;
      Bet = bet;
      NumberOfSpins = numberOfSpins;

      TotalWin = 0;
      TotalBet = 0;
      SpinWin = 0;
    }
    private uint Balance { get; set; }
    private uint NumberOfSpins { get; }
    private uint Bet { get; }
    private float TotalWin { get; set; }
    private uint TotalBet { get; set; }
    private uint SpinWin { get; set; }
    private int SpinCount { get; set; } = 0;
    private GamblingMachineWinInformation WinInfo { get; } = new GamblingMachineWinInformation();
    private readonly List<GamblingMachineSpinInformation> spinsInfo = new List<GamblingMachineSpinInformation>();

    private enum WinAward
    {
      Cherry = 18,
      Bar = 1,
      TripleSeven = 50
    }

    public void PlayGame(GamblingMachineScreen screen)
    {
      for (int i = 0; i < NumberOfSpins; i++)
      {
        var spinResult = screen.Spin();
        CalculateSpinResults(spinResult[1], spinResult[2], spinResult[3]);
      }
      WinInfo.TotalWin = TotalWin;
      WinInfo.ReportWinCombinations();
      ReportSpinsResults();
      ReportRtp();
     
    }
    private void CalculateSpinResults(string firstSymbol, string secondSymbol, string thirdSymbol)
    {
      if (firstSymbol == String.Empty || secondSymbol == String.Empty || thirdSymbol == String.Empty)
        throw new ArgumentException("Symbols passed cant be null, something went wrong");

      Balance -= Bet;
      SpinWin = 0;
      TotalBet = Bet * NumberOfSpins;

      if (firstSymbol.Equals(secondSymbol) && secondSymbol.Equals(thirdSymbol))
      {
        if (firstSymbol == "Cherry")
        {
          SpinWin = (int)WinAward.Cherry * Bet;
          TotalWin += SpinWin;
          Balance += SpinWin;
          AddWinCombination(WinInfo, "Cherry");
        }

        if (firstSymbol == "Bar")
        {
          SpinWin = (int)WinAward.Bar * Bet;
          TotalWin += SpinWin;
          Balance += SpinWin;
          AddWinCombination(WinInfo, "Bar");
        }

        if (firstSymbol == "777")
        {
          SpinWin = (int)WinAward.TripleSeven * Bet;
          TotalWin += SpinWin;
          Balance += SpinWin;
          AddWinCombination(WinInfo, "777");
        }
      }

      SpinCount += 1;
      spinsInfo.Add(new GamblingMachineSpinInformation(firstSymbol, secondSymbol, thirdSymbol, Bet, Balance, SpinWin, SpinCount));
    }

    private void AddWinCombination(GamblingMachineWinInformation winInfo, string symbol)
    {
      if (winInfo == null || symbol == String.Empty)
        throw new ArgumentNullException();

      if (winInfo.WinCombinations.ContainsKey(symbol))
      {
        winInfo.WinCombinations[symbol]++;
      }
      else
      {
        winInfo.WinCombinations.Add(symbol, 1);
      }
    }

    private void ReportSpinsResults()
    {
      if (spinsInfo.Count == 0)
        throw new ArgumentException("There was no spins made");

      foreach (var spinInfo in spinsInfo.OrderBy(s => s.SpinCount))
      {
        spinInfo.ReportSymbols();
        spinInfo.ReportResults();
      }
    }
    private void ReportRtp()
    {
      Console.WriteLine("");
      Console.WriteLine($"RTP is {GetRtp()}");
    }

    // Not sure about correctness of this method
    // RTP = totalBet / totalWin.
    private float GetRtp()
    {
      if (TotalWin <= 0)
        return 0;
      var result = TotalBet / TotalWin;
      return (float)Math.Round(result/10,2);
    }
  }
}
