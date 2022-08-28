namespace LTunes.Lib.Jwt.Infrastructure.Extensions
{
    public static class TokenHelper
    {
        /// <summary>
        /// Create refresh token
        /// </summary>
        /// <returns>type of base 64 string</returns>
        public static string CreateRefreshToken()
        {
            var numberByte = new byte[32];
            using var random = RandomNumberGenerator.Create();
            random.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte).Replace("/", "+");
        }
    }
}
