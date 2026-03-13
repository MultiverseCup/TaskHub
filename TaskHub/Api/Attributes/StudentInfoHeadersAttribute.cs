using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class StudentInfoHeadersAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        context.HttpContext.Response.OnStarting(() =>
        {
            context.HttpContext.Response.Headers["X-Student-Name"] = "Gareyev Artur Robertovich";
            context.HttpContext.Response.Headers["X-Student-Group"] = "RI-240930";
            return Task.CompletedTask;
        });

        await next();
    }
}