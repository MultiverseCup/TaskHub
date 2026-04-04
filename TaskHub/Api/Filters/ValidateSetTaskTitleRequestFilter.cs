using Api.Controllers.Tasks.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

/// <summary>
/// Фильтр для валидации запроса изменения названия задачи
/// </summary>
public class ValidateSetTaskTitleRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.ContainsKey("request"))
        {
            context.Result = new BadRequestObjectResult(new { error = "Тело запроса отсутствует" });
            return;
        }

        var request = context.ActionArguments["request"] as SetTaskTitleRequest;
        if (request == null)
        {
            context.Result = new BadRequestObjectResult(new { error = "Тело запроса отсутствует" });
            return;
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult(new { error = "Название задачи не задано" });
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}