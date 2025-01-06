using PhoneNumber.Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace PhoneNumber.WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                if (!context.Response.HasStarted)
                {
                    var response = context.Response;
                    response.ContentType = "application/json";
                    var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                    switch (error)
                    {
                        case KeyNotFoundException e:
                            // not found error
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            break;
                        default:
                            // unhandled error
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                    }
                    var result = JsonSerializer.Serialize(responseModel);

                    await response.WriteAsync(result);
                }
            }
        }
    }
}
