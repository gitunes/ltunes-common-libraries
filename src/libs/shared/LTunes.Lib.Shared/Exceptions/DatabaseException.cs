namespace LTunes.Lib.Shared.Exceptions
{
    [Serializable]
    public sealed class DatabaseException : Exception
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }

        private DatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
