namespace Safe
{
    public struct Safe<T>
    {
        private readonly T _value;
        private readonly Error _error;

        private readonly bool _errorState;

        public bool IsError => _errorState;
        public bool IsSuccess => !_errorState;

        public T AsSuccess => !_errorState ? _value : throw new SafeException<T>("Safe in error state", _value, _error);
        public Error AsError => _errorState ? _error : throw new SafeException<T>("Safe not in error state", _value, _error);


        public Safe(T value)
        {
            _value = value;
            _error = null;
            _errorState = false;
        }

        public Safe(Error error)
        {
            _value = default;
            _error = error;
            _errorState = true;
        }

        public static implicit operator Safe<T>(T item) => new Safe<T>(item);
        public static implicit operator T(Safe<T> item) => item.AsSuccess;
        public static implicit operator Safe<T>(Error item) => new Safe<T>(item);

        public static Safe<T> Ok(T item)
        {
            return item;
        }
        public static Safe<T> Error(Error item)
        {
            return item;
        }
    }
}
