namespace LTuınes.Lib.FileTransferProtocol.Infrastructure.Settings
{
    public interface IFtpSetting : ISetting
    {
        string Ip { get; init; }
        string Port { get; init; }
        string Username { get; init; }
        string Password { get; init; }
        string Url { get; init; }
        string Domain { get; init; }
    }

    public sealed record FtpSetting : IFtpSetting
    {
        public string Ip { get; init; }
        public string Port { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string Url { get; init; }
        public string Domain { get; init; }
    }
}
