using System;
using System.Collections.Generic;
using System.Linq;

namespace GamblingMachine
{
  public class GamblingMachineScreen
  {
    private List<GamblingMachineReel> Reels { get; set; }

    public GamblingMachineScreen()
    {
      Reels = DefaultReelPopulation();
      SortPositions();
    }

    private static List<GamblingMachineReel> DefaultReelPopulation()
    {
      var reels = new List<GamblingMachineReel>
      {
        new GamblingMachineReel(
          new[] { "Bar", "Cherry", "Bar", "Bar", "Bar", "Bar", "Bar", "Cherry", "Bar", "Bar", "777", "Cherry", "Cherry", "Cherry", "Bar", "Bar", "Cherry", "Bar", "Cherry", "Bar" }, 0),
        new GamblingMachineReel(
          new[] { "Bar", "Bar", "Bar", "Bar", "Cherry", "Bar", "Bar", "777", "Bar", "Bar", "Cherry", "Cherry", "Cherry", "777", "Bar", "Bar", "Bar", "Cherry", "Bar", "Cherry" }, 1),
        new GamblingMachineReel(
          new []{ "777", "Cherry","Bar","Cherry","Bar","Bar","Cherry","Cherry","Bar","Bar","Bar","Cherry","Bar","Cherry","Cherry", "Bar", "Bar", "Bar","Cherry","Bar" },2)
      };

      return reels;
    }
    private void SortPositions()
    {
      Reels = Reels.OrderBy(p => p.Index).ToList();
    }

    public Dictionary<int, string> Spin()
    {
      if (Reels == null)
        throw new ArgumentException("Something strange has happened: Reels is null");

      Random randomize = new Random();
      Dictionary<int, string> reelResult = new Dictionary<int, string>();
      var index = 0;
      foreach (var reel in Reels)
      {
        var symbolPosition = randomize.Next(0, reel.Symbols.Length);
        index += 1;
        reelResult.Add(index, reel.Symbols[symbolPosition]);
      }
      return reelResult;
    }
  }
}
