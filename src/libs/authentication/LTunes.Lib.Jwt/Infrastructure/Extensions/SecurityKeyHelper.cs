namespace LTunes.Lib.Jwt.Infrastructure.Extensions
{
    public static class SecurityKeyHelper
    {
        /// <summary>
        /// Create security key
        /// </summary>
        /// <param name="securityKey">security key value</param>
        /// <returns>type of security key</returns>
        /// <exception cref="ArgumentNullException">when the security key is null or whitespace</exception>
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            if (string.IsNullOrWhiteSpace(securityKey))
                throw new ArgumentNullException(nameof(securityKey), ExceptionMessage.SecurityKeyRequired);

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
