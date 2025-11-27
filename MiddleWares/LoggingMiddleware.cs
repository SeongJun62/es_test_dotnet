using System.Text;

namespace EnsolTest.MiddleWares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            var requestBody = await ReadBody(context.Request);

            _logger.LogInformation("[REQUEST] {method} {path} Body={body}",
                context.Request.Method,
                context.Request.Path,
                requestBody);

            var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation(
                "[RESPONSE] {statusCode} BODY={body}",
                context.Response.StatusCode,
                responseBody);

            await newBody.CopyToAsync(originalBody);
        }

        private async Task<string> ReadBody(HttpRequest request)
        {
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            string body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }
    }


}
