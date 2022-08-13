namespace LTunes.Lib.Shared.Exceptions
{
    [Serializable]
    public sealed class SettingException : Exception
    {
        public SettingException()
        {
        }

        public SettingException(string message) : base(message)
        {
        }

        private SettingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public SettingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}