namespace GamblingMachine
{
  public class GamblingMachineReel
  {
    public GamblingMachineReel()
    {
    }
    public GamblingMachineReel(string[] symbols, int index)
    {
      Symbols = symbols;
      Index = index;
    }
    public string[] Symbols { get; }
    public int Index { get; }
  }
}
