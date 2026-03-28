using Logic.Tasks.Models;

namespace Logic.Tasks.Services.Interfaces;

/// <summary>
/// Сервис задач
/// </summary>
public interface ITaskService
{
    /// <summary>
    /// Создать задачу
    /// </summary>
    Task<TaskModel> CreateTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все задачи
    /// </summary>
    Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);

    /// <summary>
    /// Изменить название задачи
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