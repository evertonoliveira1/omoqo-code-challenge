using System.Net;
using System.Text.Json;
using OmoqoCodeChallenge.Application.Exceptions;

namespace OmoqoCodeChallenge.Api.GlobalExceptionHandler
{
    public class ApiExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionHandlerMiddleware(RequestDelegate next)
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
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                ApiErrorResponse responseModel = ApiErrorResponse.Fail(error.Message);

                switch (error)
                {
                    case ApiException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case UnprocessableEntityException:
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;
                    case NotFoundItemException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonSerializer.Serialize(responseModel));
            }
        }
    }
}