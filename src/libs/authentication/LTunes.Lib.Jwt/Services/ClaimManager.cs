namespace LTunes.Lib.Jwt.Services
{
    public sealed class ClaimManager : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetEmailAddress()
        {
            string emailAddress = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Email))?.Value;
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ParameterException(ExceptionMessage.ClaimTypeEmailRequired);

            return emailAddress;
        }

        public string GetName()
        {
            string name = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Name))?.Value;
            if (string.IsNullOrWhiteSpace(name))
                throw new ParameterException(ExceptionMessage.ClaimTypeNameRequired);

            return name;
        }

        public int GetUserId()
        {
            string nameIdentifier = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.NameIdentifier))?.Value;
            if (string.IsNullOrWhiteSpace(nameIdentifier))
                throw new ParameterException(ExceptionMessage.ClaimTypeNameIdentifierRequired);

            if (!int.TryParse(nameIdentifier, out int userId))
                throw new ParameterException(ExceptionMessage.ClaimTypeNameIdentifierRequired);

            if (0 >= userId)
                throw new ParameterException(ExceptionMessage.ClaimTypeNameIdentifierRequired);

            return userId;
        }

        public string GetRole()
        {
            string roleName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.Role))?.Value;
            if (string.IsNullOrWhiteSpace(roleName))
                throw new ParameterException(ExceptionMessage.ClaimTypeRoleRequired);

            return roleName;
        }

        public string GetJti()
        {
            string jti = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(JwtRegisteredClaimNames.Jti))?.Value;
            if (string.IsNullOrWhiteSpace(jti))
                throw new ParameterException(ExceptionMessage.ClaimTypeJtiRequired);

            return jti;
        }

        public List<string> GetAudiences()
        {
            List<string> audiences = _httpContextAccessor.HttpContext.User.Claims
                    .Where(p => p.Type.Equals(JwtRegisteredClaimNames.Aud))
                    .Select(p => p.Value).ToList();

            if (audiences.IsNullOrNotAny())
                throw new ParameterException(ExceptionMessage.ClaimTypeAudienceRequired);

            return audiences;
        }

        public string GetAudience()
        {
            string audience = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(JwtRegisteredClaimNames.Aud))?.Value;
            if (string.IsNullOrWhiteSpace(audience))
                throw new ParameterException(ExceptionMessage.ClaimTypeAudienceRequired);

            return audience;
        }

        public string GetUsername()
        {
            string username = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type.Equals(ClaimTypes.GivenName))?.Value;
            if (string.IsNullOrWhiteSpace(username))
                throw new ParameterException(ExceptionMessage.ClaimTypeUsernameRequired);

            return username;
        }

        public string EmailAddress => GetEmailAddress();
        public string Name => GetName();
        public int UserId => GetUserId();
        public string Role => GetRole();
        public string Jti => GetJti();
        public List<string> Audiences => GetAudiences();
        public string Audience => GetAudience();
        public string Username => GetUsername();
    }
}
