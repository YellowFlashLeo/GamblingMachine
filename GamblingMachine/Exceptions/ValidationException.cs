using System;

namespace GamblingMachine.Exceptions
{
  public class ValidationException: Exception
  {
    public ValidationException(string message)
      : base(message)
    {
    }
  }
}
