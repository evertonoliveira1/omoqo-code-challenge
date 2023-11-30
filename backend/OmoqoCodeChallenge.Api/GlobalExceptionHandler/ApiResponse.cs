namespace OmoqoCodeChallenge.Api.GlobalExceptionHandler
{
    public class ApiErrorResponse
    {
        public required string Message { get; set; }

        public static ApiErrorResponse Fail(string errorMessage)
        {
            return new ApiErrorResponse { Message = errorMessage };
        }
    }
}