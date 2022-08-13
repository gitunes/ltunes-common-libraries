namespace LTunes.Lib.Shared.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static int Id(this ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.NameIdentifier));
            if (claim is null)
                return 0;

            return int.Parse(claim.Value);
        }

        public static string NameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
        }

        public static string Name(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Identity.Name;
        }

        public static string Surname(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.GivenName))?.Value;
        }

        public static string Email(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Email))?.Value;
        }

        public static string Role(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Role))?.Value;
        }
    }
}
