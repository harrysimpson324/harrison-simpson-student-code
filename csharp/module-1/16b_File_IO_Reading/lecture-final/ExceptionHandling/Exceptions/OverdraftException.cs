using System;

namespace ExceptionHandling.Exceptions
{
    public class OverdraftException : Exception
    {
        public double OverdraftAmount { get; } = 0.0;

        public OverdraftException(string message, double overdraftAmount)
            : base(message)
        {
            this.OverdraftAmount = overdraftAmount;
        }
    }
}
