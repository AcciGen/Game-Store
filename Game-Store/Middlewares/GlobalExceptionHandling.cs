using Game_Store.Domain.Exceptions;

namespace Game_Store.Middlewares
{
    public class GlobalExceptionHandling
    {
        public RequestDelegate _requestDelegate;
        public ILogger<GlobalExceptionHandling> _logger;

        public GlobalExceptionHandling(RequestDelegate requestDelegate, ILogger<GlobalExceptionHandling> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (NotFoundException notFound)
            {
                context.Response.Redirect("/Exceptions/NotFound");
            }
            catch (AlreadyExistsException alreadyExists)
            {
                int code = 404;
                await HandleException(code, alreadyExists, context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}\n\n- - - - - - - - - - - - - - - - - - -\n\n");
                int code = 500;
                await HandleException(code, ex, context);
            }
        }

        private async Task HandleException(int code, Exception ex, HttpContext context)
        {
            context.Response.Redirect($"/Exceptions/Error?message={ex.Message}&code={code}");
            return;
        }
    }
}
