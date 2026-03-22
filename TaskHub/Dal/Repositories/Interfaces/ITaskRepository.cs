using Dal.Entities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий задач
/// </summary>
public interface ITaskRepository
{
    /// <summary>
    /// Создать задачу
    /// </summary>
    Task<TaskEntity> CreateTaskAsync(string title, Guid createdByUserId, DateTimeOffset createdUtc,
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить все задачи
    /// </summary>
    Task<IReadOnlyCollection<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    Task<TaskEntity?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить название задачи
    /// </summary>
    Task<bool> SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    Task DeleteAllTasksAsync(CancellationToken cancellationToken);
}