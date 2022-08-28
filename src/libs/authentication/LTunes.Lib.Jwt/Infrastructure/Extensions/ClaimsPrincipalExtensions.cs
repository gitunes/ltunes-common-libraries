namespace LTunes.Lib.Jwt.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Get all claim value by claim type
        /// </summary>
        /// <remarks>Belirtilen talep türüne göre değerleri listeler. Örneğin: Role</remarks>
        /// <param name="claimsPrincipal">type of claims principal</param>
        /// <param name="claimType">type of claim type</param>
        /// <returns>type of string list</returns>
        /// <exception cref="ArgumentNullException">when claims principal or claim type is null</exception>
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            if (string.IsNullOrWhiteSpace(claimType))
                throw new ArgumentNullException(nameof(claimType), ExceptionMessage.ClaimTypeRequired);

            ArgumentNullException.ThrowIfNull(claimsPrincipal, nameof(claimsPrincipal));

            return claimsPrincipal.FindAll(claimType).Select(x => x.Value).ToList();
        }

        /// <summary>
        /// Get claim roles
        /// </summary>
        /// <remarks>Kullanıcının rollerini listeler.</remarks>
        /// <param name="claimsPrincipal">type of claims principal</param>
        /// <returns>type of string list</returns>
        /// <exception cref="ArgumentNullException">when claims principal is null</exception>
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            ArgumentNullException.ThrowIfNull(claimsPrincipal, nameof(claimsPrincipal));

            return claimsPrincipal.Claims(ClaimTypes.Role);
        }

        /// <summary>
        /// Get claim audiences
        /// </summary>
        /// <remarks>Kullanıcının sağlayıcılarını listeler.</remarks>
        /// <param name="claimsPrincipal">type of claims principal</param>
        /// <returns>type of string list</returns>
        /// <exception cref="ArgumentNullException">when claims principal is null</exception>
        public static List<string> ClaimAudiences(this ClaimsPrincipal claimsPrincipal)
        {
            ArgumentNullException.ThrowIfNull(claimsPrincipal, nameof(claimsPrincipal));

            return claimsPrincipal.Claims(JwtRegisteredClaimNames.Aud);
        }
    }
}
