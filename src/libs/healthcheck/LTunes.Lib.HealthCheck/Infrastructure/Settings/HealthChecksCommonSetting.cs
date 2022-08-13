namespace LTunes.Lib.HealthCheck.Infrastructure.Settings
{
    internal interface IHealthChecksCommonSetting : ISetting
    {
        string Name { get; init; }
        string Url { get; init; }
        string Payload { get; init; }
        string RestorePayload { get; init; }
        int EvaluationTimeInSeconds { get; init; }
        int ApiMaxActiveRequests { get; init; }
        int MaximumHistoryEntriesPerEndpoint { get; init; }
        string ResponseUrl { get; init; }
        string ViewUrl { get; init; }
        string CustomCssUrl { get; init; }
    }

    internal sealed record HealthChecksCommonSetting : IHealthChecksCommonSetting
    {
        public string Name { get; init; }
        public string Url { get; init; }
        public string Payload { get; init; }
        public string RestorePayload { get; init; }
        public int EvaluationTimeInSeconds { get; init; }
        public int ApiMaxActiveRequests { get; init; }
        public int MaximumHistoryEntriesPerEndpoint { get; init; }
        public string ResponseUrl { get; init; }
        public string ViewUrl { get; init; }
        public string CustomCssUrl { get; init; }
    }
}
