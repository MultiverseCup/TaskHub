using Api.Controllers.Tasks.Response;

namespace Api.UseCases.Tasks.Interfaces;

public interface ICreateTaskUseCase
{
    Task<TaskResponse> ExecuteAsync(string title, Guid createdByUserId, CancellationToken cancellationToken);
}

public interface IGetTasksUseCase
{
    Task<IReadOnlyCollection<TaskResponse>> ExecuteAsync(CancellationToken cancellationToken);
}

public interface IGetTaskUseCase
{
    Task<TaskResponse?> ExecuteAsync(Guid taskId, CancellationToken cancellationToken);
}

public interface ISetTaskTitleUseCase
{
    Task<bool> ExecuteAsync(Guid taskId, string title, CancellationToken cancellationToken);
}

public interface IDeleteTaskUseCase
{
    Task<bool> ExecuteAsync(Guid taskId, CancellationToken cancellationToken);
}

public interface IDeleteTasksUseCase
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}