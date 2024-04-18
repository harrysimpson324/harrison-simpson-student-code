using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Exceptions
{
    public class DaoException : Exception
    {
        public DaoException() : base()
        {
        }
        public DaoException(string message) : base(message)
        {
        }
        public DaoException(string message, Exception inner) : base($"{message} - {inner.Message}", inner)
        {
        }
    }
}
