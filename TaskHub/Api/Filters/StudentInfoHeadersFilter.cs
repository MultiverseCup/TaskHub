using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для добавления заголовков с данными студента
/// </summary>
public class StudentInfoHeadersFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        context.HttpContext.Response.Headers.Append("X-Student-Name", "Gareyev Artur Robertovich");
        context.HttpContext.Response.Headers.Append("X-Student-Group", "RI-240930");
    }
}