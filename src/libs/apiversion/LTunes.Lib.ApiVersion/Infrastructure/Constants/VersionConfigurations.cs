namespace LTunes.Lib.ApiVersion.Infrastructure.Constants
{
    /// <summary>
    /// API project versions
    /// </summary>
    public static class VersionNo
    {
        public const string V1 = "1.0";
        public const string V1S2 = "1.2";
        public const string V2 = "2.0";
        public const string V2S4 = "2.4";
        public const string V3 = "3.0";
        public const string V3S7 = "3.7";
    }

    /// <summary>
    /// Route schemes
    /// </summary>
    public static class RouteSchema
    {
        /// <summary>
        /// Versionated schema
        /// </summary>
        public const string Versioned = "api/v{version:apiVersion}/[controller]/[action]";

        /// <summary>
        /// Schema with conventional version
        /// </summary>
        public const string Standart = "api/v1/[controller]/[action]";

        /// <summary>
        /// Unversioned schema
        /// </summary>
        public const string WithAction = "api/[controller]/[action]";

        /// <summary>
        /// Schema without action
        /// </summary>
        public const string WithoutAction = "api/v1/[controller]";
    }
}
