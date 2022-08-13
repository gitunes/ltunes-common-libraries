namespace LTunes.Lib.ApiVersion.Infrastructure.Settings
{
    public interface IApiVersionSetting : ISetting
    {
        string HeaderName { get; init; }
        int MajorVersion { get; init; }
        int MinorVersion { get; init; }
    }

    public sealed record ApiVersionSetting : IApiVersionSetting
    {
        public string HeaderName { get; init; }
        public int MajorVersion { get; init; }
        public int MinorVersion { get; init; }
    }
}
