namespace Api.Controllers.Tasks.Request;

/// <summary>
/// Запрос на создание задачи
/// </summary>
public record CreateTaskRequest
{
    /// <summary>
    /// Название задачи
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Идентификатор пользователя, создающего задачу
    /// </summary>
    public required Guid CreatedByUserId { get; init; }
}