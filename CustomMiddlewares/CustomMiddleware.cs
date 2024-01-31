namespace _100_DataTransferUsingMiddlewareInMVCCore.CustomMiddlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Items["SMAK"] = "SARDAR MUDASSAR ALI KHAN";
            // Add a custom header to the response
            context.Response.Headers.Append("X-Custom-Header", "Hello from CustomMiddleware");

            await _next(context);
        }
    }
}
