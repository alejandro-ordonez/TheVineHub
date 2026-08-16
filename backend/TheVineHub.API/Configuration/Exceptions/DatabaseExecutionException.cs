using System;

namespace TheVineHub.API.Configuration.Exceptions
{
    public class DatabaseExecutionException : Exception
    {
        public DatabaseExecutionException() : base() { }

        public DatabaseExecutionException(string message) : base(message) { }

        public DatabaseExecutionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
