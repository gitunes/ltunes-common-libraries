namespace LTunes.Lib.Hangfire.Infrastructure.Constants
{
    /// <summary>
    /// The working times of the jobs added
    /// </summary>
    public static class CronExpressions
    {
        /// <summary>
        /// Her gece 04:00'de
        /// </summary>
        public const string At4PM = "00 04 * * *";

        /// <summary>
        /// Her 15 dakikada bir kez
        /// </summary>
        public const string AtEvery15thMinute = "*/15 * * * *";

        /// <summary>
        /// Her 10 dakikada 1 kez
        /// </summary>
        public const string AtEvery10thMinute = "*/10 * * * *";

        /// <summary>
        /// Saatte 1 kez
        /// </summary>
        public const string AtMinuteOPastEveryHour = "0 */1 * * *";

        /// <summary>
        /// Her gece 03:00'de
        /// </summary>
        public const string At3AM = "00 03 * * *";

        /// <summary>
        /// Will work at the relevant hour
        /// </summary>
        /// <param name="hour">What time?</param>
        /// <remarks>it will only work 1 times at the specified time.</remarks>
        /// <returns>cron expression</returns>
        public static string AtHour(int hour, int minute = 0) => $"{minute} {hour} * * *";

        /// <summary>
        /// Will work at the relevant minute
        /// </summary>
        /// <param name="minute">What minute?</param>
        /// <returns>cron expression</returns>
        public static string OnceMinute(int minute) => $"*/{minute} * * * *";
    }
}
