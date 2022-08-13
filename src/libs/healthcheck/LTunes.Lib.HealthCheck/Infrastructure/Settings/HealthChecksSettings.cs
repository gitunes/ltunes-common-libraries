namespace LTunes.Lib.HealthCheck.Infrastructure.Settings
{
    public interface IHealthChecksSettings : ISetting
    {
        List<UrlGroupSetting> UrlGroupSettings { get; init; }
    }

    public sealed record HealthChecksSettings : IHealthChecksSettings
    {
        public List<UrlGroupSetting> UrlGroupSettings { get; init; }
    }

    public sealed record UrlGroupSetting : ISetting
    {
        public Uri Url { get; init; }
        public string Name { get; init; }
        public string[] Tags { get; init; }
    }
}
