namespace LTunes.Lib.Shared.Exceptions
{
    [Serializable]
    public sealed class ParameterException : Exception
    {
        public ParameterException()
        {
        }

        public ParameterException(string message) : base(message)
        {
        }

        private ParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
