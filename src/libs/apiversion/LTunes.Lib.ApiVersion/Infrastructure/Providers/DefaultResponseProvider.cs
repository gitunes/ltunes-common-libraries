namespace LTunes.Lib.ApiVersion.Infrastructure.Providers
{
    public sealed class DefaultResponseProvider : DefaultErrorResponseProvider
    {
        private readonly int _statusCode;
        private readonly string _errorCode;
        private readonly string _errorMessage;

        public DefaultResponseProvider(
            int statusCode = StatusCodes.Status400BadRequest,
            string errorMessage = null)
        {
            _statusCode = statusCode;
            _errorCode = statusCode.ToString();
            _errorMessage = errorMessage;
        }

        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            if (context.ErrorCode.CurrentCultureIgnoreCase("UnsupportedApiVersion"))
            {
                context = new ErrorResponseContext(
                       context.Request,
                       _statusCode,
                       _errorCode,
                      _errorMessage,
                       context.MessageDetail);
            }

            return base.CreateResponse(context);

        }
    }
}
