﻿namespace LTunes.Lib.Shared.Utilities
{
    /// <summary>
    /// Text extensions
    /// </summary>
    public static class TextExtensions
    {
        /// <summary>
        /// To title case with turkish culture
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>converted title case</returns>
        public static string ToTitleCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return CultureConstants.TurkishCulture.TextInfo.ToTitleCase(text.ToLower(CultureConstants.TurkishCulture));
        }

        /// <summary>
        /// To lower with turkish culture
        /// </summary>
        /// <param name="text">text to be converted</param>
        /// <returns>Text converted to lowercase according to turkish culture</returns>
        public static string ToLowerWithTurkishCulture(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return text.ToLower(CultureConstants.TurkishCulture);
        }

        /// <summary>
        /// To upper with turkish culture
        /// </summary>
        /// <param name="text">text to be converted</param>
        /// <returns>Text converted to uppercase according to turkish culture</returns>
        public static string ToUpperWithTurkishCulture(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return text.ToUpper(CultureConstants.TurkishCulture);
        }

        /// <summary>
        /// To lower with english culture
        /// </summary>
        /// <param name="text">text to be converted</param>
        /// <returns>Text converted to lowercase according to english culture</returns>
        public static string ToLowerWithEnglishCulture(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return text.ToLower(CultureConstants.EnglishCulture);
        }

        /// <summary>
        /// To upper with english culture
        /// </summary>
        /// <param name="text">text to be converted</param>
        /// <returns>Text converted to uppercase according to english culture</returns>
        public static string ToUpperWithEnglishCulture(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            return text.ToUpper(CultureConstants.EnglishCulture);
        }
    }
}