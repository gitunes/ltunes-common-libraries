﻿namespace LTunes.Lib.Shared.Constants
{
    /// <summary>
    /// Const header for http client
    /// </summary>
    public static class HeaderKeys
    {
        public const string Authentication = "Authentication";
        public const string Authorization = "Authorization";
        public const string Bearer = "Bearer";

        public const string PlatformType = "x-platform-type";
        public const string CorrelationId = "x-correlation-id";
        public const string ApiVersion = "x-api-version";
        public const string ForwardedFor = "X-FORWARDED-FOR";
        public const string FolderName = "x-folder-name";

        public const string RequestedWithHeader = "X-Requested-With";
        public const string XmlHttpRequest = "XMLHttpRequest";
    }
}
