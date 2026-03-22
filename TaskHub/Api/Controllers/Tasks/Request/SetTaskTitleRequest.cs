namespace Api.Controllers.Tasks.Request;

/// <summary>
/// Запрос на изменение названия задачи
/// </summary>
public record SetTaskTitleRequest
{
    /// <summary>
    /// Новое название задачи
    /// </summary>
    public required string Title { get; init; }
}