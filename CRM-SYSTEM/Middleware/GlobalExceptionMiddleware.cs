using CRM_SYSTEM.CustomExceptions;

namespace CRM_SYSTEM.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new { message = "Internal server error" };
            int statusCode = StatusCodes.Status500InternalServerError;

            switch (exception)
            {
                case UserNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    response = new { message = exception.Message };
                    break;

                case InvalidPasswordException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new { message = exception.Message };
                    break;

                case UserAlreadyExistsException:
                case ClientAlreadyExistsException:
                    statusCode = StatusCodes.Status409Conflict;
                    response = new { message = exception.Message };
                    break;

                case ClientNotFoundException:
                case NotFoundRoleException:
                case OrderNotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    response = new { message = exception.Message };
                    break;

                case MailNotCorrectException:
                    statusCode = StatusCodes.Status400BadRequest;
                    response = new { message = exception.Message };
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    response = new { message = "Internal server error" };
                    break;
            }

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
