namespace LTunes.Lib.Jwt.Infrastructure.Extensions
{
    public static class SigningCredentialsHelper
    {
        /// <summary>
        /// Create signing credentials
        /// </summary>
        /// <param name="securityKey">security key object</param>
        /// <returns>type of signing credentials</returns>
        /// <exception cref="ArgumentNullException">when the security key is null</exception>
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            ArgumentNullException.ThrowIfNull(securityKey, nameof(securityKey));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
