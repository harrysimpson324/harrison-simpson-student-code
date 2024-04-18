using System;

namespace HotelReservationsClient.Utility
{
    public class BasicLoggerException : Exception
    {
        public BasicLoggerException() : base()
        {
        }
        public BasicLoggerException(string message) : base(message)
        {
        }
        public BasicLoggerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
