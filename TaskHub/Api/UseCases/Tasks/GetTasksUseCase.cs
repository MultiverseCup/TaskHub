using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Logic.Tasks.Services.Interfaces;

namespace Api.UseCases.Tasks;

internal sealed class GetTasksUseCase : IGetTasksUseCase
{
    private readonly ITaskService _taskService;

    public GetTasksUseCase(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IReadOnlyCollection<TaskResponse>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetAllTasksAsync(cancellationToken);
        return tasks
            .Select(x => new TaskResponse(x.Id, x.Title, x.CreatedByUserId, x.CreatedUtc))
            .ToList()
            .AsReadOnly();
    }
}