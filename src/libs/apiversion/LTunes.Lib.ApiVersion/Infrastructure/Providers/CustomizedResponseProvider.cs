namespace LTunes.Lib.ApiVersion.Infrastructure.Providers
{
    public sealed class CustomizedResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            ErrorResult errorResult = new(ExceptionMessage.ApiVersionNotCompatible);

            BadRequestObjectResult badRequestObjectResult = new(errorResult);
            badRequestObjectResult.StatusCode = StatusCodes.Status400BadRequest;

            return badRequestObjectResult;
        }
    }
}
