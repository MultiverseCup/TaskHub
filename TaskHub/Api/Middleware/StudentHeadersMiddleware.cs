namespace Api.Middleware;

public class StudentHeadersMiddleware
{
    private readonly RequestDelegate _next;

    public StudentHeadersMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers["X-Student-Name"] = "Gareyev Artur Robertovich";
            context.Response.Headers["X-Student-Group"] = "RI-240930";
            return Task.CompletedTask;
        });

        await _next(context);
    }
}