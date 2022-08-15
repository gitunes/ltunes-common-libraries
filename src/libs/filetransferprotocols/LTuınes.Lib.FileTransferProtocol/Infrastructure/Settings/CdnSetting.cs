namespace LTuınes.Lib.FileTransferProtocol.Infrastructure.Settings
{
    public interface ICdnSetting : ISetting
    {
        string Url { get; set; }
        string Version { get; set; }
    }

    public sealed record CdnSetting : ICdnSetting
    {
        public string Url { get; set; }
        public string Version { get; set; }

        public CdnSetting()
        {
        }

        public CdnSetting(string url, string version)
        {
            Url = url;
            Version = version;
        }
    }
}
