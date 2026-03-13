using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Api.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public sealed class ValidateUserRequestAttribute : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.Values.FirstOrDefault();

        if (request is null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var nameProperty = request.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);

        if (nameProperty is null)
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
            return;
        }

        var nameValue = nameProperty.GetValue(request) as string;

        if (string.IsNullOrWhiteSpace(nameValue))
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}