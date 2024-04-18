using System;
using System.Data.SqlClient;

namespace USCitiesAndParks.Exceptions
{
    public class DaoException : Exception
    {
        public DaoException() : base() { }
        public DaoException(string message) : base(message) { }
 
        // Message string is accepted as-is
        //
        public DaoException(string message, Exception inner) : base(message, inner) { }

        // Append the "inner" exception messsage.
        //
        //public DaoException(string message, Exception inner) : base($"{message}\n{inner.Message}", inner) { }

        // Append the Errors if "inner" exception is SqlException, otherwise just append the "inner" exception message
        //
        //public DaoException(string message, Exception inner) : base(MessageWithErrors(message, inner), inner) { }

        //private static string MessageWithErrors(string message, Exception inner)
        //{
        //    if (inner is SqlException)
        //    {
        //        SqlException sqlException = (SqlException)inner;
        //        foreach (SqlError sqlError in sqlException.Errors)
        //        {
        //            message += $"\nErrorNumber: {sqlError.Number} ErrorMessage: {sqlError.Message}";
        //        }
        //    }
        //    else
        //    {
        //        message += inner.Message;
        //    }

        //    return message;
        //}
    }
}
