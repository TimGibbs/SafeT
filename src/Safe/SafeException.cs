using System;

namespace Safe
{
    public class SafeException<T> : Exception
    {

        public T Value { get; }
        public Error Error { get; }

        public SafeException(string message, T value, Error error) : base(message)
        {
            Value = value;
            Error = error;
        }
    }
}