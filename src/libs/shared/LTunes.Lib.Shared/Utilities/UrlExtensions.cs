﻿namespace LTunes.Lib.Shared.Utilities
{
    public static class UrlExtensions
    {
        public static string ToSlugUrl(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text), ExceptionMessage.TextRequired);

            return PrepareUrl(text);
        }

        private static string PrepareUrl(string text)
        {
            text = text.ToLowerInvariant();

            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
            text = Encoding.ASCII.GetString(bytes);
            text = Regex.Replace(text, @"\s", "-", RegexOptions.Compiled);
            text = Regex.Replace(text, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);
            text = text.Trim('-', '_');
            text = Regex.Replace(text, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return text;
        }
    }
}
