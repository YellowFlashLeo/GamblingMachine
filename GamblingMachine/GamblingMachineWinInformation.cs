using System;
using System.Collections.Generic;

namespace GamblingMachine
{
  public class GamblingMachineWinInformation
  {
    public Dictionary<string, int> WinCombinations { get;} = new Dictionary<string, int>();
    public float TotalWin { get; set; }

    public void ReportWinCombinations()
    {
      if (WinCombinations != null)
      {
        foreach (var key in WinCombinations.Keys)
        {
          Console.WriteLine("");
          Console.WriteLine($"||{key}||{key}||{key}");
          Console.WriteLine($"Win({TotalWin}): {WinCombinations[key]} of a {key} ");
          Console.WriteLine("");
        }
      }
    }
  }
}
